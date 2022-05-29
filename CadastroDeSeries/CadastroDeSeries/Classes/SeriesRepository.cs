internal class SeriesRepository : IRepository<Series>
{
    private List<Series> _seriesList = new List<Series>();

    public List<Series> List { get { return new List<Series>(_seriesList); } }

    public void Insert(Series entity)
    {
        _seriesList.Add(entity);
    }

    public void Update(Series entity)
    {
        _seriesList[entity.Id] = entity;
    }

    public void Delete(int id)
    {
        _seriesList[id].Delete();
    }

    public Series? GetById(int id)
    {
        return id >= 0 && id < _seriesList.Count ? _seriesList[id] : null;
    }

    public int NextId()
    {
        return _seriesList.Count;
    }
}
