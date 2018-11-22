using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IH.IhudBlog.Core.NHibernate;

namespace IH.IhudBlog.Core.Models
{
    public class File : IEntity
    {
        /// <summary>
        /// ИД
        /// </summary>
        public virtual long Id { get; set; }
        /// <summary>
        /// Имя файла
        /// </summary>
        public virtual string FileN { get; set; }
        /// <summary>
        /// Гуид имя - так сохраняем на диске
        /// </summary>
        public virtual string GuidName { get; set; }

        /// <summary>
        /// ИД заметки к которой относится файл
        /// </summary>
        //public virtual Note NoteId { get; set; }
        public virtual Note Note { get; set; }

        /// <summary>
        /// True-Active,False-Delete
        /// </summary>
        public virtual bool FileStatus { get; set; }
    }

   

}




