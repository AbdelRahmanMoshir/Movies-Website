﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace EXercises.Models
{
    public class Customers
    {
        [Required(ErrorMessage = "Please Enter Your Name")]
        [StringLength(255)]
        public string Name { get; set; }

        public int  Id { get; set; }

        public bool IsSubscribedToNewLetter { get; set; }

        public MembershipType MembershipType { get; set; }
        [Display(Name ="Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Min18YearIfAMenmber]
        public DateTime? Birthdate { get; set; }
    }
}