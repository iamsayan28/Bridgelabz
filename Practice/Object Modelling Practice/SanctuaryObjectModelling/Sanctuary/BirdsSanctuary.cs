class BirdSanctuary
{
    HashSet<Bird> set = new HashSet<Bird>();

    public void Add(Bird bird)
    {
        set.Add(bird);
    }

    public void Remove(Bird bird)
    {
        set.Remove(bird);
    }

    public void DisplayAllBirds()
    {
        foreach(Bird b in set)
        {
            Console.WriteLine($"Bird Id: {b.ID}, Featherless: {b.Featherless}, ToothLess: {b.ToothLess}, Gender: {b.Gender}");
        }
    }
}