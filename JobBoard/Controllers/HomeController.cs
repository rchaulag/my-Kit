// WEb Api is a HTTP service. The protocal in wuestion is Http. We are trying to expose data or functionality over the Http protocal. Typically our web APi are designed to achieve broad reach. That means we are trying to reach many diffent types of clients as we possibly can. These clients could be browsers, mobile devices, phones tablets, or they can even be more extic hardware.ALl of these difenet types of clients have in common is that they all can speak HTTP. So, building WEb APi gives us broad reach. we are trying to use HTTP as an application level protocal while we are trying to build web APi. Web service is unlike web api, where web service use HTTP mostly as a transport to move around messages, and actions are encoded somehow in those message. 
//WEb-APi is for reaching more clients. There are a lot more web API's publicly on the internet. Facebook web APi, google web APi, even the enterprises are using web API. There are more devices up there. 
//with the clouds we have unprecedented access to scalable infrastructure. 




using JobBoard.Database;
using JobBoard.DataModels;
using JobBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobBoard.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        JobBoardVM viewmodel = new JobBoardVM();
        
        public ActionResult Index()
        {
            //viewmodel.Jobs = context.Jobs.ToList();==> not required for eager loading
            //this is called eager loading include("Jobs") is going to map every job with
            //the related company
         
            viewmodel.Companies = context.Companies.Include("Jobs").ToList();
            
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Index(Job newjob)
        {
            context.Jobs.Add(newjob); 
            context.SaveChanges();
            viewmodel.Companies = context.Companies.Include("Jobs").ToList();
            return View(viewmodel);
        }
        
        public ActionResult Delete(Job id)
        {
            Job JobToRemove = context.Jobs.Find(id);
           context.Jobs.Remove(JobToRemove);
           context.SaveChanges();
           return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            Job JobUpdating = new Job();
            JobUpdating = context.Jobs.Find(id);
            return View(JobUpdating);
        }
        
        [HttpPost]
        public ActionResult Update( int id, Job Jobtoupdate)
        {
            Job JobUpdating = new Job();
            JobUpdating = context.Jobs.Find(id);
            JobUpdating.Id = Jobtoupdate.Id;
            JobUpdating.Salary = Jobtoupdate.Salary;
            JobUpdating.Title = Jobtoupdate.Title;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

//web APi is a fully suported and extensible framework for building HTTP based endpoints- Built on top of ASP.net (Mostly asp.net routing).Released with ASP.net MVC-4 - we can use alone, with MVc or webforms. Also includes a new Http client. Most of the client side HTTP programming model has been built in to System.net and server-side programming model(At least when we are talking about services) has been handled by WCF. 