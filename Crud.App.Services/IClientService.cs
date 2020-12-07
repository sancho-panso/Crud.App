using Crud.App.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.App.Services
{
    interface IClientService
    {
        public void Read(Guid? id);
        public void ReadByName(string name);
        public void Create();
        public void Edit(Guid client_ID);
        public void Delete(Guid? id);

    }
}
