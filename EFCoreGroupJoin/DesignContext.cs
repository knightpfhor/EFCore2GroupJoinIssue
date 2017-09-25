using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCoreGroupJoin
{
    public class DesignContext : IDesignTimeDbContextFactory<GroupJoinContext>
    {
        public GroupJoinContext CreateDbContext(string[] args)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<GroupJoinContext>();

            dbContextBuilder.UseSqlServer("Server=.;Initial Catalog=EFCoreGroupJoin;Integrated Security=true;");

            return new GroupJoinContext(dbContextBuilder.Options);
        }
    }
}
