using System;
using System.Collections.Generic; // Required for Queue<T>
using System.Linq; // Used for the updated ToString method

/// <summary>
/// This queue is circular.  When people are added via AddPerson, then they are added to the
/// back of the queue (per FIFO rules).  When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.
/// </summary>
public class TakingTurnsQueue
{
    // Use the standard System.Collections.Generic.Queue<Person>
    private readonly Queue<Person> _people = new();

    // The standard Queue<T> uses 'Count' instead of 'Length'
    public int Length => _people.Count;

    /// <summary>
    /// Add new people to the queue with a name and number of turns.
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and return them. The person should
    /// go to the back of the queue again unless they have no more turns left.
    /// </summary>
    public Person GetNextPerson()
    {
        // Check the Count property to see if the queue is empty
        if (_people.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        // Dequeue the person from the front of the queue.
        Person person = _people.Dequeue();

        // Check for infinite turns (turns <= 0).
        if (person.Turns <= 0)
        {
            // Re-enqueue the person for their next turn.
            _people.Enqueue(person);
        }
        else // The person has a finite number of turns.
        {
            // Decrease their turn count.
            person.Turns--;

            // If they still have turns remaining, add them back to the queue.
            if (person.Turns > 0)
            {
                _people.Enqueue(person);
            }
        }

        // Return the person who just had their turn.
        return person;
    }

    /// <summary>
    /// Provides a string representation of the people in the queue.
    /// </summary>
    public override string ToString()
    {
        // Use string.Join to create a comma-separated list of names.
        // This requires the Person class to have a useful ToString() override.
        return $"[{string.Join(", ", _people.Select(p => p.Name))}]";
    }
}