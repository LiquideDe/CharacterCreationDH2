using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;
using System.IO;
using System;

public class TakeScreenshot: MonoBehaviour {
    public event Action WorkIsFinished;
    public event Action PageSaved;
    protected ICharacter _character;
    List<Texture2D> savedImages = new List<Texture2D>();
    [SerializeField] RectTransform rectImage;
    public enum PageName { First, Second, Third }
    private string _pageName;
    bool _isManyPages;

    protected void StartScreenshot(string pageName, bool isManyPages = false) {
        _pageName = pageName;
        _isManyPages = isManyPages;
        StartCoroutine(StartSaveImages());
    }

    IEnumerator TakeScreenFirst() {
        yield return TakeScreenSecond();
        SetAnchor(0, 0);
        yield return SaveImage();
    }

    IEnumerator TakeScreenSecond() {
        yield return TakeScreenThird();
        SetAnchor(0, 1);
        yield return SaveImage();
    }

    IEnumerator TakeScreenThird() {
        yield return TakeScreenFourth();
        SetAnchor(1, 1);
        yield return SaveImage();
    }

    IEnumerator TakeScreenFourth() {
        SetAnchor(1, 0);
        yield return SaveImage();
    }

    IEnumerator SaveImage() {
        yield return new WaitForSeconds(0.1f);
        yield return new WaitForEndOfFrame();

        Camera cam = Camera.main;
        Texture2D screenImage = new Texture2D(cam.pixelWidth, cam.pixelHeight);
        //Get Image from screen
        screenImage.ReadPixels(new Rect(0, 0, cam.pixelWidth, cam.pixelHeight), 0, 0);
        screenImage.Apply();
        //Convert to png
        byte[] pngBytes = screenImage.EncodeToPNG();
        savedImages.Add(screenImage);
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator StartSaveImages() {
        Coroutine cor = StartCoroutine(TakeScreenFirst());
        yield return cor;
        CombineImages();

    }

    private void CombineImages() {
        var cached = RenderTexture.active;
        var renderTexture = RenderTexture.GetTemporary(savedImages[0].width, savedImages[0].height);
        var finalTexture = new Texture2D(renderTexture.width * 2, renderTexture.height * 2);
        RenderTexture.active = renderTexture;
        UnityEngine.Graphics.Blit(savedImages[0], renderTexture);
        finalTexture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), savedImages[0].width, 0);
        UnityEngine.Graphics.Blit(savedImages[1], renderTexture);
        finalTexture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), savedImages[0].width, savedImages[0].height);
        UnityEngine.Graphics.Blit(savedImages[2], renderTexture);
        finalTexture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, savedImages[0].height);
        UnityEngine.Graphics.Blit(savedImages[3], renderTexture);
        finalTexture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);

        if (!Directory.Exists($"{Application.dataPath}/StreamingAssets/CharacterSheets/{_character.Name}"))
            Directory.CreateDirectory($"{Application.dataPath}/StreamingAssets/CharacterSheets/{_character.Name}");
        File.WriteAllBytes($"{Application.dataPath}/StreamingAssets/CharacterSheets/{_character.Name}/CharacterSheet{_pageName}.png", finalTexture.EncodeToPNG());
        if (_isManyPages == false) {
            WorkIsFinished?.Invoke();
            Destroy(gameObject);
        } else {
            savedImages.Clear();
            PageSaved?.Invoke();
        }
    }

    private void SetAnchor(int x, int y) {
        rectImage.anchorMin = new Vector2(x, y);
        rectImage.anchorMax = new Vector2(x, y);
        rectImage.pivot = new Vector2(x, y);
    }
}
