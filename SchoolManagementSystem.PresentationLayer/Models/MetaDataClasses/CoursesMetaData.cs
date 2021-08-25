using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.PresentationLayer.Models
{
    public class CoursesMetaData
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [Range(1,8)]
        public Nullable<int> Credits { get; set; }
    }

    [MetadataType(typeof(CoursesMetaData))]
    public partial class Course { }
}