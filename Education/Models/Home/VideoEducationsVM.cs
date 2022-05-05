using Domain.Entities;
using System.Collections.Generic;

namespace Education.Models.Home
{
    public class VideoEducationsVM
    {
        public IEnumerable<VideoEducation> GetVideoEducation { get; set; }
    }
}