using UnityEngine;
using Zenject;

namespace CharacterCreation
{
    public class AddCameraToCanvas : MonoBehaviour
    {
        private Camera _camera;
        private Canvas _canvas;

        [Inject]
        private void Construct(Camera camera) => _camera = camera;

        void Start()
        {
            _canvas = GetComponent<Canvas>();
            _canvas.worldCamera = _camera;
        }
    }
}

