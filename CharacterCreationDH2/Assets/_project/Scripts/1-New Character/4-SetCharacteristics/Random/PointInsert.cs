using UnityEngine;
using UnityEngine.EventSystems;

namespace CharacterCreation
{
    public class PointInsert : MonoBehaviour, IDropHandler
    {
        [SerializeField] private CharacteristicCard characteristicCard;
        private bool isEmpty = true;

        private void OnEnable()
        {
            characteristicCard.Reset += ResetBool;
        }

        private void OnDisable()
        {
            characteristicCard.Reset -= ResetBool;
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (isEmpty)
            {
                if (eventData.pointerDrag != null)
                {
                    CardWithNumber cardWith = eventData.pointerDrag.GetComponent<CardWithNumber>();
                    cardWith.SetNewParent(transform);
                    cardWith.GetComponent<RectTransform>().anchoredPosition = transform.GetComponent<RectTransform>().anchoredPosition;
                    characteristicCard.PlusAmount(cardWith.GetAmount());
                    cardWith.gameObject.SetActive(false);
                    isEmpty = false;
                }
            }
        }

        private void ResetBool() => isEmpty = true;
    }
}

