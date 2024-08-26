using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;
using System.IO;
using System;

public class TakeScreenshot : MonoBehaviour
{
    public event Action WorkIsFinished;
    public event Action PageSaved;
    protected ICharacter _character;
    List<byte[]> savedImages = new List<byte[]>();
    [SerializeField] RectTransform rectImage;
    public enum PageName { First, Second, Third}
    private string _pageName;
    bool _isManyPages;

    protected void StartScreenshot(string pageName, bool isManyPages = false)
    {
        _pageName = pageName;
        _isManyPages = isManyPages;
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
        /*
        yield return new WaitForSeconds(0.1f);
        yield return new WaitForEndOfFrame();
        Texture2D screenImage = new Texture2D(Screen.width, Screen.height);
        //Get Image from screen
        screenImage.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenImage.Apply();
        //Convert to png
        byte[] pngBytes = screenImage.EncodeToPNG();
        savedImages.Add(pngBytes);
        yield return new WaitForSeconds(0.1f);*/

        yield return new WaitForSeconds(0.1f);
        yield return new WaitForEndOfFrame();

        Camera cam = Camera.main;
        Texture2D screenImage = new Texture2D(cam.pixelWidth, cam.pixelHeight);
        //Get Image from screen
        screenImage.ReadPixels(new Rect(0, 0, cam.pixelWidth, cam.pixelHeight), 0, 0);
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
        Camera cam = Camera.main;
        List<Bitmap> bitmaps = new List<Bitmap>();
        foreach (byte[] by in savedImages)
        {
            bitmaps.Add(ConvertByteToBitmap(by));
        }
        //Bitmap newImage = new Bitmap(2800, 2160);
        int w = (int)(cam.pixelWidth * 1.458f);
        int h = cam.pixelHeight * 2;
        Bitmap newImage = new Bitmap(w, h);
        newImage.SetResolution(72, 72);
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(newImage);
        g.DrawImageUnscaled(bitmaps[0], newImage.Width - bitmaps[0].Width, newImage.Height - bitmaps[0].Height);
        g.DrawImageUnscaled(bitmaps[1], newImage.Width - bitmaps[1].Width, 0);
        g.DrawImageUnscaled(bitmaps[2], 0, 0);
        g.DrawImageUnscaled(bitmaps[3], 0, newImage.Height - bitmaps[3].Height);
        if(!Directory.Exists($"{Application.dataPath}/StreamingAssets/CharacterSheets/{_character.Name}"))
            Directory.CreateDirectory($"{Application.dataPath}/StreamingAssets/CharacterSheets/{_character.Name}");
        newImage.Save($"{Application.dataPath}/StreamingAssets/CharacterSheets/{_character.Name}/CharacterSheet{_pageName}.png", System.Drawing.Imaging.ImageFormat.Png);
        if(_isManyPages == false)
        {
            WorkIsFinished?.Invoke();
            Destroy(gameObject);
        }        
        else
        {
            savedImages.Clear();
            PageSaved?.Invoke();
        }
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
