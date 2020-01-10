using System.ComponentModel.DataAnnotations;

namespace ContactWeb.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "Name of State is required")]
        [StringLength(ContactWebConstants.MaxStateNameLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = "State Abbreviation is required")]
        [StringLength(ContactWebConstants.MaxStateAbbrLength)]
        public string Abbreviation { get; set; }
    }
}