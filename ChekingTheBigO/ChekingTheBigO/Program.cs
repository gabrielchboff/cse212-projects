using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine("Performance Testing:");
        Console.WriteLine("--------------------");
        
        // Test with different input sizes to see performance characteristics
        BigOPerformaceCheckerWithTime(() => DoSomething(1000));
        BigOPerformaceCheckerWithTime(() => DoSomething(10000));
        
        var testList = new List<string> { "apple", "banana", "cherry", "date", "elderberry" };
        BigOPerformaceCheckerWithTime(() => ProcessWords(testList));
        BigOPerformaceCheckerWithTime(() => DoAnotherThing(testList));
    }

    // O(n) time complexity - linear
    static void DoSomething(int n)
    {
        long sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += i;
        }
    }
    
    // O(n) time complexity - processes each item once
    static void ProcessWords(List<string> words)
    {
        foreach (var word in words)
        {
            var temp = word.ToUpper();
        }
    }
    
    // O(n^2) time complexity - nested loops
    static void DoAnotherThing(List<string> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            for (int j = 0; j < items.Count; j++)
            {
                var temp = items[i] + items[j];
            }
        }
    }
    
    static void BigOPerformaceCheckerWithTime(Action function)  
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        function();
        stopwatch.Stop();
        Console.WriteLine($"Method: {function.Method.Name}, Execution time: {stopwatch.ElapsedMilliseconds} ms");
    }
}

