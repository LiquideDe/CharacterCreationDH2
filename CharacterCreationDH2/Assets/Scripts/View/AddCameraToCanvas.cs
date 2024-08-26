using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class AddCameraToCanvas : MonoBehaviour
{
    private Camera _camera;
    private Canvas _canvas;

    [Inject]
    private void Construct(Camera camera) => _camera = camera;
    // Start is called before the first frame update
    void Start()
    {
        _canvas = GetComponent<Canvas>();
        _canvas.worldCamera = _camera;
    }

}
