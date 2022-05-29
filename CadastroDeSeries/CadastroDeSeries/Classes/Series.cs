internal class Series : BaseEntity
{
    public Genre Genre { get; private set; }
    public string Title { get; private set; }
    public string Synopsis { get; private set; }
    public int ReleaseYear { get; private set; }
    public bool IsDeleted { get; private set; }

    public Series(int id, string title, Genre genre, int releaseYear, string synopsis)
    {
        Id = id;
        Genre = genre;
        Title = title;
        Synopsis = synopsis;
        ReleaseYear = releaseYear;
        IsDeleted = false;
    }

    public override string ToString()
    {
        return $"Title: {Title}{Environment.NewLine}" +
               $"Genre: {Genre}{Environment.NewLine}" +
               $"Synopsis: {Synopsis}{Environment.NewLine}" +
               $"Release Year: {ReleaseYear}{Environment.NewLine}" +
               $"Deleted: {(IsDeleted ? "Yes" : "No")}";
    }

    public void Delete()
    {
        IsDeleted = true;
    }
}
