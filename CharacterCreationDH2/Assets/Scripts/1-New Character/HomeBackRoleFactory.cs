using UnityEngine;
using Zenject;

public class HomeBackRoleFactory
{
    private DiContainer _diContainer;

    public HomeBackRoleFactory(DiContainer diContainer) => _diContainer = diContainer;

    public ICreator Get(TypeCreator typeCreator)
    {
        switch (typeCreator)
        {
            case TypeCreator.Homeworld:
                return _diContainer.Instantiate<CreatorWorlds>();

            case TypeCreator.Background:
                return _diContainer.Instantiate<CreatorBackgrounds>();

            case TypeCreator.Role:
                return _diContainer.Instantiate<CreatorRole>();

            default:
                throw new System.Exception("Нет такого типа TypeCreator");
        }
    }
}

public enum TypeCreator
{
    Homeworld,
    Background,
    Role
}
