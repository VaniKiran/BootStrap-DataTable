using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BootStrap_DataTable.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
    }
    public class EmployeeView
    {
        public virtual Guid Id { get; set; }
        public string FirstName { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
    }
    public class EmployeeViewList
    {
        public List<EmployeeView> aaData
        {
            get;
            set;
        }

        public int sEcho { set; get; }
        public int recordsTotal { set; get; }
        public int recordsFiltered { set; get; }
        public int iTotalRecords { set; get; }
        public int iTotalDisplayRecords { set; get; }
    }
}