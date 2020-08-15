using BelajarCRUDApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarCRUDApp.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("BelajarCRUDApp")
        {

        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<TransactionItem> TransactionItems {get; set;}
    }

    
}
