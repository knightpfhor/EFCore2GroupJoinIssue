using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace EFCoreGroupJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<GroupJoinContext>();

            dbContextBuilder.UseSqlServer("Server=.;Initial Catalog=EFCoreGroupJoin;Integrated Security=true;");

            using (var context = new GroupJoinContext(dbContextBuilder.Options))
            {
                bool ensureOneParentHasNoChildren = false;

                if (args.Length > 0 && args[0] == "-d")
                {
                    ensureOneParentHasNoChildren = true;
                }

                InitialiseData(context, ensureOneParentHasNoChildren);

                var results = context.Parents.GroupJoin(
                    context.Children.Select(x => new
                    {
                        ParentId = x.ParentId,
                        OtherParent = x.OtherParent.Name
                    }),
                    p => p.Id,
                    c => c.ParentId,
                    (parent, child) => new
                    {
                        ParentId = parent.Id,
                        ParentName = parent.Name,
                        Children = child.Select(x => x.OtherParent)
                    });

                foreach (var parent in results)
                {
                    Console.WriteLine(parent.ParentName);

                    foreach (var parentChild in parent.Children)
                    {
                        Console.Write("-");
                        Console.WriteLine(parentChild);
                    }
                }
            }

            Console.WriteLine("Press a key");
            Console.ReadKey();
        }

        private static void InitialiseData(GroupJoinContext context, bool ensureOneParentHasNoChildren)
        {
            CheckAndAddParent(context, 1);
            CheckAndAddParent(context, 2);
            CheckAndAddParent(context, 3);

            CheckAndAddOtherParent(context, 1);
            CheckAndAddOtherParent(context, 2);


            CheckAndAddChild(context, 1, 1);
            CheckAndAddChild(context, 1, 2);

            CheckAndAddChild(context, 2, 1);
            CheckAndAddChild(context, 2, 2);

            if (ensureOneParentHasNoChildren)
            {
                foreach (var child in context.Children.Where(x => x.ParentId == 3).ToArray())
                {
                    context.Children.Remove(child);
                }

                context.SaveChanges();
            }
            else
            {
                CheckAndAddChild(context, 3, 2);
            }
        }

        private static void CheckAndAddParent(GroupJoinContext context, int id)
        {
            var parent = context.Parents.SingleOrDefault(x => x.Id == id);

            if (parent == null)
            {
                parent = new Parent
                {
                    Name = "Parent" + id
                };

                context.Parents.Add(parent);

                context.SaveChanges();
            }
        }

        private static void CheckAndAddOtherParent(GroupJoinContext context, int id)
        {
            var otherParent = context.OtherParents.SingleOrDefault(x => x.Id == id);

            if (otherParent == null)
            {
                otherParent = new OtherParent()
                {
                    Name = "Other Parent" + id
                };

                context.OtherParents.Add(otherParent);

                context.SaveChanges();
            }
        }

        private static void CheckAndAddChild(GroupJoinContext context, int parentId, int otherParentId)
        {
            var child = context.Children.SingleOrDefault(x => x.ParentId == parentId && x.OtherParentId == otherParentId);

            if (child == null)
            {
                child = new Child
                {
                    ParentId = parentId,
                    OtherParentId = otherParentId
                };

                context.Children.Add(child);

                context.SaveChanges();
            }
        }

        private static void DeleteOneChild(GroupJoinContext context)
        {
            
        }
    }
}
