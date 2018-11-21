using System.Collections.Generic;
using IH.IhudBlog.Core.Models;

namespace IH.IhudBlog.Core.Repository.Interface
{
    public interface IFileRepository : IEntityRepository<File>
    {
        /// <summary>
        /// Найти пользователя по имени
        /// </summary>
        /// <param name="name">Имя или login</param>
        /// <returns></returns>
        IList<File> LoadByNote(long NoteId);
    }
}



    