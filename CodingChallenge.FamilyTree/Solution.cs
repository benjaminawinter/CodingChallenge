using System.Collections.Generic;

namespace CodingChallenge.FamilyTree
{
    public class Solution
    {
        public string GetBirthMonth(Person person, string descendantName)
        {
            var peopleQueue = new Queue<Person>();
            peopleQueue.Enqueue(person);

            var people = new List<Person>
            {
                person
            };

            while (peopleQueue.Count > 0)
            {
                var e = peopleQueue.Dequeue();
                if (e.Name == descendantName)
                {
                    return e.Birthday.ToString("MMMM");
                }

                foreach (var descendant in e.Descendants)
                {
                    if (people.Contains(descendant))
                    {
                        continue;
                    }

                    peopleQueue.Enqueue(descendant);
                    people.Add(descendant);
                }
            }

            return string.Empty;
        }
    }
}