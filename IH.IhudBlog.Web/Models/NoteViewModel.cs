using System;
using System.Collections.Generic;
using IH.IhudBlog.Core.Models;
using System.ComponentModel.DataAnnotations;
using IH.IhudBlog.Core.NHibernate;
using System.Web;

namespace IH.IhudBlog.Web.Models
{
    public class NoteViewModel
    {
        /// <summary>
        /// ИД заметки
        /// </summary>
        /// 
        [Display(Name = "ИД")]
        public long? Id { get; set; }
        /// <summary>
        /// Название статьи
        /// </summary>
        /// 
        [Display(Name = "Заголовок статьи")]
        [Required(ErrorMessage = "Нужен заголовок")]
        public string Title { get; set; }
        /// <summary>
        /// Короткое название статьи
        /// </summary>
        /// 
        [Display(Name = "Заголовок")]
        public string ShortTitle { get; set; }
        /// <summary>
        /// Текст заметки
        /// </summary>
        /// 
        [Display(Name = "Текст заметки")]
        [Required(ErrorMessage = "Нужен текст")]
        public string Text { get; set; }
        /// <summary>
        /// автор
        /// </summary>
        /// 
        [Display(Name = "ИД пользователя")]
        public long UserId { get; set; }
        /// <summary>
        /// Черновик
        /// </summary>
        /// 
        [Display(Name = "Черновик")]
        public bool IsDraft { get; set; }
        /// <summary>
        /// Тэги
        /// </summary>
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
        /// Ссылки на файлы
        /// </summary>
        [Display(Name = "Файлы")]
        //public List<FileLight> NoteFiles { get; set; }
        public List<File> NoteFiles { get; set; }
        /// <summary>
        /// Пользователь - владелец
        /// </summary>
        /// 
        [Display(Name = "Пользователь")]
        public User User { get; set; }
        /// <summary>
        /// Файлы для загрузки
        /// </summary>

        //[DataType(DataType.Upload)]
        //public List<HttpPostedFileBase> FilesUpload { get; set; }


        public NoteViewModel()
        {
            this.IsDraft = false;
            this.ShortTitle = "";
            this.Title = "";
            this.Text = "";
            this.User = null;
            this.UserId = -1;
            this.Tags = "";
            this.ChangeTime = DateTime.Now;
            this.CreationTime = DateTime.Now;
        }
        public NoteViewModel(Note note)
        {
            //var StartData = Note.GetNotes();

            this.Id = note.Id;
            this.IsDraft = note.IsDraft;
            this.ShortTitle = note.Title.Length > 30 ? note.Title.Substring(0, 30)+ "..." : note.Title;
            this.Title = note.Title;
            this.Text = note.Text;
            this.User = note.User;//new User() { Login = "admin", Password = "admin", Id = 1 };//StartData.Users.FirstOrDefault(u => u.Id == note.UserId);
            this.UserId = note.User.Id;
            this.Tags = note.Tags;//.Split(new char[] {' '});
            this.ChangeTime = note.ChangeTime;
            this.CreationTime = note.CreationTime;

            NHFileRepository NHFileRepository = new IH.IhudBlog.Core.NHibernate.NHFileRepository();
            
            List<File> Files = new List<File>();
            

            foreach (File file in NHFileRepository.LoadByNote(note.Id))
            {
                //tempFile = ConversionFileTypes(file);
                Files.Add(file);
            }

            this.NoteFiles = Files;

        }


        public static Note Conversion(NoteViewModel note)
        {
            //var StartData = Note.GetNotes();
            NHUserRepository NhuserRepository = new IH.IhudBlog.Core.NHibernate.NHUserRepository();
            User user = new User();
            user = NhuserRepository.LoadByName(HttpContext.Current.User.Identity.Name);

            Note result = new Note
            {
                Id = (long)note.Id,
                IsDraft = note.IsDraft,
                Title = note.Title,
                Text = note.Text,
                User = user,
                Tags = note.Tags == null ? "" : note.Tags,//String.Join(" ", note.Tags?.ToArray()),
                ChangeTime = DateTime.Now,
                CreationTime = note.CreationTime == null ? DateTime.Now : note.CreationTime,
                NoteStatus = 1
                
            };
            
            return result;
        }


        public static FileLight ConversionFileTypes(File file)
        {
            
            FileLight result = new FileLight
            {
                Id = (long)file.Id,
                FileN = file.FileN,
                FileStatus = file.FileStatus,
                GuidName = file.GuidName,
                NoteId = file.Note.Id
            };

            return result;
        }

        public static File FileConversion(HttpPostedFileBase file, long noteId)
        {
            
            File result = new File
            {
                Id = -1,
                FileN = file.FileName,
                GuidName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(file.FileName),
                Note = new Note(),
                FileStatus = true

            };

            return result;
        }

        public string Error { get; set; }
    }
}
