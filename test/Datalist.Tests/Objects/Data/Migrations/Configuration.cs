using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Datalist.Tests.Objects.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Datalist.Tests.Data";
            MigrationsDirectory = "Objects\\Data\\Migrations";
        }

        protected override void Seed(Context context)
        {
            for (Int32 index = 0; index < 100; index++)
            {
                String id = index.ToString();
                if (!context.TestModels.Any(model => model.Id == id))
                {
                    context.TestRelationModels.Add(new TestRelationModel { Id = id, Value = id + "." + id });
                    context.TestRelationModels.Add(new TestRelationModel { Id = "-" + id, Value = "-" + id + "." + id });
                    context.TestModels.Add(new TestModel
                    {
                        Id = id,
                        ParentId = id,
                        Sum = index + index,
                        Number = (index % 2 == 0) ? index : -index,
                        NullableString = (index % 3 == 0) ? id : null,
                        CreationDate = DateTime.Now.Date.AddDays(index),
                        FirstRelationModelId = (index % 2 == 0) ? id : null,
                        SecondRelationModelId = (index % 5 == 0) ? "-" + id : null
                    });
                }
            }

            context.SaveChanges();
        }
    }
}
