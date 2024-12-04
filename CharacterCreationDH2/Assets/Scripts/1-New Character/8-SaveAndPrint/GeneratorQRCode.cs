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
        QRCodeWriter qrEncode = new QRCodeWriter(); //�������� QR ����

        Dictionary<EncodeHintType, object> hints = new Dictionary<EncodeHintType, object>();    //��� �������� ���������
        hints.Add(EncodeHintType.CHARACTER_SET, "utf-8");   //���������� � ��������� ��������� utf-8
        BitMatrix qrMatrix = qrEncode.encode(   //�������� ������� QR
            textForEncode,                 //���������� ������
            BarcodeFormat.QR_CODE,  //������ ����, �.�. ������������ QRCodeWriter ����������� QR_CODE
            width,                    //������
            height,                    //������
            hints);                 //���������� �������� ���������

        BarcodeWriter qrWrite = new BarcodeWriter();    //����� ��� ����������� QR � ��������� �����
        return qrWrite.Write(qrMatrix);

    }
}
