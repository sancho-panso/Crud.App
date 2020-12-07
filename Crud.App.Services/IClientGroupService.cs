using Crud.App.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.App.Services
{
    interface IClientGroupService
    {
        public void Create(string name);
        public ClientGroup Read(Guid? id);
        public Guid ReadByName(string name);
        public void Edit(string name, Guid? id);
        public void Delete(Guid? id);
        public void EditByName(string newName, string name);


    }
}
