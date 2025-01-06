using System.Collections.ObjectModel;
using System.Windows.Input;
using People.Models;

namespace People.ViewModels;

public class MainPageViewModel
{
    public ObservableCollection<Person> People { get; set; } = new ObservableCollection<Person>();
    public ICommand DeletePersonCommand { get; }

    public MainPageViewModel()
    {
        DeletePersonCommand = new Command<Person>(DeletePerson);
    }

    public void AddPerson(string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            var newPerson = new Person { Id = People.Count + 1, Name = name };
            People.Add(newPerson);
        }
    }

    public void LoadPeople()
    {
        People.Clear();
        People.Add(new Person { Id = 1, Name = "Matt" });
        People.Add(new Person { Id = 2, Name = "James" });
        People.Add(new Person { Id = 3, Name = "David" });
    }

    private void DeletePerson(Person person)
    {
        if (People.Contains(person))
        {
            People.Remove(person);
        }
    }
}
