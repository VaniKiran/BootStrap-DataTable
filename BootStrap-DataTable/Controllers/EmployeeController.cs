using BootStrap_DataTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
namespace BootStrap_DataTable.Controllers
{
    public class EmployeeController : Controller
    {
        private AppContext db = new AppContext();
        // GET: Employee
        public ActionResult Index()
        {
            return View(db.Employees.AsEnumerable().Select(e => new EmployeeView { Id = e.Id, FirstName = e.FirstName, City = e.City, Email = e.Email }));
        }

        public string GetEmployees(string sEcho, string sSearch, int iDisplayLength, int iDisplayStart, int iColumns, int iSortingCols, string sColumns, string sColSort, string sSortOrder)
        {
            var echo = int.Parse(sEcho);
            var displayLength = iDisplayLength;
            var displayStart = iDisplayStart;
            var itemsToSkip = displayStart == 0 ? 0 : displayStart;

            var employees = db.Employees.Select(s => new EmployeeView()
            {
                Id = s.Id,
                FirstName = s.FirstName,
                City = s.City,
                Email = s.Email
            });
            employees = _buildQuery(employees, sSearch, sColSort, sSortOrder);

            var totalRecords = employees.Count();
            if (displayLength == -1)
            {
                displayLength = totalRecords;
            }

            //Sort the list with passed sort expression and take only required data
            employees = employees.Skip(itemsToSkip).Take(displayLength);

            EmployeeViewList employeesList = new EmployeeViewList();
            if (employees != null)
            {
                employeesList.sEcho = echo;
                employeesList.recordsTotal = totalRecords;
                employeesList.recordsFiltered = employees.Count();
                employeesList.iTotalRecords = totalRecords;
                employeesList.iTotalDisplayRecords = totalRecords;
                employeesList.aaData = employees.ToList();
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(employeesList);
        }
        private static IQueryable<T> _buildQuery<T>(IQueryable<T> qry, string sSearch, string sColSort, string sSortOrder)
        {
            if (!string.IsNullOrEmpty(sSearch))
            {
                var searchParams = sSearch.Split('|');
                foreach (var searchParam in searchParams)
                {
                    var paramParts = searchParam.Split(':');
                    DateTime dtValue;
                    //Search the list with passed search expression
                    if (DateTime.TryParse(paramParts[1], out dtValue))
                    {
                        qry = qry.Where(paramParts[0] + ".CompareTo(@0) > 0", dtValue);
                        qry = qry.Where(paramParts[0] + ".CompareTo(@0) < 0", dtValue.AddDays(1));
                    }
                    else
                        qry = qry.Where(paramParts[0] + ".Contains(@0)", paramParts[1]);
                }
            }

            if (!string.IsNullOrEmpty(sColSort))
            {
                //Sort the list with passed sort expression
                qry = qry.OrderBy(sColSort + " " + sSortOrder);
            }

            return qry;
        }
    }
}