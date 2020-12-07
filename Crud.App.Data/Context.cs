using Crud.App.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.App.Data
{
    public class Context:DbContext
    {
        public DbSet<Adress> Adress {get; set; }
        public DbSet<Branch> Branches {get; set; }
        public DbSet<Client> Clients {get; set; }
        public DbSet<ClientGroup> ClientsGroups {get; set; }
        public DbSet<Discount> Discounts {get; set; }
        public DbSet<Item> Items {get; set; }
        public DbSet<ItemsGroup> ItemsGroups {get; set; }
        public DbSet<Order> Orders {get; set; }
        public DbSet<OrderedItem> OrderedItems {get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Crud_App;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
