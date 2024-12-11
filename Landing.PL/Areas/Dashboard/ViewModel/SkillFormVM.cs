using System.ComponentModel.DataAnnotations;

namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class SkillFormVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Skill Name is Required..!")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Skill Value is Required..!")]

        public int Value { get; set; }
        public bool IsDeleted { get; set; }

    }
}
