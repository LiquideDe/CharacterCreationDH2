using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;
using ZXing.Common;
using System.Drawing;

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
        QRCodeWriter qrEncode = new QRCodeWriter(); //создание QR кода

        Dictionary<EncodeHintType, object> hints = new Dictionary<EncodeHintType, object>();    //для колекции поведений
        hints.Add(EncodeHintType.CHARACTER_SET, "utf-8");   //добавление в коллекцию кодировки utf-8
        BitMatrix qrMatrix = qrEncode.encode(   //создание матрицы QR
            textForEncode,                 //кодируемая строка
            BarcodeFormat.QR_CODE,  //формат кода, т.к. используется QRCodeWriter применяется QR_CODE
            width,                    //ширина
            height,                    //высота
            hints);                 //применение колекции поведений

        BarcodeWriter qrWrite = new BarcodeWriter();    //класс для кодирования QR в растровом файле
        return qrWrite.Write(qrMatrix);

    }
}
