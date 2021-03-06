using Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public class EduRepasitory : IEduRepasitory
    {
        private EduDBContext _dbContext;
        public EduRepasitory()
        {
            _dbContext = new EduDBContext();
        }

        public IEnumerable<UsefulLinks> GetUsefulLinks()
        {
            return _dbContext.UsefulLinks.AsEnumerable().ToList();
        }
        public UsefulLinks GetUsefulLinks(int usefulLinksId)
        {
            return _dbContext.UsefulLinks.Find(usefulLinksId);
        }
        public AboutUs GetAboutUs()
        {
            return _dbContext.AboutUs.FirstOrDefault();
        }
        public AboutCollage GetAboutCollage()
        {
            return _dbContext.AboutCollage.FirstOrDefault();
        }
        public IEnumerable<AboutFiles> GetAboutFiles()
        {
            return _dbContext.AboutFiles.AsEnumerable();
        }
        public IEnumerable<Educations> GetEducation()
        {
            return _dbContext.Educations.AsEnumerable();
        }
        public IEnumerable<Educations> GetEducationParent()
        {
            return _dbContext.Educations.Where(m => m.ParentId == 0).AsEnumerable();
        }
        public Educations FindEducation(int educationsId)
        {
            return _dbContext.Educations.Find(educationsId);
        }
        public IEnumerable<EducationsFile> GetEducationsFile(int educationsId)
        {
            return _dbContext.EducationsFile.Where(m => m.EducationsId == educationsId).AsEnumerable();
        }
        public IEnumerable<VideoEducation> GetVideoEducation()
        {
            return _dbContext.VideoEducation.AsEnumerable();
        }
        public bool AddEntity<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                _dbContext.Add(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditEntity<TEntity>(string values, params object[] keys) where TEntity : class
        {
            try
            {
                var entityForUpd = (TEntity)_dbContext.Find(typeof(TEntity), keys);
                JsonConvert.PopulateObject(values, entityForUpd);
                _dbContext.Update(entityForUpd);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditUsefulLinksImgUrl(int usefulLinksId, string imgUrl)
        {
            try
            {
                var item = _dbContext.UsefulLinks.Find(usefulLinksId);
                if (item != null)
                {
                    if (!string.IsNullOrEmpty(imgUrl))
                    {
                        item.Img = imgUrl;
                        _dbContext.Update(item);
                        _dbContext.SaveChanges();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditAboutUsContent(AboutUs data)
        {
            try
            {
                var item = _dbContext.AboutUs.Where(ro => ro.AboutUsId == data.AboutUsId).SingleOrDefault();
                if (item != null)
                {
                    item.UContent = data.UContent;
                    _dbContext.Update(item);
                }
                else
                {
                    _dbContext.Add(data);
                }
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditAboutCollageContent(AboutCollage data)
        {
            try
            {
                var item = _dbContext.AboutCollage.Where(ro => ro.AboutCollageId == data.AboutCollageId).SingleOrDefault();
                if (item != null)
                {
                    item.UContent = data.UContent;
                    _dbContext.Update(item);
                }
                else
                {
                    _dbContext.Add(data);
                }
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditEducationsContent(Educations data)
        {
            try
            {
                var item = _dbContext.Educations.Where(ro => ro.EducationsId == data.EducationsId).SingleOrDefault();
                if (item != null)
                {
                    item.UContent = data.UContent;
                    _dbContext.Update(item);
                }
                else
                {
                    _dbContext.Add(data);
                }
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteEntity<TEntity>(params object[] keys) where TEntity : class
        {
            try
            {
                var entityForDel = (TEntity)_dbContext.Find(typeof(TEntity), keys);
                _dbContext.Remove(entityForDel);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SortUsefulLinks(int key, string values)
        {
            try
            {
                int r = 1;
                var sortedTasks = _dbContext.UsefulLinks.ToList();
                var task = sortedTasks.Where(m => m.UsefulLinksId == key).First();
                var oldOrderIndex = task.Sorting;
                JsonConvert.PopulateObject(values, task);
                if (oldOrderIndex != task.Sorting)
                {
                    if (oldOrderIndex < task.Sorting)
                    {
                        var taskList = sortedTasks.Where(m => m.UsefulLinksId != task.UsefulLinksId && m.Sorting >= oldOrderIndex && m.Sorting <= task.Sorting).OrderBy(t => t.Sorting);
                        for (var i = 0; i < taskList.Count(); i++)
                        {
                            taskList.ElementAt(i).Sorting--;
                        }
                    }
                    else if (oldOrderIndex > task.Sorting)
                    {
                        var taskList = sortedTasks.Where(m => m.UsefulLinksId != task.UsefulLinksId && m.Sorting >= task.Sorting && m.Sorting <= oldOrderIndex).OrderBy(t => t.Sorting);
                        for (var i = 0; i < taskList.Count(); i++)
                        {
                            taskList.ElementAt(i).Sorting++;
                        }
                    }
                }
                foreach (var item in _dbContext.UsefulLinks.ToList().OrderBy(m => m.Sorting))
                {
                    var it = _dbContext.UsefulLinks.Find(item.UsefulLinksId);
                    it.Sorting = r++;
                    _dbContext.Update(it);
                }
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<UsefulLinks> GetUIUsefulLinks()
        {
            return _dbContext.UsefulLinks.Where(m => m.State).AsEnumerable().ToList();
        }
        public IEnumerable<Educations> GetUIEducation()
        {
            return _dbContext.Educations.Where(m => m.State).AsEnumerable();
        }
        public Educations FindUIEducation(int educationsId)
        {
            if (educationsId == 0)
            {
                var data = _dbContext.Educations.OrderBy(x => x.EducationsId).FirstOrDefault();
                if (data != null)
                    educationsId = data.EducationsId;
            }
            return _dbContext.Educations.Find(educationsId);
        }
        public IEnumerable<EducationsFile> GetUIEducationsFile(int educationsId)
        {
            if (educationsId == 0)
            {
                var data = _dbContext.Educations.OrderBy(x => x.EducationsId).FirstOrDefault();
                if (data != null)
                    educationsId = data.EducationsId;
            }
            return _dbContext.EducationsFile.Where(m => m.EducationsId == educationsId).AsEnumerable();
        }
        public IEnumerable<Educations> GetUIBestEducation()
        {
            return _dbContext.Educations.Where(m => m.IsBest).Take(4).OrderBy(x => x.EducationsId).AsEnumerable();
        }
    }
}