internal abstract class Character
{
    public string Name { get; set; }
    public int Level { get; set; }
    public string Class { get; set; }

    public Character(string Name, int Level, string Class)
    {
        this.Name = Name;
        this.Level = Level;
        this.Class = Class;
    }

    public override string ToString()
    {
        return $"Name: {Name} | Level: {Level} | Class: {Class}";
    }

    public virtual string Attack()
    {
        return $"{Name} attacked";
    }

    public string Attack(int Damage)
    {
        return $"{Attack()} and dealt {(Damage > 6 ? "a critical hit for " : "")}{Damage} of damage";
    }
}
