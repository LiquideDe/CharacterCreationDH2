using UnityEngine;

namespace CharacterCreation
{
    public class CanDestroyView : MonoBehaviour
    {
        public virtual void DestroyView() => Destroy(gameObject);
    }
}

