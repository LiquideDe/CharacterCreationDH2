public interface ICreator
{
    int Count { get; }

    IHistoryCharacter Get(int id);
}
