public class PersonRepository : BaseRepository<Person>, IPersonRepository
{
    public PersonRepository(string connectionString) : base(connectionString)
    {
    }
}
