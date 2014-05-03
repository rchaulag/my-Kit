using JobBoard.Database;
using JobBoard.DataModels;
using JobBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JobBoard.Controllers
{
    public class JobBoardController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();
        JobBoardVM viewmodel = new JobBoardVM();

        public IHttpActionResult Get()
        {
            try
            {
                viewmodel.Companies = context.Companies.Include("Jobs").ToList();
                return Ok(viewmodel);
            }
            catch (Exception ex)
            {
                 return InternalServerError(ex);
            }
        }
        //for single item 
        public IHttpActionResult Get(int id)
        {
            Job Jobs = context.Jobs.Find(id);
            return Ok(Jobs);
        }

        // POST api/<controller>
        
        public IHttpActionResult Post([FromBody]Job newJob)
        {
            try
            {
                viewmodel.Jobs.Add(newJob);
                context.SaveChanges();
                return Created("api/JobBoard" + newJob.Id, newJob);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        public IHttpActionResult Put(int id, [FromBody]Job JObupdated)
        {
            try
            {
                Job Jobupdating = new Job();
                Jobupdating.Id = JObupdated.Id;
                Jobupdating.Salary = Jobupdating.Salary;
                Jobupdating.Title = Jobupdating.Title;
                context.SaveChanges();
                return Ok(JObupdated);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }



        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                Job JobToRemove = new Job();
                JobToRemove = context.Jobs.Find(id);
                context.Jobs.Remove(JobToRemove);
                return Ok();
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);

            }
        }
    }
}