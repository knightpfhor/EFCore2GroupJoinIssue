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
        public int OtherParentId { get; set; }
        public OtherParent OtherParent { get; set; }
    }
}
