using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue one item and dequeue it
    // Expected Result: The dequeued value matches the enqueued value
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        // Enqueue items
        priorityQueue.Enqueue("Low Priority", 1);
        priorityQueue.Enqueue("Medium Priority", 2);
        priorityQueue.Enqueue("High Priority", 3);
        priorityQueue.Enqueue("Another High Priority", 3);

        // Dequeue and check order
        Assert.AreEqual("High Priority", priorityQueue.Dequeue());
        Assert.AreEqual("Another High Priority", priorityQueue.Dequeue());
        Assert.AreEqual("Medium Priority", priorityQueue.Dequeue());
        Assert.AreEqual("Low Priority", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: InvalidOperationException is thrown
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        // Attempt to dequeue from an empty queue
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
        catch (Exception ex)
        {
            Assert.Fail($"Unexpected exception of type {ex.GetType()} caught: {ex.Message}");
        }
    }
     [TestMethod]
    // Scenario: Enqueue a single item and then dequeue it.
    // Expected Result: The item is dequeued correctly.
    // Defect(s) Found: None after the fixes.
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();

        // Enqueue a single item
        priorityQueue.Enqueue("Single Item", 1);

        // Dequeue and verify
        Assert.AreEqual("Single Item", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority to test FIFO behavior.
    // Expected Result: Items are dequeued in the order they were enqueued.
    // Defect(s) Found: None after the fixes.
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();

        // Enqueue items with the same priority
        priorityQueue.Enqueue("First", 2);
        priorityQueue.Enqueue("Second", 2);
        priorityQueue.Enqueue("Third", 2);

        // Dequeue and verify FIFO order
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }
}