class Duck : Bird, ISwimmable
{
    public Duck(int id, bool featherless, bool toothless, Genders gender) : base(id, featherless, toothless, gender) { }

    public void Swimmable()
    {
        Console.WriteLine("Can swim");
    }
}