using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Account
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Drink { get; set; }
        public string Size { get; set; }
        public string Address { get; set; }
        public string Time { get; set; }
        public string OrderOption { get; set; }
        public int OrderNumber { get; set; }

        public Account()
        {
            OrderNumber = 0;
            Address = "";
        }
    } 
}