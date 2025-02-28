using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

namespace CharacterCreation
{
    public class CardWithNumber : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [SerializeField] TextMeshProUGUI _text;
        int _amount;
        Vector3 startPos;
        CanvasGroup canvasGroup;
        bool cantReplace;
        private void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position += new Vector3(eventData.delta.x, eventData.delta.y);
        }

        public void SetAmount(int amount)
        {
            gameObject.SetActive(true);
            _amount = amount;
            _text.text = amount.ToString();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            startPos = transform.position;
            canvasGroup.blocksRaycasts = false;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!cantReplace)
            {
                transform.position = startPos;
                canvasGroup.blocksRaycasts = true;
            }
        }

        public int GetAmount()
        {
            return _amount;
        }

        public void SetNewParent(Transform transform)
        {
            cantReplace = true;
            this.transform.SetParent(transform);
        }
    }
}

