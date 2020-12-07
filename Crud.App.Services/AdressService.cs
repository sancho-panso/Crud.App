using Crud.App.Data;
using Crud.App.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crud.App.Services
{
    public class AdressService : IAdressService
    {
        private readonly Context _context;

        public AdressService(Context context)
        {
            _context = context;
        }
        public Guid Create()
        {
            Dictionary<string, string> data = InputAdress();

            Adress adress = new Adress();
            adress.Building = data["building"];
            adress.Index = data["index"];
            adress.City = data["city"];
            adress.Street = data["street"];
            adress.Country = data["country"];
            _context.Add(adress);
            _context.SaveChanges();
            return adress.ID;
        }

        public void Delete(Guid? id)
        {
            var adress = _context.Adress.Where(c => c.ID == id).FirstOrDefault();
            _context.Remove(adress);
            _context.SaveChanges();
        }

        public void Edit(Guid? id)
        {
            var adress = _context.Adress.Where(c => c.ID == id).FirstOrDefault();
            Dictionary<string, string> data = InputAdress();
            adress.Building = data["building"];
            adress.Index = data["index"];
            adress.City = data["city"];
            adress.Street = data["street"];
            adress.Country = data["country"];
            _context.Add(adress);
            _context.SaveChanges();
        }

        public void Read(Guid? id)
        {
            var adress = _context.Adress.Where(c => c.ID == id).FirstOrDefault();
            OutputAdress(adress);
        }

        public static Dictionary<string, string> InputAdress()
        {
            Console.WriteLine("Please enter country");
            string country = Console.ReadLine();
            Console.WriteLine("Please enter city");
            string city = Console.ReadLine();
            Console.WriteLine("Please enter street");
            string street = Console.ReadLine();
            Console.WriteLine("Please enter building");
            string building = Console.ReadLine();
            Console.WriteLine("Please enter index");
            string index = Console.ReadLine();
            Dictionary<string, string> data = new Dictionary<string, string>()
            {
                { "building", building },
                { "index", index },
                { "street", street },
                { "city", city },
                { "country", country },
            };
            return data;
        }

        public static void OutputAdress(Adress adress)
        {
            Console.WriteLine("Country");
            Console.WriteLine(adress.Country);
            Console.WriteLine("City");
            Console.WriteLine(adress.City);
            Console.WriteLine("Street");
            Console.WriteLine(adress.Street);
            Console.WriteLine("Building");
            Console.WriteLine(adress.Building);
            Console.WriteLine("Index");
            Console.WriteLine(adress.Index);
        }


    }
}
