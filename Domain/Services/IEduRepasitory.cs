using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Services
{
    public interface IEduRepasitory
    {
        IEnumerable<UsefulLinks> GetUsefulLinks();
        UsefulLinks GetUsefulLinks(int usefulLinksId);
        AboutUs GetAboutUs();
        AboutCollage GetAboutCollage();
        IEnumerable<AboutFiles> GetAboutFiles();
        IEnumerable<Educations> GetEducation();
        IEnumerable<Educations> GetEducationParent();
        Educations FindEducation(int educationsId);
        IEnumerable<EducationsFile> GetEducationsFile(int educationsId);
        IEnumerable<VideoEducation> GetVideoEducation();
        bool AddEntity<TEntity>(TEntity entity) where TEntity : class;
        bool EditEntity<TEntity>(string values, params object[] keys) where TEntity : class;
        bool EditUsefulLinksImgUrl(int usefulLinksId, string imgUrl);
        bool EditAboutUsContent(AboutUs data);
        bool EditAboutCollageContent(AboutCollage data);
        bool EditEducationsContent(Educations data);
        bool DeleteEntity<TEntity>(params object[] keys) where TEntity : class;
        bool SortUsefulLinks(int key, string values);
        IEnumerable<UsefulLinks> GetUIUsefulLinks();
        IEnumerable<Educations> GetUIEducation();
        Educations FindUIEducation(int educationsId);
        IEnumerable<EducationsFile> GetUIEducationsFile(int educationsId);
        IEnumerable<Educations> GetUIBestEducation();
    }
}