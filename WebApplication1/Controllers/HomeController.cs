using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "SWEET SWEET COFFEE!!!!!";

            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult Order(string firstname, string lastname, string email)
        {
            Models.Account user = new Models.Account()
            {
                FirstName = firstname,
                LastName = lastname,
                Email = email
            };
            ViewBag.User = user;
            return View(user);
        }

        public ActionResult PickupOrDelivery(string firstname, string lastname, string email, string drink, string size, string orderoption)
        {
            Models.Account user = new Models.Account() { FirstName = firstname, LastName = lastname, Email = email, Drink = drink, Size = size, OrderOption = orderoption };
            user.OrderNumber++;
            if (user.OrderOption == "Pickup")
            {
                return View("Pickup", user);
            }
            else
            {
                return View("Delivery", user);
            }
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult ThankYou(Models.Account account)
        {
            ViewBag.Welcome = $"Welcome, {account.FirstName} {account.LastName}!!";
            return View(account);
        }

        [HttpPost]
        public ActionResult RegisterCheck(string firstname, string lastname, string email, string password, string verifypassword)
        {
            Regex emailRegex = new Regex(@"^[a-zA-Z0-9]{3,30}@[a-zA-Z0-9]{3,10}\.[a-zA-Z0-9]{2,3}$");
            bool matchEmailRegex = emailRegex.IsMatch(email);

            if (!matchEmailRegex)
            {
                ViewBag.EmailCheck = "Email not valid.<br />";
                return View("Registration");
            }
            if (verifypassword != password)
            {
                ViewBag.PasswordMatch = "Passwords do not match.<br />";
                return View("Registration");
            }
            Models.Account account = new Models.Account();
            account.FirstName = firstname;
            account.LastName = lastname;
            account.Email = email;
            account.Password = password;
            return RedirectToAction("ThankYou", account);
        }

        public ActionResult ConfirmDelivery(string firstname, string lastname, string email, string drink, string size, string address)
        {
            Models.Account user = new Models.Account() { FirstName = firstname, LastName = lastname, Email = email, Drink = drink, Size = size, Address = address };
            ViewBag.OrderReady = DateTime.Now.AddMinutes(20);
            return View("Confirmed", user);
        }

        public ActionResult ConfirmPickup(string firstname, string lastname, string email, string drink, string size, string pickuptime)
        {
            Models.Account user = new Models.Account() { FirstName = firstname, LastName = lastname, Email = email, Drink = drink, Size = size, Time = pickuptime };
            return View("Confirmed", user);
        }

    }
}