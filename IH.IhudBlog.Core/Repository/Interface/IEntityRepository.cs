using System.Collections.Generic;
using IH.IhudBlog.Core.Models;

namespace IH.IhudBlog.Core.Repository.Interface
{

    public interface IEntityRepository<T> where T : class, IEntity
    {
        T Create();

        T Load(long id);

        void Save(T entity);

        void Delete(long id);

        IEnumerable<T> GetAll();
    }

}

