using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class ToDo
    {
         [Key]
         public int Id { get; set; }
        [Required (ErrorMessage = "Title is Required")]
        [StringLength(30)]
        public string Title { get; set; } = string.Empty;
        [DataType(DataType.MultilineText )]
        public string Details { get; set; }= string.Empty;
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        [Display(Name ="Status")]
        public bool isActive { get; set; } 
    }
}
