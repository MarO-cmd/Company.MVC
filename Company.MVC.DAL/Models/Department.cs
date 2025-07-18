﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.MVC.DAL.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is Required!")]
        public string Name { get; set; }
        public string Code { get; set; }

        public DateTime DateOfCreation { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}
