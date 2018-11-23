using System.Web;
using System.Collections.Generic;
using NHibernate;
using IH.IhudBlog.Core.Models;
using IH.IhudBlog.Core.Repository.Interface;
using NHibernate.Criterion;

namespace IH.IhudBlog.Core.NHibernate
{

    public class NHFileRepository : NHBaseRepository<File>, IFileRepository
    {
        /// <summary>
        /// Загрузка по пользователю
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public IList<File> LoadByNote(long NoteId)
        {
            var session = NHibernateHelper.GetCurrentSession();

            var entity = session.QueryOver<File>()
                .And(f => f.Note.Id == NoteId)
                .And(f => f.FileStatus == true)
                .List();

            NHibernateHelper.CloseSession();

            return entity;
        }

    }

}



