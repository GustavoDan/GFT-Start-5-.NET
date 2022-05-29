internal class WhiteWizard : Character
{
    public WhiteWizard(string Name, int Level) : base(Name, Level, "White wizard")
    {
    }

    public override string Attack()
    {
        return $"{Name} cast a speel";
    }
}
