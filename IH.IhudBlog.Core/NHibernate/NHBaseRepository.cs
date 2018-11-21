using System;
using System.Collections.Generic;
using NHibernate;
using IH.IhudBlog.Core.Models;
using IH.IhudBlog.Core.Repository.Interface;
using NHibernate.Criterion;

namespace IH.IhudBlog.Core.NHibernate
{
    public class NHBaseRepository<T> : IEntityRepository<T> where T : class, IEntity
    {
        public virtual T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public virtual void Delete(long id)
        {
            var session = NHibernateHelper.GetCurrentSession();

            try
            {
                using (var tx = session.BeginTransaction())
                {
                    var entity = Load(id);

                    if (entity != null)
                    {
                        session.Delete(entity);
                        tx.Commit();
                    }
                }
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            var criteria = session.CreateCriteria<T>();
            var entities = criteria.List<T>();

            NHibernateHelper.CloseSession();

            return entities;
        }

       

        public virtual T Load(long id)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            var user = session.Load<T>(id);

            NHibernateHelper.CloseSession();

            return user;
        }

        public virtual void Save(T entity)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            try
            {
                using (var tx = session.BeginTransaction())
                {
                    session.SaveOrUpdate(entity);
                    tx.Commit();
                }
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }
        }

        public virtual T LoadById(long Id)
        {
            var session = NHibernateHelper.GetCurrentSession();

            var entity = session.QueryOver<T>()
                .And(u => u.Id == Id)
                .SingleOrDefault();

            NHibernateHelper.CloseSession();

            return entity;
        }
    }
}
