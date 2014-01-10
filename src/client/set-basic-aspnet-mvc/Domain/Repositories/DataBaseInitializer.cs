using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.IO;

namespace set_basic_aspnet_mvc.Domain.Repositories
{
    public class DefaultInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            base.Seed(context);
            context.SaveChanges();
        }
    }
}

