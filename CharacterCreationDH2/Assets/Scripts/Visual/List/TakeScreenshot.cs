using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;
using System.IO;

public class TakeScreenshot : MonoBehaviour
{
    public delegate void FinishTakeScreenshot();
    FinishTakeScreenshot finishTakeScreenshot;
    protected Character character;
    List<byte[]> savedImages = new List<byte[]>();
    [SerializeField] RectTransform rectImage;
    protected bool isFirst;

    public void RegDelegate(FinishTakeScreenshot finishTakeScreenshot)
    {
        this.finishTakeScreenshot = finishTakeScreenshot;
    }
    protected void StartScreenshot()
    {
        StartCoroutine(StartSaveImages());
    }

    IEnumerator TakeScreenFirst()
    {
        yield return TakeScreenSecond();
        SetAnchor(0, 0);
        yield return SaveImage();
    }

    IEnumerator TakeScreenSecond()
    {
        yield return TakeScreenThird();
        SetAnchor(0, 1);
        yield return SaveImage();
    }

    IEnumerator TakeScreenThird()
    {
        yield return TakeScreenFourth();
        SetAnchor(1, 1);
        yield return SaveImage();
    }

    IEnumerator TakeScreenFourth()
    {
        SetAnchor(1, 0);
        yield return SaveImage();
    }

    IEnumerator SaveImage()
    {
        yield return new WaitForSeconds(0.1f);
        yield return new WaitForEndOfFrame();
        Texture2D screenImage = new Texture2D(Screen.width, Screen.height);
        //Get Image from screen
        screenImage.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenImage.Apply();
        //Convert to png
        byte[] pngBytes = screenImage.EncodeToPNG();
        savedImages.Add(pngBytes);
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator StartSaveImages()
    {
        Coroutine cor = StartCoroutine(TakeScreenFirst());
        yield return cor;
        CombineImages();

    }

    private void CombineImages()
    {
        List<Bitmap> bitmaps = new List<Bitmap>();
        foreach (byte[] by in savedImages)
        {
            bitmaps.Add(ConvertByteToBitmap(by));
        }
        //Bitmap newImage = new Bitmap(2800, 2160);
        int w = (int)(Screen.width * 1.458f);
        int h = Screen.height * 2;
        Bitmap newImage = new Bitmap(w, h);
        newImage.SetResolution(72, 72);
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(newImage);
        g.DrawImageUnscaled(bitmaps[0], newImage.Width - bitmaps[0].Width, newImage.Height - bitmaps[0].Height);
        g.DrawImageUnscaled(bitmaps[1], newImage.Width - bitmaps[1].Width, 0);
        g.DrawImageUnscaled(bitmaps[2], 0, 0);
        g.DrawImageUnscaled(bitmaps[3], 0, newImage.Height - bitmaps[3].Height);
        if (isFirst)
        {
            newImage.Save($"{Application.dataPath}/StreamingAssets/CharacterSheets/{character.Name}/CharacterSheetFirst.png", System.Drawing.Imaging.ImageFormat.Png);
        }
        else
        {
            newImage.Save($"{Application.dataPath}/StreamingAssets/CharacterSheets/{character.Name}/CharacterSheetSecond.png", System.Drawing.Imaging.ImageFormat.Png);
        }
        
        finishTakeScreenshot?.Invoke();
        Destroy(gameObject);
    }

    private Bitmap ConvertByteToBitmap(byte[] source)
    {
        using (var ms = new MemoryStream(source))
        {
            return new Bitmap(ms);
        }
    }

    private void SetAnchor(int x, int y)
    {
        rectImage.anchorMin = new Vector2(x, y);
        rectImage.anchorMax = new Vector2(x, y);
        rectImage.pivot = new Vector2(x, y);
    }
}
