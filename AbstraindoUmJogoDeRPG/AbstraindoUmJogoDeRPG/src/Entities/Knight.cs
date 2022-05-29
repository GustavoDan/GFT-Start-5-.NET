internal class Knight : Character
{
    public Knight(string Name, int Level) : base(Name, Level, "Knight")
    {
    }

    public override string Attack()
    {
        return $"{base.Attack()} using his sword";
    }
}
