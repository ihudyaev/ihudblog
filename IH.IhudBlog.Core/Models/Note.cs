using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IH.IhudBlog.Core.Models
{
    public class Note:IEntity
    {
        
        public virtual long Id { get; set; }
        
        public virtual string Title { get; set; }
        
        public virtual string Text { get; set; }

        public virtual bool IsDraft { get; set; }

        public virtual string Tags { get; set; }


        public virtual DateTime ChangeTime { get; set; }

        public virtual DateTime CreationTime { get; set; }


        public virtual User User { get; set; }
        /// <summary>
        /// Status 1- enabled,2-deleted
        /// </summary>
        public virtual int NoteStatus { get; set; }

    }

    
}
