using UnityEngine;
using Zenject;

public class LvlFactory
{
    private PrefabHolder _prefabHolder;
    private DiContainer _diContaner;

    public LvlFactory(PrefabHolder prefabHolder, DiContainer diContainer)
    {
        _prefabHolder = prefabHolder;
        _diContaner = diContainer;
    }

    public GameObject Get(TypeScene typeScene)
    {
        GameObject instance = _diContaner.InstantiatePrefab(_prefabHolder.Get(typeScene));
        return instance;
    }
}
