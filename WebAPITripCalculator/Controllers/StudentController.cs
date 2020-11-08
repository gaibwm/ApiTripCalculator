using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TripCalculator;
using WebAPITripCalculator.DAL;
using log4net;

namespace WebAPITripCalculator.api
{
    [RoutePrefix("/api/Student")]
    public class StudentController : ApiController
    {
        private TripCalculatorContext db = new TripCalculatorContext();
        ILog log = log4net.LogManager.GetLogger(typeof(StudentController));

        [ResponseType(typeof(Student))]
        [HttpGet]
        // GET: api/Student
        public IQueryable<Student> GetStudents()
        {
            log.Debug("GetStudents");
            return db.Students;
        }

        //post expense
        // POST: api/Student
        [ResponseType(typeof(Student))]
        public IQueryable<Student>  PostStudent(Expense exp) 
        {
            log.Debug("Post expense");
            exp.ID = (db.Expenses.Count() + 1).ToString();
            //just make sure we get new ID aasuming no one delete record in db
            exp.Amount = Math.Round(exp.Amount, 2);
            double d = Math.Round(exp.Amount / 3);
            foreach(Student s in db.Students)
            {
                if (s.ID == exp.StudentID)
                {
                    s.TTpay += exp.Amount;
                    s.Balance += Math.Round((d*2), 2);
                }
                else
                {
                    s.Balance -= d;
                }
            }

            db.Expenses.Add(exp);

            db.SaveChanges();

            return db.Students;
        }

        //final calculation
        // GET: api/Student/5
        [ResponseType(typeof(string))]
        public List<string> GetStudent(string id)
        {
            log.Debug("GetStudent");
            List<string> sFinal = new List<string>();
            foreach (Student s in db.Students)
                sFinal.Add(s.Name + ((s.Balance > 0) ? " receive: $" + s.Balance : " pay: $" + Math.Abs(s.Balance)));

            return sFinal;
        }


        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(string id)
        {
            return db.Students.Count(e => e.ID == id) > 0;
        }
    }
}