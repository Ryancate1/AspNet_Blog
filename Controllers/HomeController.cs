﻿using rcate_blog.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static rcate_blog.ApplicationSignInManager;

namespace rcate_blog.Controllers
{
    [RequireHttps]
    public class HomeController : Universal
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Personal Site of Ryan Cate";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Page";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var body = "<p>Email From: <bold>{0}</bold> ({1})</p><p> Message:</p><p>{2}</p> ";
                    var from = "myBlog<emaple@gmail.com>";

                    var email = new MailMessage(from,
                    ConfigurationManager.AppSettings["emailto"])
                    {
                        Subject = "Blog Contact Email",
                        Body = string.Format(body, model.FromName, model.FromEmail,
                        model.Body),
                        IsBodyHtml = true
                    };
                    var svc = new PersonalEmail(); 
                    await svc.SendAsync(email);
                    return View(new EmailModel()); 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.FromResult(0);
                }
            }
            return View(model);
        }
    }
}