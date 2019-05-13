using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BoxBuster.Models;

namespace BoxBuster.ViewModels
{
    public class NewCustomerViewModel
    {
        //iterate over membershiptypes
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        //re-use existing cstomr domain object. 
        public Customer Customer { get; set; }
    }
}