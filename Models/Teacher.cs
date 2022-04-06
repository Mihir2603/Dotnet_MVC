
using System;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Teacher
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? Teacher_Name { get; set; }

        public string? subject { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime JoiningDate { get; set; }
    }
}