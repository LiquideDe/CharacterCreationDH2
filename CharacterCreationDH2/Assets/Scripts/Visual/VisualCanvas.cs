using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Text;

public abstract class VisualCanvas : MonoBehaviour
{
    public delegate void ChangeItemToNext();
    public delegate void ChangeItemToPrev();
    [SerializeField] protected Image image;
    [SerializeField] protected TextMeshProUGUI textDescr, textName, textBonusDescr, textCitata;
    [SerializeField] protected GameObject panel;
    protected ChangeItemToNext changeItemNext;
    protected ChangeItemToPrev changeItemPrev;

    protected List<Sprite> images = new List<Sprite>();
    protected string path;
    protected bool isTextFullOpen;
    protected int id;

    protected string ReadText(string nameFile)
    {
        string txt;
        using (StreamReader _sw = new StreamReader(nameFile, Encoding.Default))
        {
            txt = (_sw.ReadToEnd());
            _sw.Close();
        }
        return txt;
    }

    protected Sprite ReadImage(string path)
    {
        if (string.IsNullOrEmpty(path)) return null;
        if (System.IO.File.Exists(path))
        {

            int sprite_width = 100;
            int sprite_height = 100;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(sprite_width, sprite_height, TextureFormat.RGB24, false);
            texture.LoadImage(bytes);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            return sprite;
        }
        return null;
    }

    public void ShowOrHideFullText()
    {
        if (isTextFullOpen)
        {
            panel.SetActive(false);
            //textButton.text = "Show FULL";
            isTextFullOpen = false;
        }
        else
        {
            panel.SetActive(true);
            //textButton.text = "Hide FULL";
            isTextFullOpen = true;
        }
    }

    protected void ChangeImage()
    {
        if (id + 1 < images.Count)
        {
            id += 1;
        }
        else
        {
            id = 0;
        }
        image.sprite = images[id];
    }

    protected void ResetImages()
    {
        CancelInvoke();
        images.Clear();
    }

    public void RegDelegate(ChangeItemToNext changeItemNext, ChangeItemToPrev changeItemPrev)
    {
        Debug.Log("Зарегестрировали переключение");
        if(changeItemNext != null)
        {
            Debug.Log($"Они не нуль");
        }
        else
        {
            Debug.Log("Херня какая то");
        }
        this.changeItemNext = changeItemNext;
        this.changeItemPrev = changeItemPrev;
    }

    public void NextItem()
    {
        ResetImages();
        Debug.Log("Next");
        changeItemNext?.Invoke();
    }

    public void PrevItem()
    {
        ResetImages();
        changeItemPrev?.Invoke();
    }

    protected void SetImage(string path)
    {
        IEnumerable<string> imageFiles = Directory.EnumerateFiles(path, "*.jpg");
        foreach (string s in imageFiles)
        {
            images.Add(ReadImage(s));
        }
        image.sprite = images[0];
    }
}
