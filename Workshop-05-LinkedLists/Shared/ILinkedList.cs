namespace Shared;

public interface ILinkedList<T>
{
    void Add(T data);
    void ShowForward();
    void ShowBackward();
    void SortDescending();
    void ShowModes();
    void ShowChart();
    bool Exists(T data);
    void RemoveFirst(T data);
    void RemoveAll(T data);
}
