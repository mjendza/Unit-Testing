using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.DataAccess
{
    public class SQLDataBaseEFContext : DbContext
    {
        public SQLDataBaseEFContext()
            : base(@"name=TrainingDB")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SQLDataBaseEFContext>());
            //Database.SetInitializer<SQLDataBaseEFContext>(new CreateDatabaseIfNotExists<SQLDataBaseEFContext>());

        }
        public virtual IDbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }

    }
}
