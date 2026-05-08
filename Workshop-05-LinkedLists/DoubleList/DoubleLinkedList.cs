using Shared;

namespace DoubleList;

public class DoublyLinkedList<T> : ILinkedList<T> where T : IComparable<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    public bool IsEmpty => _head == null;

    // Adds element in ascending order
    public void Add(T data)
    {
        var newNode = new Node<T>(data);

        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }

        var current = _head;
        while (current != null && current.Data.CompareTo(data) <= 0)
        {
            current = current.Next;
        }

        if (current == null)
        {
            newNode.Previous = _tail;
            _tail!.Next = newNode;
            _tail = newNode;
        }
        else if (current.Previous == null)
        {
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
        }
        else
        {
            newNode.Previous = current.Previous;
            newNode.Next = current;
            current.Previous!.Next = newNode;
            current.Previous = newNode;
        }
    }

    // Shows list forward
    public void ShowForward()
    {
        if (IsEmpty) { Console.WriteLine("The list is empty."); return; }
        var current = _head;
        while (current != null)
        {
            Console.Write($"{current.Data} ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    // Shows list backward
    public void ShowBackward()
    {
        if (IsEmpty) { Console.WriteLine("The list is empty."); return; }
        var current = _tail;
        while (current != null)
        {
            Console.Write($"{current.Data} ");
            current = current.Previous;
        }
        Console.WriteLine();
    }

    // Sorts list in descending order
    public void SortDescending()
    {
        if (IsEmpty) return;
        var current = _head;
        while (current != null)
        {
            var next = current.Next;
            while (next != null)
            {
                if (current.Data.CompareTo(next.Data) < 0)
                {
                    (current.Data, next.Data) = (next.Data, current.Data);
                }
                next = next.Next;
            }
            current = current.Next;
        }
    }

    // Shows the mode(s)
    public void ShowModes()
    {
        if (IsEmpty) { Console.WriteLine("The list is empty."); return; }

        var counts = new Dictionary<T, int>();
        var current = _head;
        while (current != null)
        {
            if (counts.ContainsKey(current.Data))
                counts[current.Data]++;
            else
                counts[current.Data] = 1;
            current = current.Next;
        }

        int maxCount = counts.Values.Max();
        if (maxCount == 1) { Console.WriteLine("No mode (all elements appear once)."); return; }

        var modes = counts.Where(x => x.Value == maxCount).Select(x => x.Key);
        Console.WriteLine($"Mode(s): {string.Join(", ", modes)}");
    }

    // Shows a chart with occurrences
    public void ShowChart()
    {
        if (IsEmpty) { Console.WriteLine("The list is empty."); return; }

        var counts = new Dictionary<T, int>();
        var current = _head;
        while (current != null)
        {
            if (counts.ContainsKey(current.Data))
                counts[current.Data]++;
            else
                counts[current.Data] = 1;
            current = current.Next;
        }

        foreach (var item in counts)
        {
            Console.Write($"{item.Key} ");
            Console.WriteLine(new string('*', item.Value));
        }
    }

    // Checks if an element exists
    public bool Exists(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data.CompareTo(data) == 0) return true;
            current = current.Next;
        }
        return false;
    }

    // Removes first occurrence
    public void RemoveFirst(T data)
    {
        if (IsEmpty) { Console.WriteLine("The list is empty."); return; }

        var current = _head;
        while (current != null)
        {
            if (current.Data.CompareTo(data) == 0)
            {
                RemoveNode(current);
                Console.WriteLine($"First occurrence of '{data}' removed.");
                return;
            }
            current = current.Next;
        }
        Console.WriteLine($"'{data}' not found.");
    }

    // Removes all occurrences
    public void RemoveAll(T data)
    {
        if (IsEmpty) { Console.WriteLine("The list is empty."); return; }

        int count = 0;
        var current = _head;
        while (current != null)
        {
            var next = current.Next;
            if (current.Data.CompareTo(data) == 0)
            {
                RemoveNode(current);
                count++;
            }
            current = next;
        }

        if (count == 0)
            Console.WriteLine($"'{data}' not found.");
        else
            Console.WriteLine($"{count} occurrence(s) of '{data}' removed.");
    }

    private void RemoveNode(Node<T> node)
    {
        if (node.Previous != null)
            node.Previous.Next = node.Next;
        else
            _head = node.Next;

        if (node.Next != null)
            node.Next.Previous = node.Previous;
        else
            _tail = node.Previous;
    }
}
