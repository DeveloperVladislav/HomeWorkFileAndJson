using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkFileAndJson
{
	public class Person
	{
		public static string path = @"D:\ДЗ.РепетиторствоC#\Текст\Text.txt";   // путь к файлу
		public int Age { get; set; }
		public string? Name { get; set; }

		public Person(string name,int age)
		{
			Name = name;
			Age = age;
		}

		public async Task WriteInFile()
		{
			string text = await ReadInFile();

			text += $"{Name}, {Age}\n";
			//1 способ через File
			using (FileStream fstream = new FileStream(path, FileMode.Create))
			{
				byte[] buffer = Encoding.Default.GetBytes(text);
				await fstream.WriteAsync(buffer, 0, buffer.Length);
				Console.WriteLine("Данные добавлены в файл");
			}
			//2 способ через Stream
			/*using (StreamWriter writer = new StreamWriter(path, true))
			{
				await writer.WriteLineAsync(text);
				Console.WriteLine("Данные добавлены в файл");
				
			}*/

		}

		public async Task<string> ReadInFile()
		{
			string textFromFile = "";

			// Чтение из файла
			if (File.Exists(path))
			{
				//1 способ через File
				using (FileStream fstream = File.OpenRead(path))
				{
					byte[] buffer = new byte[fstream.Length];
					await fstream.ReadAsync(buffer, 0, buffer.Length);
					textFromFile = Encoding.Default.GetString(buffer);
				}
				//2 способ через Stream
				/*using (StreamReader reader = new StreamReader(path))
				{
					textFromFile = await reader.ReadToEndAsync();
				}*/

			}
			return textFromFile;
		}
	}
}
