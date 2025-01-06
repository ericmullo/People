using People.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace People
{
    public class PersonRepository
    {
        private string _dbPath; // Declaración correcta del campo privado
        private SQLiteConnection conn; // Declaración de la conexión dentro de la clase

        public string StatusMessage { get; set; }

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath; // Inicializa la ruta de la base de datos
        }

        // Método para inicializar la conexión SQLite
        private void Init()
        {
            if (conn != null)
                return; // Si la conexión ya está inicializada, salimos del método

            conn = new SQLiteConnection(_dbPath); // Inicializamos la conexión
            conn.CreateTable<Person>(); // Creamos la tabla Person si no existe
        }

        // Método para agregar una nueva persona
        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init(); // Aseguramos que la conexión esté inicializada

                // Validación básica para asegurarse de que se ha ingresado un nombre
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                // Insertamos la nueva persona en la base de datos
                result = conn.Insert(new Person { Name = name });

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }
        }

        // Método para obtener todas las personas
        public List<Person> GetAllPeople()
        {
            try
            {
                Init(); // Aseguramos que la conexión esté inicializada
                return conn.Table<Person>().ToList(); // Retornamos la lista de personas
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Person>(); // Retornamos una lista vacía en caso de error
        }
    }
}
