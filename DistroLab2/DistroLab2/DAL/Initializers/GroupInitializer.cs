using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DistroLab2.Models;
using DistroLab2.DAL.Contexts;

namespace DistroLab2.DAL
{
    public class GroupInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GroupContext>
    {
        protected override void Seed(GroupContext context)
        {
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
