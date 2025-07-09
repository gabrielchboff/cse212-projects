using System;
using System.Collections.Generic;
using System.Linq;

public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    /// <summary>
    /// Removes the item with the highest priority from the queue and returns its value.
    /// If there's a tie in priority, the item that was enqueued first is removed.
    /// </summary>
    /// <returns>The value of the highest-priority item.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the queue is empty.</exception>
    public string Dequeue()
    {
        // Verify the queue is not empty
        if (_queue.Count == 0) 
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index of the item with the highest priority
        var highPriorityIndex = 0;
        for (int index = 1; index < _queue.Count; index++)
        {
            // Use '>' to ensure that in a tie, the item closer to the front is kept.
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
        }

        // Retrieve the value and then remove the item from the queue
        var value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex);

        return value;
    }

    /// <summary>
    /// Provides a string representation of the queue's contents.
    /// </summary>
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

/// <summary>
/// Represents a single item in the priority queue, containing a value and a priority.
/// </summary>
internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}