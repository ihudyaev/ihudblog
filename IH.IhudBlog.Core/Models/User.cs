using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IH.IhudBlog.Core.Models
{
    public class User : IEntity
    {
        public virtual long Id { get; set; }

        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        /// <summary>
        /// 1-Active,2-Blocked,3-Deleted
        /// </summary>
        public virtual int UserStatus { get; set; }
    }

}




