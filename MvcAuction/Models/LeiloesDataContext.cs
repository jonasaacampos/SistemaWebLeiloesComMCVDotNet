using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcAuction.Models
{
    public class LeiloesDataContext : DbContext
    {
        public DbSet<Leilao> Leiloes { get; set; }

        static LeiloesDataContext() 
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LeiloesDataContext>());
        }
    }
}