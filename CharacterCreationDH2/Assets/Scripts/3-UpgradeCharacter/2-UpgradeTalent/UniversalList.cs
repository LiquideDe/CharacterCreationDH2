using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum LISTDIRECTION
{
    HORIZONTAL = 0,
    VERTICAL = 1
}

public abstract class UniversalList : CanDestroyView
{
    [SerializeField] private RectTransform _container;
    [SerializeField] private Mask _mask;
    //[SerializeField] private RectTransform Prefab;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _spacing;
    [SerializeField] private LISTDIRECTION Direction = LISTDIRECTION.HORIZONTAL;
    [SerializeField] private bool _optimize;
    [SerializeField] private Scrollbar _scrollbar;

    private int _num;
    private RectTransform _maskRT;
    private int _numVisible;
    private int _numBuffer = 2;
    private float _containerHalfSize;
    private float _prefabSize;

    private Dictionary<int, int[]> _itemDict = new Dictionary<int, int[]>();
    private List<RectTransform> _listItemRect = new List<RectTransform>();
    private int _numItems = 0;
    private Vector3 _startPos;
    private Vector3 _offsetVec;

    private bool isSubscribed = false;

    private void OnEnable()
    {
        _scrollbar.onValueChanged.AddListener(ReorderItemsByPos);
        isSubscribed = true;
    }


    private void OnDisable() => _scrollbar.onValueChanged.RemoveAllListeners();

    public virtual void Initialize(int countList)
    {
        _num = countList;
        SubWhenOnEnableDontWork();
        _container.anchoredPosition3D = new Vector3(0, 0, 0);

        _maskRT = _mask.GetComponent<RectTransform>();

        Vector2 prefabScale = _prefab.GetComponent<RectTransform>().rect.size;
        _prefabSize = (Direction == LISTDIRECTION.HORIZONTAL ? prefabScale.x : prefabScale.y) + _spacing;

        _container.sizeDelta = Direction == LISTDIRECTION.HORIZONTAL ? (new Vector2(_prefabSize * _num, prefabScale.y)) : (new Vector2(prefabScale.x, _prefabSize * _num));
        _containerHalfSize = Direction == LISTDIRECTION.HORIZONTAL ? (_container.rect.size.x * 0.5f) : (_container.rect.size.y * 0.5f);

        _numVisible = Mathf.CeilToInt((Direction == LISTDIRECTION.HORIZONTAL ? _maskRT.rect.size.x : _maskRT.rect.size.y) / _prefabSize);

        _offsetVec = Direction == LISTDIRECTION.HORIZONTAL ? Vector3.right : Vector3.down;
        _startPos = _container.anchoredPosition3D - (_offsetVec * _containerHalfSize) + (_offsetVec * ((Direction == LISTDIRECTION.HORIZONTAL ? prefabScale.x : prefabScale.y) * 0.5f));
        _numItems = _optimize ? Mathf.Min(_num, _numVisible + _numBuffer) : _num;

        for (int i = 0; i < _numItems; i++)
        {
            GameObject obj = Instantiate(_prefab, _container.transform);
            RectTransform t = obj.GetComponent<RectTransform>();
            t.anchoredPosition3D = _startPos + (_offsetVec * i * _prefabSize);
            _listItemRect.Add(t);
            _itemDict.Add(t.GetInstanceID(), new int[] { i, i });
            obj.SetActive(true);

            IItemForList itemForList = obj.GetComponent<IItemForList>();
            SetTasksAndAnotherToItem(itemForList, i);
        }
        _prefab.SetActive(false);
        _container.anchoredPosition3D += _offsetVec * (_containerHalfSize - ((Direction == LISTDIRECTION.HORIZONTAL ? _maskRT.rect.size.x : _maskRT.rect.size.y) * 0.5f));
    }

    public void ReorderItemsByPos(float normPos)
    {
        if (Direction == LISTDIRECTION.VERTICAL) normPos = 1f - normPos;
        int numOutOfView = Mathf.CeilToInt(normPos * (_num - _numVisible));   //number of elements beyond the left boundary (or top)
        int firstIndex = Mathf.Max(0, numOutOfView - _numBuffer);   //index of first element beyond the left boundary (or top)
        int originalIndex = 0;
        if (_numItems != 0)
            originalIndex = firstIndex % _numItems;

        int newIndex = firstIndex;
        for (int i = originalIndex; i < _numItems; i++)
        {
            moveItemByIndex(_listItemRect[i], newIndex);
            UpdateParametersItem(i, newIndex);
            newIndex++;
        }
        for (int i = 0; i < originalIndex; i++)
        {
            moveItemByIndex(_listItemRect[i], newIndex);
            UpdateParametersItem(i, newIndex);
            newIndex++;
        }
    }

    private void SubWhenOnEnableDontWork()
    {
        if(isSubscribed==false)
            _scrollbar.onValueChanged.AddListener(ReorderItemsByPos);
    }

    private void moveItemByIndex(RectTransform item, int index)
    {
        int id = item.GetInstanceID();
        _itemDict[id][0] = index;
        item.anchoredPosition3D = _startPos + (_offsetVec * index * _prefabSize);
    }

    protected void ClearList()
    {
        for(int i = 0; i < _listItemRect.Count; i++)
        {
            Destroy(_listItemRect[i].gameObject);
        }

        _listItemRect.Clear();
        _itemDict.Clear();
    }

    protected abstract void SetTasksAndAnotherToItem(IItemForList itemForList, int index);
    protected abstract void UpdateParametersItem(int oldIndex, int newIndex);
}
