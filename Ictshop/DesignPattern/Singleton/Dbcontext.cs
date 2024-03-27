using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Ictshop.Models;

namespace Ictshop.DesignPattern.Singleton
{
    public class Dbcontext
    {
        private static Lazy<Dbcontext> instance = new Lazy<Dbcontext>(() => new Dbcontext());


        private readonly Model1 dbContext;

        private Dbcontext()
        {
            dbContext = new Model1();
        }

        public static Dbcontext Instance => instance.Value;
        public Model1 GetDbContext()
        {
            return dbContext;
        }

    }
}