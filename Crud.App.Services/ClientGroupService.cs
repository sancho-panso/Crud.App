using Crud.App.Data;
using Crud.App.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Crud.App.Services
{
    public class ClientGroupService : IClientGroupService
    {
        private readonly Context _context;

        public ClientGroupService(Context context)
        {
            _context = context;
        }
        public void Create(string name)
        {
            ClientGroup clientGroup = new ClientGroup(name);
            _context.Add(clientGroup);
            _context.SaveChanges();
        }

        public void Delete(Guid? id)
        {
            var clientGroup = _context.ClientsGroups.Where(c => c.ID == id).FirstOrDefault();
            _context.Remove(clientGroup);
            _context.SaveChanges();
        }

        public void Edit(string name, Guid? id)
        {
            var clientGroup = _context.ClientsGroups.Where(c => c.ID == id).FirstOrDefault();
            clientGroup.Name = name;
            _context.SaveChanges();
        }

        public void EditByName(string newName, string name)
        {
            var clientGroup = _context.ClientsGroups.Where(c => c.Name == name).FirstOrDefault();
            clientGroup.Name = newName;
            _context.SaveChanges();
        }

        public ClientGroup Read(Guid? id)
        {
            var clientGroup = _context.ClientsGroups.Where(c => c.ID == id).FirstOrDefault();
            return clientGroup;

        }

        public Guid ReadByName(string name)
        {
            var clientGroup = _context.ClientsGroups.Where(c => c.Name == name).FirstOrDefault();
            return clientGroup.ID;
        }
    }
}
