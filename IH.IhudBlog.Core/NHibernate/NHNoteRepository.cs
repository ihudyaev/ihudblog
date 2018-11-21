using System.Web;
using System.Collections.Generic;
using NHibernate;
using IH.IhudBlog.Core.Models;
using IH.IhudBlog.Core.Repository.Interface;
using NHibernate.Criterion;

namespace IH.IhudBlog.Core.NHibernate
{

    public class NHNoteRepository : NHBaseRepository<Note>, INoteRepository
    {
        /// <summary>
        /// Загрузка по пользователю
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public IList<Note> LoadByUser(long UserId)
        {
            var session = NHibernateHelper.GetCurrentSession();

            var entity = session.QueryOver<Note>()
                .And(u => u.User.Id == UserId)
                .List();

            NHibernateHelper.CloseSession();

            return entity;
        }

        public IEnumerable<Note> GetAllValid()
        {
            

            NHUserRepository UserRep = new NHUserRepository();

            User CurrrentUser = UserRep.LoadByName(HttpContext.Current.User.Identity.Name);

            ISession session = NHibernateHelper.GetCurrentSession();

            var criteria = session.CreateCriteria<Note>().Add(Expression.Eq("NoteStatus", 1)).Add(Expression.Or(
                Expression.Eq("User", CurrrentUser),
                Expression.Eq("IsDraft", false)
                ));

            var entities = criteria.List<Note>();

            NHibernateHelper.CloseSession();

            return entities;
        }


    }

}



