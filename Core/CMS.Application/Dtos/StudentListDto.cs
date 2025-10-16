using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Dtos;

public class StudentListDto
{
    public Guid Id { get; set; }
    public string NationalId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public char Status { get; set; }
}