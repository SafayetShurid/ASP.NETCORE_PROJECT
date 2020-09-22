using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; } 

        [Required(ErrorMessage ="Nam ta den vai")]
        
        public string Name { get; set; } 
        [Required(ErrorMessage = "Boyosh ti likhe felun")]
        [Range(18,200,ErrorMessage ="Valid boyosh diben please")]
        public int Age { get; set; } 

        [Required(ErrorMessage ="Apnar ki department nei vai?")]
        [DisplayName("Department")]
        public string Department { get; set; }

    }
}
