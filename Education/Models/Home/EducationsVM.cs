using Domain.Entities;
using System.Collections.Generic;

namespace Education.Models.Home
{
    public class EducationsVM
    {
        public IEnumerable<Educations> GetUIEducation { get; set; }
        public Educations FindUIEducation { get; set; }
        public IEnumerable<Educations> GetUIBestEducation { get; set; }
        public IEnumerable<EducationsFile> GetEducationsFile { get; set; }
    }
}