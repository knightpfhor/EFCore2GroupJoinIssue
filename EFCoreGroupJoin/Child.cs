using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreGroupJoin
{
    public class Child
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public Parent Parent { get; set; }
        public string Name { get; set; }
    }
}
