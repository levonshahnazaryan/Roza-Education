using Domain.Entities;

namespace Education.Models.Account
{
    public class AboutUsVM
    {
        public int AboutUsId { get; set; }
        public string UContent { get; set; }
        public AboutUs GetAboutUs { get; set; }
    }
}