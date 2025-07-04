public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // The result will be a list of doubles that contains the multiples
        var result = new List<double>();

        // Check if the length is negative
        if (length <= 0)
        {
            // Generate an negative length list to properly generate the multiples according to the index
            for (int i = 0; i > length; i--)
            {
                // Add the number to the result
                result.Add(number * (i - 1));
            }
        }
        // Check if the length is 0
        else if (length == 0)
        {
            // Add the number to the result
            result.Add(number);
        }
        else if (length > 0)
        {
            // Loop to generate the multiples according to the length parameter if it is greater than 0
            for (int i = 0; i < length; i++)
            {
                // Add the number to the result
                result.Add(number * (i + 1));
            }    
        }

        // Return the result
        return result.ToArray();
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Get the number of items in the list
        int count = data.Count;

        // Calculate the effective rotation amount using modulo
        // This handles cases where amount is greater than the list size
        int effectiveAmount = amount % count;

        // Get the two parts of the list using GetRange
        // First part: last 'effectiveAmount' elements
        // Second part: remaining elements from the start
        List<int> lastPart = data.GetRange(count - effectiveAmount, effectiveAmount);
        List<int> firstPart = data.GetRange(0, count - effectiveAmount);

        // Clear the original list and add the parts in reverse order
        data.Clear();
        
        // Add the parts in reverse order to the original list
        data.AddRange(lastPart);
        data.AddRange(firstPart);
    }
}
