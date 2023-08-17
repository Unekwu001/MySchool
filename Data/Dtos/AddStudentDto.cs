using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class AddStudentDto
    {
        [Required]
        public string StudentName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
