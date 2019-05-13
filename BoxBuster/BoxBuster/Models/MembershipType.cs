using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace BoxBuster.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }


        [Required]
        public string Name { get; set; }

        public short JoinFee { get; set; }
        public byte Duration { get; set; }
        public byte Discount { get; set; }


    }
}