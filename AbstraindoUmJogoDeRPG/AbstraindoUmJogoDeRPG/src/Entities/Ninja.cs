internal class Ninja : Character
{
    public Ninja(string Name, int Level) : base(Name, Level, "Ninja")
    {
    }

    public override string Attack()
    {
        return $"{base.Attack()} using his katana";
    }
}
