public static class ArraySelector
{
    public static void Run()
    {
        //define arrays and selector
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
       //merge arrays
        var intResult = ListSelector(l1, l2, select);
       //print result
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
        //define arrays and selector
        var l3 = new[] { 'A','A','A','A','A' };//FIRST ARRAY
        var l4 = new[] { 'B','B','B','B','B' };//SECOND ARRAY
        select = new[] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2};//SELECTOR
        //merge arrays
        var charResult = ListSelector(l3, l4, select);
        //print result
        Console.WriteLine("<char[]>{" + string.Join(", ", charResult) + "}"); // <char[]>{A, B, A, B, A, B, A, B, A, B}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        //result array
        var result = new int[select.Length];
        var l1Idx =0;
        var l2Idx =0;
        //iterate over select array
        for (var i = 0; i < select.Length; i++)
        {
            //if select is 1
            if (select[i] == 1)
            {
                //add element from list1
                result[i] = list1[l1Idx++];
            }
            else
            {
                //if selector is 2 pick element from list2
                result[i] = list2[l2Idx++];
            }
        }
        return result;
    }
private static char[] ListSelector(char[] list1, char[] list2, int[] select)
    {
        var result = new char[select.Length]; // Initialize result array
        var l1Idx = 0; // Index for list1
        var l2Idx = 0; // Index for list2

        // Iterate through the selector array
        for (var i = 0; i < select.Length; i++)
        {
            // Use ternary operator for compact logic
            result[i] = select[i] == 1 ? list1[l1Idx++] : list2[l2Idx++];
        }

        return result; // Return merged array
    }
}