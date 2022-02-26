using Domain.Services;
using Education.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education.Components
{
    public class BestEducations : ViewComponent
    {
        private IEduRepasitory _eduRepository;
        public BestEducations(IEduRepasitory eduRepository)
        {
            _eduRepository = eduRepository;
        }

        public IViewComponentResult Invoke()
        {
            return View(new EducationsVM()
            {
                GetUIBestEducation = _eduRepository.GetUIBestEducation()
            });
        }
    }
}