using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;

public class GeneratorQRCode
{
    private Texture2D _textureForCode = new Texture2D(256, 256);
    public Texture2D EncodeTextToQrCode(string text)
    {
        Color32[] convertPixelToTexture = Encode(text, _textureForCode.width, _textureForCode.height);
        _textureForCode.SetPixels32(convertPixelToTexture);
        _textureForCode.Apply();
        return _textureForCode;
    }

    private Color32[] Encode(string textForEncode, int width, int height)
    {
        BarcodeWriter writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };

        return writer.Write(textForEncode);
    }
}
