using System;
using System.Collections.Generic;
using NHibernate;
using IH.IhudBlog.Core.Models;
using IH.IhudBlog.Core.Repository.Interface;
using NHibernate.Criterion;

namespace IH.IhudBlog.Core.NHibernate
{

    public class NHUserRepository : NHBaseRepository<User>, IUserRepository
    {
        public override void Delete(long id)
        {
            var user = Load(id);

            if (user != null)
            {
                user.UserStatus = 3;
                Save(user);
            }
        }

        public void Block(long id)
        {
            var user = Load(id);

            if (user != null)
            {
                user.UserStatus = 2;
                Save(user);
            }
        }

        public User LoadByName(string name)
        {
            var session = NHibernateHelper.GetCurrentSession();

            var entity = session.QueryOver<User>()
                .And(u => u.Login == name)
                .SingleOrDefault();

            NHibernateHelper.CloseSession();

            return entity;
        }

        public IEnumerable<User> GetAllValid()
        {
            
            ISession session = NHibernateHelper.GetCurrentSession();

            var criteria = session.CreateCriteria<User>().Add(Expression.Eq("UserStatus", 1));

            var entities = criteria.List<User>();

            NHibernateHelper.CloseSession();

            return entities;
        }

    }

}



