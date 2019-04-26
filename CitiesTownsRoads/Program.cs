using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesTownsRoads
{
    
    class Program
    {

        static string _connectionString = "Data Source = (LocalDb)/MSSQLLocalDB; Initial Catalog = CitiesTownsRoads.Exam; Integrated Security = True";
        static void Main(string[] args)
        {
            int i = 0;
            int a;
            Console.WriteLine("1.Добавление");
            Console.WriteLine("2. Удаление");
            Console.WriteLine("3.Выход");

            while (!int.TryParse(Console.ReadLine(), out i))
            {
                Console.WriteLine("Введите цифру ");
            }
            a = i;

            while (a != 1 && a != 2 && a != 3)
            {
                Console.WriteLine("Введите цифру 1, 2, 3");
                while (!int.TryParse(Console.ReadLine(), out i))
                {
                    Console.WriteLine("Введите цифру 1, 2, 3");
                }
                a = i;
            }
            if (a == 1)
            {
                Console.WriteLine("Введите название Страны");
                string nameofCountry = Console.ReadLine();
                Console.WriteLine("Введите название Города");
                string nameOfCity = Console.ReadLine();
                Console.WriteLine("Введите название Дороги");
                string nameOfRoad = Console.ReadLine();

                var country = new Country
                {
                    Name = nameofCountry
                };
                var city = new City
                {
                    Name = nameOfCity,
                    Country = country,
                };
                var road = new Road
                {
                    Name = nameOfRoad,
                    City = city,
                };

                using (var context = new Exam())
                {
                    context.Countries.Add(country);                    
                    context.Cities.Add(city);
                    context.Roads.Add(road);
                    context.SaveChanges(); 
                }
                Console.WriteLine("Успешно добавлено");
            }
            else if (a == 2)
            {
                Console.WriteLine("Не сделал");
                Console.ReadLine();
            }
            else if (a == 3)
            {
                Environment.Exit(0);
            };



           



        }        
    }
}
