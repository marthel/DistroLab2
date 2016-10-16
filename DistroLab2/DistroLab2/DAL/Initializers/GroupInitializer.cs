using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DistroLab2.Models;
using DistroLab2.DAL.Contexts;
using System.Diagnostics;

namespace DistroLab2.DAL
{
   /* public class GroupInitializer : DropCreateDatabaseIfChanges<GroupContext>
    {
        protected override void Seed(GroupContext context)
        {
            Debug.WriteLine("KUKEN i FITTAN");
            var groups = new List<Group>
            {
            new Group{Name="grupp 1"},
            new Group{Name="grupp 2"},
            new Group{Name="grupp 3"},
            new Group{Name="grupp 4"},
            new Group{Name="grupp 5"},
            };

            groups.ForEach(g => context.Groups.Add(g));
            context.SaveChanges();
        }
    }*/
}
