using Crud.App.Data;
using Crud.App.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crud.App.Services
{
    public class ClientService : IClientService
    {
        private readonly Context _context;

        public ClientService(Context context)
        {
            _context = context;
        }
        public void Create()
        {
            Client client = new Client();
            Dictionary<string, string> data = ClientInput();
            client.Name = data["name"];
            client.BussinessID = data["busID"];
            client.VAT_ID = data["vat"];
            client.Phone = data["phone"];
            client.Email = data["email"];
            AdressService adressService = new AdressService(_context);
            ClientGroupService clientGroupService = new ClientGroupService(_context);
            Console.WriteLine("Input Address");
            client.AdressID = adressService.Create();
            Console.WriteLine("Input Delivery Address");
            client.DeliveryAdressID = adressService.Create();
            Console.WriteLine("Please select Pricelist code");
            client.PricelistCode = (PricelistCode)Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please input Client Group Name");
            string groupName = Console.ReadLine();
            Console.WriteLine("Please input credit limits");
            client.CreditLimit = (double)Convert.ToInt32(Console.ReadLine());
            client.ClientsGroupID = clientGroupService.ReadByName(groupName);
            _context.Add(client);
            _context.SaveChanges();
            
        }

        public void Delete(Guid? clientID)
        {
            var client = _context.Clients.Where(c => c.ID == clientID).FirstOrDefault();
            _context.Remove(client);
            _context.SaveChanges();
        }

        public void Edit(Guid clientID)
        {
            var client = _context.Clients.Where(c => c.ID == clientID).FirstOrDefault();
            Dictionary<string, string> data = ClientInput();
            client.Name = data["name"];
            client.BussinessID = data["busID"];
            client.VAT_ID = data["vat"];
            client.Phone = data["phone"];
            client.Email = data["email"];
            AdressService adressService = new AdressService(_context);
            ClientGroupService clientGroupService = new ClientGroupService(_context);
            Console.WriteLine("Input Address");
            client.AdressID = adressService.Create();
            Console.WriteLine("Input Delivery Address");
            client.DeliveryAdressID = adressService.Create();
            Console.WriteLine("Please select Pricelist code");
            client.PricelistCode = (PricelistCode)Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please input Client Group Name");
            string groupName = Console.ReadLine();
            client.ClientsGroupID = clientGroupService.ReadByName(groupName);
            Console.WriteLine("Please input credit limits");
            client.CreditLimit = (double)Convert.ToInt32(Console.ReadLine());
            _context.SaveChanges();
        }

        public void Read(Guid? clientID)
        {
            AdressService adressService = new AdressService(_context);
            ClientGroupService clientGroupService = new ClientGroupService(_context);
            var client = _context.Clients.Where(c => c.ID == clientID).Include(c=>c.Group).FirstOrDefault();
            ClientOutput(client);
            Console.WriteLine("Client Address");
            adressService.Read(client.AdressID);
            Console.WriteLine("Client Delivery Address");
            adressService.Read(client.DeliveryAdressID);
            Console.WriteLine("Clients Pricelist code");
            Console.WriteLine(client.PricelistCode);
            Console.WriteLine("Client Group");
            Console.WriteLine(client.Group.Name);

        } 
        
        public void ReadByName(string name)
        {
            AdressService adressService = new AdressService(_context);
            ClientGroupService clientGroupService = new ClientGroupService(_context);
            var client = _context.Clients.Where(c => c.Name == name)
                                           .Include(c=>c.Group)
                                           .Include(c=>c.Branches)
                                           .Include(c=>c.ClientsOrders).FirstOrDefault();
            ClientOutput(client);
            Console.WriteLine("Client Address");
            adressService.Read(client.AdressID);
            Console.WriteLine("Client Delivery Address");
            adressService.Read(client.DeliveryAdressID);
            Console.WriteLine("Clients Pricelist code");
            Console.WriteLine(client.PricelistCode);
            Console.WriteLine("Client Group");
            Console.WriteLine(client.Group.Name);
            Console.WriteLine("Credit limit");
            Console.WriteLine(client.CreditLimit);
            Console.WriteLine("Clients orders:");
            foreach (var item in client.ClientsOrders)
            {
                Console.WriteLine(item.OrderNumber);
            } Console.WriteLine("Clients branches:");
            foreach (var item in client.Branches)
            {
                Console.WriteLine(item.BranchName);
            }

        }

        public static Dictionary<string, string> ClientInput()
        {
            Console.WriteLine("Please write Client Name");
            string name = Console.ReadLine();
            Console.WriteLine("Please write Client Business ID");
            string bus_ID = Console.ReadLine();
            Console.WriteLine("Please write Client VAT ID");
            string VAT_ID = Console.ReadLine();
            Console.WriteLine("Please write Client Phone");
            string phone = Console.ReadLine();
            Console.WriteLine("Please write Client Email");
            string email = Console.ReadLine();

            Dictionary<string, string> data = new Dictionary<string, string>()
            {
                { "name", name },
                { "busID", bus_ID },
                { "vat", VAT_ID },
                { "phone", phone },
                { "email", email },
            };
            return data;
        }

        public static void ClientOutput(Client client)
        {
            Console.WriteLine("Client Name");
            Console.WriteLine(client.Name);
            Console.WriteLine("Client Business ID");
            Console.WriteLine(client.BussinessID); ;
            Console.WriteLine("Client VAT ID");
            Console.WriteLine(client.VAT_ID);
            Console.WriteLine("Client Phone");
            Console.WriteLine(client.Phone);
            Console.WriteLine("Client Email");
            Console.WriteLine(client.Email);

        }


    }
}
