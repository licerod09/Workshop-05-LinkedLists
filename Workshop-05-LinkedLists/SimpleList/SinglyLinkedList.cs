using Shared;

namespace SimpleList;

public class SinglyLinkedList<T> : ILinkedList<T> where T : IComparable<T>
{
    private Node<T>? _head;

    public bool IsEmpty => _head == null;

    // Adds element in ascending order
    public void Add(T data)
    {
        var newNode = new Node<T>(data);

        if (_head == null || _head.Data.CompareTo(data) >= 0)
        {
            newNode.Next = _head;
            _head = newNode;
            return;
        }

        var current = _head;
        while (current.Next != null && current.Next.Data.CompareTo(data) < 0)
        {
            current = current.Next;
        }

        newNode.Next = current.Next;
        current.Next = newNode;
    }

    // Traverses from head to end
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

    // Traverses backward using recursion
    public void ShowBackward()
    {
        if (IsEmpty) { Console.WriteLine("The list is empty."); return; }
        ShowBackwardHelper(_head);
        Console.WriteLine();
    }

    private void ShowBackwardHelper(Node<T>? node)
    {
        if (node == null) return;
        ShowBackwardHelper(node.Next);
        Console.Write($"{node.Data} ");
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

    // Counts occurrences and shows the most repeated
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

    // Shows one asterisk per occurrence
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

    // Returns true if element exists
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

    // Removes only the first matching node
    public void RemoveFirst(T data)
    {
        if (IsEmpty) { Console.WriteLine("The list is empty."); return; }

        if (_head!.Data.CompareTo(data) == 0)
        {
            _head = _head.Next;
            Console.WriteLine($"First occurrence of '{data}' removed.");
            return;
        }

        var current = _head;
        while (current.Next != null)
        {
            if (current.Next.Data.CompareTo(data) == 0)
            {
                current.Next = current.Next.Next;
                Console.WriteLine($"First occurrence of '{data}' removed.");
                return;
            }
            current = current.Next;
        }
        Console.WriteLine($"'{data}' not found.");
    }

    // Removes all matching nodes
    public void RemoveAll(T data)
    {
        if (IsEmpty) { Console.WriteLine("The list is empty."); return; }

        int count = 0;
        while (_head != null && _head.Data.CompareTo(data) == 0)
        {
            _head = _head.Next;
            count++;
        }

        var current = _head;
        while (current?.Next != null)
        {
            if (current.Next.Data.CompareTo(data) == 0)
            {
                current.Next = current.Next.Next;
                count++;
            }
            else
            {
                current = current.Next;
            }
        }

        if (count == 0)
            Console.WriteLine($"'{data}' not found.");
        else
            Console.WriteLine($"{count} occurrence(s) of '{data}' removed.");
    }
}
