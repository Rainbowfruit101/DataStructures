using System.Collections;

namespace Structures;

public class LinkedList<TValue> : IList<TValue>
{
    private Node<TValue> _head;

    public int Count
    {
        get
        {
            var count = 0;
            var current = _head;

            while (current != null)
            {
                count++;
                current = current.Next;
            }

            return count;
        }
    }

    public bool IsReadOnly => false;

    public TValue this[int index]
    {
        get
        {
            var current = _head;

            for (var i = 0; i < index + 1; i++)
            {
                current = current.Next;
            }

            return current.Value;
        }
        set
        {
            var current = _head;

            for (var i = 0; i < index + 1; i++)
            {
                current = current.Next;
            }

            current.Value = value;
        }
    }

    public IEnumerator<TValue> GetEnumerator()
    {
        var current = _head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(TValue item)
    {
        var last = GetLast();
        var newNode = new Node<TValue>()
        {
            Value = item
        };
        if (last == null)
        {
            _head = newNode;
        }
        else
        {
            last.Next = newNode;
        }
    }

    public void Clear()
    {
        _head = null;
    }

    public bool Contains(TValue item)
    {
        if (_head == null)
        {
            return false;
        }

        var current = _head;

        while (current != null)
        {
            if (current.Value.Equals(item))
            {
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    public void CopyTo(TValue[] array, int arrayIndex)
    {
        //this.ToArray().CopyTo(array,arrayIndex);

        if (array.Length - arrayIndex < Count)
        {
            throw new ArgumentException(
                "Destination array was not long enough. Check the destination index, length, and the array's lower bounds.");
        }

        var current = _head;
        var amount = Count + arrayIndex;
        for (var i = arrayIndex; i < amount; i++)
        {
            array[i] = current.Value;
            current = current.Next;
        }
    }

    public bool Remove(TValue item)
    {
        var index = IndexOf(item);

        if (index < 0)
        {
            return false;
        }

        RemoveAt(index);
        return true;
    }

    public int IndexOf(TValue item)
    {
        if (!Contains(item))
        {
            return -1;
        }

        var current = _head;
        var count = 0;

        while (!current.Value.Equals(item))
        {
            current = current.Next;
            count++;
        }

        return count;
    }

    public void Insert(int index, TValue item)
    {
        if (index < 0 || index > Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        Node<TValue> prev = null;
        var current = _head;

        for (var i = 0; i < index; i++)
        {
            prev = current;
            current = current.Next;
        }

        if (prev == null)
        {
            _head = new Node<TValue>()
            {
                Value = item,
                Next = _head
            };
        }
        else
        {
            prev.Next = new Node<TValue>()
            {
                Value = item,
                Next = current
            };
        }
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        Node<TValue> prev = null;
        var current = _head;

        for (var i = 0; i < index; i++)
        {
            prev = current;
            current = current.Next;
        }

        if (prev == null)
        {
            var count = Count;
            if (count == 1)
            {
                _head = null;
            }
            else if (count > 1)
            {
                _head = current.Next;
            }
        }
        else
        {
            prev.Next = current.Next;
        }
    }

    private Node<TValue> GetLast()
    {
        var current = _head;

        if (current == null)
        {
            return null;
        }

        while (current.Next != null)
        {
            current = current.Next;
        }

        return current;
    }
}