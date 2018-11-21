using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IH.IhudBlog.Core.Models;

namespace IH.IhudBlog.Core.Repository.Interface
{
    public interface IUserRepository : IEntityRepository<User>
    {
        /// <summary>
        /// Найти пользователя по имени
        /// </summary>
        /// <param name="name">Имя или login</param>
        /// <returns></returns>
        User LoadByName(string name);

        /// <summary>
        /// Заблокировать пользователя
        /// </summary>
        /// <param name="id">Идентификатор</param>
        void Block(long id);
    }
}



    