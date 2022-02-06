using Domain.Entities;
using System.Collections.Generic;

namespace Education.Models.Home
{
    public class IndexVM
    {
        public IEnumerable<UsefulLinks> GetUIUsefulLinks { get; set; }
        public AboutUs GetAboutUs { get; set; }
    }
}