using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EXercises.Models;

namespace EXercises.ViewModels
{
    public class NewCustomerViewModels
    {
        public IEnumerable<MembershipType> MembershipType { get; set; }
        public Customers Customer { get; set; }
    }
}