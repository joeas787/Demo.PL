using Demo.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.DataTransferObject;

public class EmployeeResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    [DataType(DataType.Currency)]
    public decimal Salary { get; set; }

      [Display(Name = "Is Active")]
       public bool IsActive { get; set; }

    public string Gender { get; set; }


    public string Email { get; set; }
    [Display(Name = "Employee Type")]
    public string EmployeeType { get; set; }
    public string? Department { get; set; }
}
