using Domain.Entities;

namespace Education.Models.Account
{
    public class EducationVM
    {
        public int EducationsId { get; set; }
        public string UContent { get; set; }
        public Educations FindEducation { get; set; }
    }
}