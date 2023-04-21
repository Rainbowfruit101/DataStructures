using System.Collections;

namespace Tests;

public class LinkedListCases : CasesBase
{
    public static IEnumerable CreateCases => Convert(new()
        {
            Name = "Create { 1, 2, 3, 4 }",
            Actual = new Structures.LinkedList<int> { 1, 2, 3, 4 },
            Expected = new[] { 1, 2, 3, 4 }
        },
        new()
        {
            Name = "Create { 1, 2, 3 }",
            Actual = new Structures.LinkedList<int> { 1, 2, 3 },
            Expected = new[] { 1, 2, 3 }
        }
    );

    public static IEnumerable AddCases => Convert(new()
        {
            Name = "Add 5",
            Actual = new Structures.LinkedList<int> { 1, 2, 3, 4 },
            Expected = new[] { 1, 2, 3, 4, 5 },
            Other = new object[] { 5 }
        },
        new()
        {
            Name = "Add 4",
            Actual = new Structures.LinkedList<int> { 1, 2, 3 },
            Expected = new[] { 1, 2, 3, 4 },
            Other = new object[] { 4 }
        }
    );

    public static IEnumerable RemoveCases => Convert(new()
        {
            Name = "Remove last",
            Actual = new Structures.LinkedList<int> { 1, 2, 3, 4, 5 },
            Expected = new[] { 1, 2, 3, 4 },
            Other = new object[] { 5 }
        },
        new()
        {
            Name = "Remove mid",
            Actual = new Structures.LinkedList<int> { 1, 2, 3, 4, 5 },
            Expected = new[] { 1, 2, 4, 5 },
            Other = new object[] { 3 }
        },
        new()
        {
            Name = "Remove first",
            Actual = new Structures.LinkedList<int> { 1, 2, 3, 4 },
            Expected = new[] { 2, 3, 4 },
            Other = new object[] { 1 }
        }
    );

    public static IEnumerable CopyToCases => Convert(new()
        {
            Name = "CopyTo(10, 3) { 1, 2, 3, 4 }",
            Actual = new Structures.LinkedList<int> { 1, 2, 3, 4 },
            Expected = new[] { 0, 0, 0, 1, 2, 3, 4, 0, 0, 0 },
            Other = new object[] { 10, 3 }
        },
        new()
        {
            Name = "CopyTo(6, 0) { 1, 2, 3, 4, 5 }",
            Actual = new Structures.LinkedList<int> { 1, 2, 3, 4, 5 },
            Expected = new [] { 1, 2, 3, 4, 5, 0 },
            Other = new object[] { 6, 0 }
        }
    );

    public static IEnumerable InsertCases => Convert(new()
        {
            Name = "Insert 0 (index 2)",
            Actual = new Structures.LinkedList<int> { 1, 2, 3, 4 },
            Expected = new[] { 1, 2, 0, 3, 4 },
            Other = new object[] { 2, 0 }
        },
        new()
        {
            Name = "Insert 0 (index 0)",
            Actual = new Structures.LinkedList<int> { 1, 2, 3 },
            Expected = new[] { 0, 1, 2, 3 },
            Other = new object[] { 0, 0 }
        },
        new()
        {
            Name = "Insert 0 (index 2 in the end)",
            Actual = new Structures.LinkedList<int> { 1, 2, 3 },
            Expected = new[] { 1, 2, 0, 3 },
            Other = new object[] { 2, 0 }
        }
    );

    public static IEnumerable RemoveAtCases => Convert(new()
        {
            Name = "Remove at 2",
            Actual = new Structures.LinkedList<int> { 1, 2, 0, 3, 4 },
            Expected = new[] { 1, 2, 3, 4 },
            Other = new object[] { 2 }
        },
        new()
        {
            Name = "Remove at first",
            Actual = new Structures.LinkedList<int> { 1, 2, 3, 4 },
            Expected = new[] { 2, 3, 4 },
            Other = new object[] { 0 }
        },
        new()
        {
            Name = "Remove at last",
            Actual = new Structures.LinkedList<int> { 1, 2, 3, 4 },
            Expected = new[] { 1, 2, 3 },
            Other = new object[] { 3 }
        }
    );

    public static IEnumerable ContainsCases => Convert(new()
        {
            Name = "Contains last",
            Actual = new Structures.LinkedList<int> { 1, 2, 3, 4, 5 },
            Expected = true,
            Other = new object[] { 5 }
        },
        new()
        {
            Name = "Contains first",
            Actual = new Structures.LinkedList<int> { 1, 2, 3, 4, 5 },
            Expected = true,
            Other = new object[] { 1 }
        },
        new()
        {
            Name = "Contains false",
            Actual = new Structures.LinkedList<int> { 1, 2, 3, 4 },
            Expected = false,
            Other = new object[] { 9 }
        }
    );

    public static IEnumerable IndexOfCases => Convert(new()
        {
            Name = "Index of last",
            Actual = new Structures.LinkedList<int> { 1, 2, 3, 4, 5 },
            Expected = 4,
            Other = new object[] { 5 }
        },
        new()
        {
            Name = "Index of first",
            Actual = new Structures.LinkedList<int> { 1, 2, 3, 4 },
            Expected = 0,
            Other = new object[] { 1 }
        }
    );

    public static IEnumerable GetEnumeratorCases => Convert(new()
        {
            Name = "Get enumerator { 1, 2, 3, 4, 5 }",
            Actual = new Structures.LinkedList<int> { 1, 2, 3, 4, 5 },
            Expected = new[] { 1, 2, 3, 4, 5 }
        },
        new()
        {
            Name = "Get enumerator { 1, 2, 3 }",
            Actual = new Structures.LinkedList<int> { 1, 2, 3 },
            Expected = new[] { 1, 2, 3 }
        }
    );
}