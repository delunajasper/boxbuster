using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoxBuster.Dtos
{
    public class MembershipTypeDto
    {
        //two properties only from MembershipType.
        public byte Id { get; set; }
        public string Name { get; set; }
    }
}