using Domain.Entities;
using System.Collections.Generic;

namespace Education.Models.Account
{
    public class AboutCollageVM
    {
        public int AboutCollageId { get; set; }
        public string UContent { get; set; }
        public AboutCollage GetAboutCollage { get; set; }
        public IEnumerable<AboutFiles> GetAboutFiles { get; set; }
    }
}