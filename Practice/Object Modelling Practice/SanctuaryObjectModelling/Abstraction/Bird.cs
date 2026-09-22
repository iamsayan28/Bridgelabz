abstract class Bird
{
    public int ID { get; set; }
    public bool Featherless { get; set; }
    public bool ToothLess { get; set; }
    public Genders Gender{ get; set; }

    public Bird(int id, bool featherless, bool toothless, Genders gender)
    {
        ID = id;
        Featherless = featherless;
        ToothLess = toothless;
        Gender = gender;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Bird other)
            return ID == other.ID;

        return false;
    }

    public override int GetHashCode()
    {
        return ID.GetHashCode();
    }
}

public enum Genders
{
    Male,
    Female
}