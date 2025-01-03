using System;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;

namespace XmlLoginRegisterApp.Controllers
{
    public class AccountController : Controller
    {
        
        public ActionResult Home()
        {
            return View();
        }

        
        public ActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var xml = XDocument.Load(Server.MapPath("~/UserData.xml"));

            
            var user = xml.Descendants("User").FirstOrDefault(u =>
                u.Element("Username").Value == username &&
                u.Element("Password").Value == password);

            if (user != null)
            {
                
                return RedirectToAction("Index", "Operations");
            }

            
            ViewBag.Message = "Invalid username or password!";
            return View();
        }

        
        public ActionResult Register()
        {
            return View();
        }

        

        [HttpPost]
        public ActionResult Register(string username, string password, string confirmPassword)
        {
           

            if (password != confirmPassword)
            {
                ViewBag.Message = "Passwords do not match!";
                return View();
            }

            var filePath = Server.MapPath("~/UserData.xml");
            XDocument xml;

            if (System.IO.File.Exists(filePath))
            {
                xml = XDocument.Load(filePath);
            }
            else
            {
                xml = new XDocument(new XElement("Users"));
            }

           
            var existingUser = xml.Descendants("User").FirstOrDefault(u =>
                u.Element("Username").Value == username);

            if (existingUser != null)
            {
                ViewBag.Message = "Username already exists!";
                return View();
            }

            
            xml.Root.Add(new XElement("User",
                new XElement("Username", username),
                new XElement("Password", password)
            ));

            xml.Save(filePath);

            ViewBag.Message = "Registration successful! Please log in.";
            return RedirectToAction("Login");
        }
    }
}
