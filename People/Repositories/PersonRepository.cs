using People.Models;
using SQLite;

namespace People.Repositories;

public class PersonRepository
{
    private readonly SQLiteConnection _conn;

    public PersonRepository(string dbPath)
    {
        _conn = new SQLiteConnection(dbPath);
        _conn.CreateTable<Person>();
    }

    public void AddNewPerson(string name)
    {
        var person = new Person { Name = name };
        _conn.Insert(person);
    }

    public List<Person> GetAllPeople()
    {
        return _conn.Table<Person>().ToList();
    }

    public void DeletePerson(Person person)
    {
        _conn.Delete(person);
    }
}
