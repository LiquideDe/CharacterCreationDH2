using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private MainMenuView _viewPrefab;
    private LvlMediator _lvlMediator;
    // Start is called before the first frame update
    void Start()
    {
        _lvlMediator.MainMenu();
    }

    [Inject]
    private void Construct(LvlMediator lvlMediator)
    {
        _lvlMediator = lvlMediator;
    }
}
