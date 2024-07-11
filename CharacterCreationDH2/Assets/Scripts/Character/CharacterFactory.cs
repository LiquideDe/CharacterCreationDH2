using Zenject;

public class CharacterFactory
{
    private DiContainer _diContainer;

    public CharacterFactory(DiContainer diContainer) => _diContainer = diContainer;    

    public Character Get()
    {
        return _diContainer.Instantiate<Character>();
    }
}
