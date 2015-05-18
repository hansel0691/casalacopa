using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace casalacopa.com.Controllers
{
    public class HomeController : Controller
    {
        private decimal _price = 45;

        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Book(string name, string lastName, string email, long checkIn, long checkOut, string country, int rooms, int adults, int children, string notes)
        {
            var nights = (checkOut - checkIn) / (1000 * 60 * 60 * 24);
            var totalCost = nights * _price * rooms;
            var toClient = new MailMessage { From = new MailAddress("booking@benyhouse.com") };
            toClient.To.Add(new MailAddress(email));
            toClient.Subject = "La Copa: Confirmation Request";

            //llevar fecha a string para correo;
            var unixDate = new DateTime(1970, 1, 1); 
            var dateIn = unixDate.AddMilliseconds(checkIn).Date;
            var dateOut = unixDate.AddMilliseconds(checkOut).Date;

            var toAdmin = new MailMessage { From = new MailAddress("booking@benyhouse.com") };
            toAdmin.To.Add(new MailAddress("booking@benyhouse.com"));
            toAdmin.To.Add(new MailAddress("benync@yahoo.es"));
            toAdmin.Subject = "New Request from www.casalacopa.com";

            var toClientMsg = "<html style=\'padding:10px\'><body><style type=\'text/css\' media=\'screen\'>body{font-family: \'Helvetica Neue\', Helvetica, Arial, sans-serif;border: 1px solid #ddd;margin: auto;width: 550px;height: 600px;}" +
                "header{background-color: #2BA9B9;display: block;text-align: center;}header h1{color: #FFF;padding: 20px;font-size: 22px;margin: 0;font-weight: 400;letter-spacing: .9px;}section{margin-top: 20px;}article{margin-left: 20px;color: #555;}" +
                "i{color: #80A305;}a{color: #2a6496;text-decoration: none;}footer{margin: 30px 0 -20px -20px;background-color: #1C1C1C;padding: 5px;}</style><header><h1>Request Information</h1></header><article><section><i>Dear " + name + "</i><br>thank you so much for being interested in our house. Your request will be checked as soon as possible(usally less than 12 hours)." +
                "</section><section><h2>Personal Details</h2>Full Name: " + name + " " + lastName + "<br>Country: " + country + "</section><section><h2>Booking Details</h2>Check in: " + dateIn + "<br>Check out: " + dateOut + "<br>Nights: " + nights + "<br>Number of Rooms: " + rooms + "<br>Price per night: " + _price + "<br>" +
                "Total Cost: " + totalCost + "<br>Phone number: 53 45611700<br>Address: 55 St. #124 between 1st and 2nd Ave,Varadero,Matanzas, Cuba.<br>State: <i>Pendent to confirm.</i></section><footer>If you want to cancel this request just click on " +
                      "the following <a href=''>link</a> or send us a message to benync@yahoo.es <br>To see more pictures of La Copa and La Habana enter in <a href='www.facebook.com/benyhostel'>Facebook</a> and remember give us a <a href=''>like</a>.</footer></article></body></html>";

            toClient.Body = toClientMsg;
            toClient.IsBodyHtml = true;

            var toAdminMsg = "<html style=\'padding:10px\'><body><style type=\'text/css\' media=\'screen\'>body{font-family: \'Helvetica Neue\', Helvetica, Arial, sans-serif;border: 1px solid #ddd;margin: auto;width: 550px;height: 600px;}" +
                "header{background-color: #2BA9B9;display: block;text-align: center;}header h1{color: #FFF;padding: 20px;font-size: 22px;margin: 0;font-weight: 400;letter-spacing: .9px;}section{margin-top: 20px;}article{margin-left: 20px;color: #555;}" +
                "i{color: #80A305;}a{color: #2a6496;text-decoration: none;}footer{margin: 30px 0 -20px -20px;background-color: #1C1C1C;padding: 5px;}</style><header><h1>New request of booking has been done from La Copa</h1></header><article>" +
                "<section><h2>Personal Details</h2>Full Name: " + name + " " + lastName + "<br>Country: " + country + "</section><section><h2>Booking Details</h2>Check in: " + dateIn + "<br>Check out: " + dateOut + "<br>Nights: " + nights + "<br>Number of Rooms: " + rooms + "<br>Price per night: " + _price + "<br>" +
                "Total Cost: " + totalCost + "<br>Adults Number: " + adults + "<br>Children Number: " + children + "<br>Comments: " + (string.IsNullOrWhiteSpace(notes) ? "The Client didn't let a comment" : notes) + "<br>State: <i>Pendent to confirm.</i></section></article></body></html>";

            toAdmin.Body = toAdminMsg;
            toAdmin.IsBodyHtml = true;

            var smtp = new SmtpClient("smtp.1and1.com") { Credentials = new NetworkCredential("booking@benyhouse.com", "Arenita1"), Port = 25 };
            try
            {
                smtp.Send(toClient);
                //smtp.Send(toAdmin);
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }


            return Json(new {success = true});
        }
    }
}
