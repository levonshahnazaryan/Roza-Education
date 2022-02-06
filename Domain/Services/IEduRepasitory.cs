using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Services
{
    public interface IEduRepasitory
    {
        IEnumerable<UsefulLinks> GetUsefulLinks();
        UsefulLinks GetUsefulLinks(int usefulLinksId);
        bool AddEntity<TEntity>(TEntity entity) where TEntity : class;
        bool EditEntity<TEntity>(string values, params object[] keys) where TEntity : class;
        bool EditUsefulLinksImgUrl(int usefulLinksId, string imgUrl);
        bool DeleteEntity<TEntity>(params object[] keys) where TEntity : class;
        bool SortUsefulLinks(int key, string values);
    }
}