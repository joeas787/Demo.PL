using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.DataTransferObject;

public class DepartmentRequest
{
    [Required(ErrorMessage ="name ??")]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Code { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
}
