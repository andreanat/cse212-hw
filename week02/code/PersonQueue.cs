/// <summary>
/// A basic implementation of a Queue
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the queue
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person)
    {
        _queue.Add(person);//add the person to the end of the queue
    }
    /// <summary>
    /// Remove a person from the queue
    /// </summary>
    /// <returns>The person that was removed</returns>

    public Person Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }
        var person = _queue[0];//get the first person in the queue
        _queue.RemoveAt(0);//remove the first person from the queue
        return person;
    }
    // <summary>
    /// Check if the queue is empty
    /// </summary>
    /// <returns>True if the queue is empty, false otherwise</returns>

    public bool IsEmpty()
    {
        return Length == 0; //return true if the length of the queue is 0
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue.Select(p => p.ToString()))}]";//joins each person to a single string
    }
}