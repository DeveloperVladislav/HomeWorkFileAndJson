using System.IO.Compression;
using System.Text;
using System.Text.Json;

namespace HomeWorkFileAndJson
{
	public class Program
	{
		static async Task Main(string[] args)
		{
			var person = new Person("", 0); // Создаем пустой объект Person
			string allData = await person.ReadInFile();
			Console.WriteLine("Все данные в файле:\n" + allData);
			while (true)
			{
				Console.WriteLine("Введите имя:");
				string? name = Console.ReadLine();
				Console.WriteLine("Введите возраст:");
				int age = Convert.ToInt32(Console.ReadLine());
				person = new Person(name, age);
				await person.WriteInFile();

				allData = await person.ReadInFile();
				Console.WriteLine("Все данные в файле:\n" + allData);
				Console.WriteLine();

				string json = JsonSerializer.Serialize(person);
				Console.WriteLine($"Сериализация объекта Person - {json}");
				Console.WriteLine();
				Person deserializedPerson = JsonSerializer.Deserialize<Person>(json);
				Console.WriteLine($"Десериализация объекта Person - Имя: {deserializedPerson?.Name}, Возраст: {deserializedPerson?.Age}");
				Console.WriteLine();
			}

		}
	}
}