class Program
{
    public static void Main(string[] args)
    {
        BirdSanctuary sanctuary = new BirdSanctuary();

        Bird duck = new Duck(1,false, false, Genders.Female);
        Bird ostrich = new Ostrich(2, false, false, Genders.Male);
        Bird b1 = new Ostrich(1, false, false, Genders.Female);

        sanctuary.Add(duck);
        sanctuary.Add(ostrich);
        sanctuary.Add(b1);

        sanctuary.DisplayAllBirds();
    }
}