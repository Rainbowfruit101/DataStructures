using NUnit.Framework;


namespace Tests;

[TestFixture]
[TestOf(typeof(Structures.LinkedList<>))]
public class LinkedListIsSame
{
    [TestCaseSource(typeof(LinkedListCases), nameof(LinkedListCases.CreateCases))]
    public void Create(Structures.LinkedList<int> actual, int[] expected)
    {
        CollectionAssert.AreEqual(expected, actual.ToArray());
    }

    [TestCaseSource(typeof(LinkedListCases), nameof(LinkedListCases.AddCases))]
    public void Add(Structures.LinkedList<int> actual, int[] expected, int value)
    {
        actual.Add(value);
        CollectionAssert.AreEqual(expected, actual.ToArray());
    }

    [TestCaseSource(typeof(LinkedListCases), nameof(LinkedListCases.RemoveCases))]
    public void Remove(Structures.LinkedList<int> actual, int[] expected, int value)
    {
        actual.Remove(value);
        CollectionAssert.AreEqual(expected, actual.ToArray());
    }

    [TestCaseSource(typeof(LinkedListCases), nameof(LinkedListCases.CopyToCases))]
    public void CopyTo(Structures.LinkedList<int> actual, int[] expected, int length, int index)
    {
        var newArray = new int[length];
        actual.CopyTo(newArray, index);
        CollectionAssert.AreEqual(expected, newArray.ToArray());
    }

    [TestCaseSource(typeof(LinkedListCases), nameof(LinkedListCases.InsertCases))]
    public void Insert(Structures.LinkedList<int> actual, int[] expected, int index, int item)
    {
        actual.Insert(index, item);
        CollectionAssert.AreEqual(expected, actual.ToArray());
    }

    [TestCaseSource(typeof(LinkedListCases), nameof(LinkedListCases.RemoveAtCases))]
    public void RemoveAt(Structures.LinkedList<int> actual, int[] expected, int index)
    {
        actual.RemoveAt(index);
        CollectionAssert.AreEqual(expected, actual.ToArray());
    }

    [TestCaseSource(typeof(LinkedListCases), nameof(LinkedListCases.ContainsCases))]
    public void Contains(Structures.LinkedList<int> actual, bool expected, int value)
    {
        Assert.AreEqual(expected, actual.Contains(value));
    }

    [TestCaseSource(typeof(LinkedListCases), nameof(LinkedListCases.IndexOfCases))]
    public void IndexOf(Structures.LinkedList<int> actual, int expected, int value)
    {
        Assert.AreEqual(expected, actual.IndexOf(value));
    }

    [TestCaseSource(typeof(LinkedListCases), nameof(LinkedListCases.GetEnumeratorCases))]
    public void GetEnumerator(Structures.LinkedList<int> actualList, int[] expectedArray)
    {
        var expected = expectedArray.AsEnumerable().GetEnumerator();
        var actual = actualList.GetEnumerator();

        Assert.AreEqual(expectedArray.Length, actualList.Count);

        while (expected.MoveNext() && actual.MoveNext())
        {
            Assert.AreEqual(expected.Current, actual.Current);
        }
    }

    [Test]
    public void Clear()
    {
        var expected = Array.Empty<int>();
        var actual = new Structures.LinkedList<int>
        {
            1, 2, 3, 4
        };
        actual.Clear();
        CollectionAssert.AreEqual(expected, actual.ToArray());
    }
}