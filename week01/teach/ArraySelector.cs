public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    
    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        var result = new List<int>();
        int indexTracker1 = 0;
        int indexTracker2 = 0;
        
        foreach (int choice in select)
        {
            if (choice == 1 && indexTracker1 < list1.Length)
            {
                result.Add(list1[indexTracker1]);
                indexTracker1++;
            }
            else if (choice == 2 && indexTracker2 < list2.Length)
            {
                result.Add(list2[indexTracker2]);
                indexTracker2++;
            }
        }
        return result.ToArray();
    }
}