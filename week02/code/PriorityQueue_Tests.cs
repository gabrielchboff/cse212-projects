using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities to test basic dequeue order.
    public void TestPriorityQueue_BasicDequeueOrder()
    {
        // Arrange
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 3);
        priorityQueue.Enqueue("Medium", 2);

        // Act & Assert
        Assert.AreEqual("High", priorityQueue.Dequeue(), "Should dequeue the highest priority item first.");
        Assert.AreEqual("Medium", priorityQueue.Dequeue(), "Should dequeue the next highest priority item.");
        Assert.AreEqual("Low", priorityQueue.Dequeue(), "Should dequeue the lowest priority item last.");
    }

    [TestMethod]
    // Scenario: Enqueue items with the same highest priority to test the tie-breaking rule (FIFO).
    public void TestPriorityQueue_TieBreaker()
    {
        // Arrange
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("Second", 5);

        // Act & Assert
        Assert.AreEqual("First", priorityQueue.Dequeue(), "The first item enqueued with the highest priority should be dequeued first.");
        Assert.AreEqual("Second", priorityQueue.Dequeue(), "The second item with the highest priority should be dequeued second.");
    }
    
    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue to ensure it throws the correct exception.
    public void TestPriorityQueue_EmptyQueueException()
    {
        // Arrange
        var priorityQueue = new PriorityQueue();

        // Act & Assert
        Assert.ThrowsException<System.InvalidOperationException>(() => priorityQueue.Dequeue(), "Dequeuing from an empty queue should throw an InvalidOperationException.");
    }
}