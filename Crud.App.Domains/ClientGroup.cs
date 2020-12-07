using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Crud.App.Domains
{
    public class ClientGroup
    {
        public Guid ID { get; set;}
        public string Name { get; set; }
        public List<Client> Clients { get; set; }
        public ClientGroup(string name)
        {
            Guid ID = Guid.NewGuid();
            Name = name;
            Clients = new List<Client>();

        }

    }


}