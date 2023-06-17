using System.ComponentModel.DataAnnotations;

namespace ContactWebModels
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "State")]
        [Required(ErrorMessage = "State name required")]
        [StringLength(ContactManagerConstants.MAX_STATE_NAME_LENGTH)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Abberviation required")]
        [StringLength(ContactManagerConstants.MAX_STATE_ABBR_LENGTH)]
        public string Abbreviation { get; set; }

    }
}
