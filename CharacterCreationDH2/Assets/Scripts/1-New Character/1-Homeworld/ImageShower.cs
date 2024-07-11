using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ImageShower : MonoBehaviour
{
    [SerializeField] private Image _image;
    private List<Sprite> _sprites = new List<Sprite>();
    private int _id;
    private IEnumerator _coroutine;

    public void SetImage(string path)
    {
        IEnumerable<string> imageFiles = Directory.EnumerateFiles(path, "*.jpg");
        IEnumerable<string> imageFilesJpeg = Directory.EnumerateFiles(path, "*.jpeg");
        foreach (string s in imageFiles)
        {
            _sprites.Add(ReadImage(s));
        }

        foreach (string s in imageFilesJpeg)
        {
            _sprites.Add(ReadImage(s));
        }
        _image.sprite = _sprites[0];
        _coroutine = ChangeSprite();
        StartCoroutine(_coroutine);
    }

    public void ResetImages()
    {
        if(_coroutine != null)
            StopCoroutine(_coroutine);

        _sprites.Clear();
    }

    private Sprite ReadImage(string path)
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

    IEnumerator ChangeSprite()
    {      
        while (true)
        {
            yield return new WaitForSeconds(3);
            if (_id + 1 < _sprites.Count)
                _id += 1;
            
            else
                _id = 0;
            
            _image.sprite = _sprites[_id];
        }
    }
}
