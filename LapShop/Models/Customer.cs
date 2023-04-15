﻿using System.ComponentModel.DataAnnotations.Schema;

namespace LapShop.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public User User { get; set; }
    }
}
