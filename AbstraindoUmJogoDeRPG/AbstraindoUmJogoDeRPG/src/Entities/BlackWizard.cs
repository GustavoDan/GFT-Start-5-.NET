internal class BlackWizard : Character
{
    public BlackWizard(string Name, int Level) : base(Name, Level, "Black wizard")
    {
    }

    public override string Attack()
    {
        return $"{Name} cast a speel";
    }
}
