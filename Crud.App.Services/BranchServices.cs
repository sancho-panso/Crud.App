using Crud.App.Data;
using Crud.App.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crud.App.Services
{
    public class BranchServices : IBranchService
    {
        private readonly Context _context;

        public BranchServices(Context context)
        {
            _context = context;
        }
        public void Create()
        {
            Branch branch = new Branch();
            ClientService clientService = new ClientService(_context);
            AdressService adressService = new AdressService(_context);
            Dictionary<string, string> data = BranchInput();
            var client = _context.Clients.Where(c => c.Name == data["client"])
                                          .FirstOrDefault();
            branch.Client = client;
            branch.BranchName = data["name"];
            branch.Phone = data["phone"];
            branch.Email = data["email"];
            branch.AdressID = adressService.Create();
            branch.DeliveryAdressID = adressService.Create();
            _context.Add(branch);
            _context.SaveChanges();
        }

        public void Delete(Guid? id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Guid client_ID)
        {
            throw new NotImplementedException();
        }

        public void Read(Guid? id)
        {
            throw new NotImplementedException();
        }

        public void ReadByName(string name)
        {
            throw new NotImplementedException();
        }

        public static Dictionary<string, string> BranchInput()
        {
            Console.WriteLine("Please write Clients Name");
            string client = Console.ReadLine();
            Console.WriteLine("Please write Branch Name");
            string name = Console.ReadLine();
            Console.WriteLine("Please write Client Phone");
            string phone = Console.ReadLine();
            Console.WriteLine("Please write Client Email");
            string email = Console.ReadLine();

            Dictionary<string, string> data = new Dictionary<string, string>()
            {
                {"client", client },
                { "name", name },
                { "phone", phone },
                { "email", email },
            };
            return data;
        }
    }
}
