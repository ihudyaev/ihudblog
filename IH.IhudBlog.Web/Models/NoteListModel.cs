using System;
using IH.IhudBlog.Core.Models;
using System.ComponentModel.DataAnnotations;
using IH.IhudBlog.Core.NHibernate;
using System.Web;

namespace IH.IhudBlog.Web.Models
{
    public class NoteListModel
    {
        /// <summary>
        /// ИД заметки
        /// </summary>
        /// 
        [Display(Name = "ИД")]
        public long Id { get; set; }
        /// <summary>
        /// Короткое название статьи
        /// </summary>
        /// 
        [Display(Name = "Заголовок")]
        public string ShortTitle { get; set; }
        /// <summary>
        /// автор
        /// </summary>
        /// 
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }
        /// <summary>
        /// Черновик
        /// </summary>
        /// 
        [Display(Name = "Черновик")]
        [Required(ErrorMessage = "Заголовок надо заполнить для лучшего отображения статьи в списке")]
        public bool IsDraft { get; set; }
        /// <summary>
        /// Тэги
        /// </summary>
        /// 

        [Display(Name = "Теги")]
        public string Tags { get; set; }
        /// <summary>
        /// Время создания
        /// </summary>
        /// 
        [Display(Name = "Время изменения")]
        public DateTime ChangeTime { get; set; }
        /// <summary>
        /// Время создания
        /// </summary>
        /// 
        [Display(Name = "Время создания")]
        public DateTime CreationTime { get; set; }
        /// <summary>
        /// Разрешено редактирование / удаление?
        /// </summary>
        /// 
        [Display(Name = "Владелец")]
        public bool Owner { get; set; }


        public NoteListModel()
        {

        }
        public NoteListModel(Note note)
        {
            this.Id = note.Id;
            this.IsDraft = note.IsDraft;
            this.ShortTitle = note.Title.Length > 30 ? note.Title.Substring(0, 30)+ "..." : note.Title;
            this.UserName = note.User.Login;
            this.Tags = note.Tags;
            this.ChangeTime = note.ChangeTime;
            this.CreationTime = note.CreationTime;
            this.Owner = note.User.Login == HttpContext.Current.User.Identity.Name ? true : false;
        }


        public static Note Conversion(NoteListModel note)
        {
         
            NHNoteRepository NoteRepository = new IH.IhudBlog.Core.NHibernate.NHNoteRepository();
            Note NHnote = new Note();
            NHnote = NoteRepository.LoadById(note.Id);

            Note result = new Note
            {
                IsDraft = note.IsDraft,
                Title = NHnote.Title,
                Text = NHnote.Text,
                User = NHnote.User,
                Tags = NHnote.Tags == null ? "" : note.Tags,
                ChangeTime = DateTime.Now,
                CreationTime = NHnote.CreationTime == null ? DateTime.Now : note.CreationTime,
                NoteStatus = 1
            };
            return result;
        }

        public string Error { get; set; }
    }
}
