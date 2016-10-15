namespace DistroLab2.DAL.Contexts.GroupMigrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DistroLab2.DAL.Contexts.GroupContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DAL\Contexts\GroupMigrations";
        }

        protected override void Seed(DistroLab2.DAL.Contexts.GroupContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            Console.WriteLine("KUKEN i FITTAN");
            var groups = new List<Group>
            {
            new Group{GroupId=1,Name="grupp 1"},
            new Group{GroupId=2,Name="grupp 2"},
            new Group{GroupId=3,Name="grupp 3"},
            new Group{GroupId=4,Name="grupp 4"},
            new Group{GroupId=5,Name="grupp 5"},
            };

            groups.ForEach(g => context.Groups.Add(g));
            context.SaveChanges();
        }
    }
}
