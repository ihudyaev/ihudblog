using System.Collections.Generic;
using IH.IhudBlog.Core.Models;

namespace IH.IhudBlog.Core.Repository.Interface
{
    public interface INoteRepository : IEntityRepository<Note>
    {
        /// <summary>
        /// Найти пользователя по имени
        /// </summary>
        /// <param name="name">Имя или login</param>
        /// <returns></returns>
        IList<Note> LoadByUser(long UserId);
    }
}



    