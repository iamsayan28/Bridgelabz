class Ostrich : Bird, INotFlyable
{
    public Ostrich(int id, bool featherless, bool toothless, Genders gender) : base(id, featherless, toothless, gender) 
    { }
    public void NotFlyable()
    {
        Console.WriteLine("Not flyable");
    }
}