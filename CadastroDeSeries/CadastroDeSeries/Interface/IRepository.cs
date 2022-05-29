internal interface IRepository<T>
{
    public List<T> List { get; }

    Series? GetById(int id);
    void Insert(T entity);
    void Delete(int id);
    void Update(T entity);
    int NextId();
}
