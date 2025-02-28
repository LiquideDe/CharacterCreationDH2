using UnityEngine;

namespace CharacterCreation
{
    public class CanDestroyView : MonoBehaviour
    {
        public void DestroyView() => Destroy(gameObject);
    }
}

