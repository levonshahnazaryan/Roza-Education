using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Domain.Entities;
using Education.Models.Account;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace Education.Controllers
{
    public partial class AccountController
    {
        [HttpGet]
        public object GetUsefulLinks(DataSourceLoadOptions loadOptions)
        {
            var sortinfo = new SortingInfo[]
            {
                new SortingInfo() {Desc = false, Selector = "Sorting"},
            };
            loadOptions.Sort = sortinfo;
            return DataSourceLoader.Load(_eduRepository.GetUsefulLinks(), loadOptions);
        }

        [HttpPost]
        public IActionResult PostUsefulLinks(string values)
        {
            UsefulLinks how = new();
            JsonConvert.PopulateObject(values, how);
            var error = _eduRepository.AddEntity(how);
            if (!error)
                return BadRequest();
            return Ok();
        }

        [HttpPut]
        public IActionResult PutUsefulLinks(int key, string values)
        {
            bool error;
            if (values.IndexOf("Sorting") > -1)
            {
                UsefulLinks how = new();
                JsonConvert.PopulateObject(values, how);
                error = _eduRepository.SortUsefulLinks(key, values);
            }
            else
                error = _eduRepository.EditEntity<UsefulLinks>(values, key);
            if (!error)
                return BadRequest();
            return Ok();
        }

        [HttpDelete]
        public void DeleteUsefulLinks(int key)
        {
            _eduRepository.DeleteEntity<UsefulLinks>(key);
        }

        [HttpPost]
        [Route("[controller]/UsefulLinksImageUp/{usefulLinksId}")]
        public ActionResult UsefulLinksImageUp(int usefulLinksId)
        {
            var myFile = Request.Form.Files["UsefulLinksImage"];
            var cont = $"{_webHostEnvironment.WebRootPath}/Resources/UsefulLinks";
            if (!Directory.Exists(cont))
                Directory.CreateDirectory(cont);
            var idCont = $"{_webHostEnvironment.WebRootPath}/Resources/UsefulLinks/" + usefulLinksId;
            if (!Directory.Exists(idCont))
                Directory.CreateDirectory(idCont);
            var path = $"{_webHostEnvironment.WebRootPath}/Resources/UsefulLinks/" + usefulLinksId + "/" + myFile.FileName;
            using (var fileStream = System.IO.File.Create(path))
            {
                myFile.CopyTo(fileStream);
                _eduRepository.EditUsefulLinksImgUrl(usefulLinksId, myFile.FileName);
            }
            return new EmptyResult();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Route("[controller]/UpdateAboutUsContent")]
        public IActionResult UpdateAboutUsContent([FromBody] AboutUsVM data)
        {
            var model = new AboutUs
            {
                AboutUsId = data.AboutUsId,
                UContent = data.UContent
            };
            var res = _eduRepository.EditAboutUsContent(model);
            return Json(res);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Route("[controller]/UpdateAboutCollageContent")]
        public IActionResult UpdateAboutCollageContent([FromBody] AboutCollageVM data)
        {
            var model = new AboutCollage
            {
                AboutCollageId = data.AboutCollageId,
                UContent = data.UContent
            };
            var res = _eduRepository.EditAboutCollageContent(model);
            return Json(res);
        }

        [HttpGet]
        public object GetEducation(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_eduRepository.GetEducation(), loadOptions);
        }

        [HttpGet]
        public object GetEducationParent(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_eduRepository.GetEducationParent(), loadOptions);
        }

        [HttpPost]
        public IActionResult PostEducation(string values)
        {
            values = values.Replace("null", "0");
            Educations how = new();
            JsonConvert.PopulateObject(values, how);
            var error = _eduRepository.AddEntity(how);
            if (!error)
                return BadRequest();
            return Ok();
        }

        [HttpPut]
        public IActionResult PutEducation(int key, string values)
        {
            bool error = _eduRepository.EditEntity<Educations>(values, key);
            if (!error)
                return BadRequest();
            return Ok();
        }

        [HttpDelete]
        public void DeleteEducation(int key)
        {
            _eduRepository.DeleteEntity<Educations>(key);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Route("[controller]/UpdateEducationsContent")]
        public IActionResult UpdateEducationsContent([FromBody] EducationVM data)
        {
            var model = new Educations
            {
                EducationsId = data.EducationsId,
                UContent = data.UContent
            };
            var res = _eduRepository.EditEducationsContent(model);
            return Json(res);
        }

        [HttpGet]
        public object GetEducationsFile(int educationsId, DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_eduRepository.GetEducationsFile(educationsId), loadOptions);
        }

        [HttpDelete]
        public void DeleteEducationsFile(int key)
        {
            _eduRepository.DeleteEntity<EducationsFile>(key);
        }

        [HttpPost]
        [Route("[controller]/UploadEducationFile/{educationsId}")]
        public ActionResult UploadEducationFile(int educationsId)
        {
            var myFile = Request.Form.Files["EduUpFiles"];
            var cont = $"{_webHostEnvironment.WebRootPath}/Resources/Education";
            if (!Directory.Exists(cont))
                Directory.CreateDirectory(cont);
            var idCont = $"{_webHostEnvironment.WebRootPath}/Resources/Education/" + educationsId;
            if (!Directory.Exists(idCont))
                Directory.CreateDirectory(idCont);
            var path = $"{_webHostEnvironment.WebRootPath}/Resources/Education/" + educationsId + "/" + myFile.FileName;
            using (var fileStream = System.IO.File.Create(path))
            {
                myFile.CopyTo(fileStream);
                EducationsFile file = new()
                {
                    EducationsId = educationsId,
                    FileName = myFile.FileName
                };
                _eduRepository.AddEntity(file);
            }
            return new EmptyResult();
        }

        [HttpGet]
        public object GetAboutFile(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_eduRepository.GetAboutFiles(), loadOptions);
        }

        [HttpDelete]
        public void DeleteAboutFile(int key)
        {
            _eduRepository.DeleteEntity<AboutFiles>(key);
        }

        [HttpPost]
        [Route("[controller]/UploadAboutFile")]
        public ActionResult UploadAboutFile()
        {
            var myFile = Request.Form.Files["AboutUpFiles"];
            var cont = $"{_webHostEnvironment.WebRootPath}/Resources/AboutFiles";
            if (!Directory.Exists(cont))
                Directory.CreateDirectory(cont);
            var path = $"{_webHostEnvironment.WebRootPath}/Resources/AboutFiles/" + myFile.FileName;
            using (var fileStream = System.IO.File.Create(path))
            {
                myFile.CopyTo(fileStream);
                AboutFiles file = new()
                {
                    FileName = myFile.FileName
                };
                _eduRepository.AddEntity(file);
            }
            return new EmptyResult();
        }

        [HttpGet]
        public object GetVideoEducations(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_eduRepository.GetVideoEducation(), loadOptions);
        }

        [HttpDelete]
        public void DeleteVideoEducations(int key)
        {
            _eduRepository.DeleteEntity<VideoEducation>(key);
        }

        [HttpPost]
        [Route("[controller]/UploadVideoEducations")]
        public ActionResult UploadVideoEducations()
        {
            var myFile = Request.Form.Files["VideoEduUpFiles"];
            var cont = $"{_webHostEnvironment.WebRootPath}/Resources/VideoEducation";
            if (!Directory.Exists(cont))
                Directory.CreateDirectory(cont);
            var path = $"{_webHostEnvironment.WebRootPath}/Resources/VideoEducation/" + myFile.FileName;
            using (var fileStream = System.IO.File.Create(path))
            {
                myFile.CopyTo(fileStream);
                VideoEducation file = new()
                {
                    FileName = myFile.FileName
                };
                _eduRepository.AddEntity(file);
            }
            return new EmptyResult();
        }
    }
}