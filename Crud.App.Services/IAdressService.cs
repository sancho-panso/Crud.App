using Crud.App.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.App.Services
{
    interface IAdressService
    {
        public void Read(Guid? id);
        public Guid Create();
        public void Edit(Guid? id);
        public void Delete(Guid? id);
    }
}
