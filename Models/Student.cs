using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVC.Models
{
    public class Student
    {
       
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
      
        public string? Class { get; set; }

        [ForeignKey("SubjectId")]
        [Display(Name="Subject")]

        public int TeacherId { get; set; }

        public virtual Teacher? Teacher { get; set; }

    }
}