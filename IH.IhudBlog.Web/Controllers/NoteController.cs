using System.Collections.Generic;
using System.Web.Mvc;
using System.Web;
using IH.IhudBlog.Web.Models;
using IH.IhudBlog.Core.Models;
using System;
using System.Linq;
using IH.IhudBlog.Core.NHibernate;

namespace IH.IhudBlog.Web.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {


        Core.NHibernate.NHNoteRepository NoteRepository;

        public NoteController()
        {
            NoteRepository = new IH.IhudBlog.Core.NHibernate.NHNoteRepository();
        }

        // GET: Note
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "UserName_desc" : "";
            ViewBag.DateSortParm = sortOrder == "ChangeTime" ? "ChangeTime_desc" : "ChangeTime";
            ViewBag.TitleSortParam = sortOrder == "Title" ? "Title_desc" : "Title";
            ViewBag.DraftSortParam = sortOrder == "IsDraft" ? "IsDraft_desc" : "IsDraft";



            IEnumerable<Note> all = NoteRepository.GetAllValid();
            //фильтр
            if (!String.IsNullOrEmpty(searchString))
            {
                all = all.Where(s => s.Title.Contains(searchString)
                                       || s.Text.Contains(searchString));
            }
            //соритровка
            switch (sortOrder)
            {
                case "UserName_desc":
                    all = all.OrderByDescending(s => s.User.Login);
                    break;
                case "ChangeTime_desc":
                    all = all.OrderByDescending(s => s.ChangeTime);
                    break;
                case "ChangeTime":
                    all = all.OrderBy(s => s.ChangeTime);
                    break;
                case "Title_desc":
                    all = all.OrderByDescending(s => s.Title);
                    break;
                case "Title":
                    all = all.OrderBy(s => s.Title);
                    break;
                case "IsDraft":
                    all = all.OrderBy(s => s.IsDraft);
                    break;
                case "IsDraft_desc":
                    all = all.OrderByDescending(s => s.IsDraft);
                    break;
                default:
                    all = all.OrderBy(s => s.User.Login);
                    break;
            }

            

            List<NoteListModel> model = new List<NoteListModel>();
            

            foreach (Note note in all)
            {
                model.Add(new NoteListModel(note));
            }

            return View(model);

        }


        [HttpGet]
        public ActionResult EditNote(long noteid)
        {
            if(noteid == -1)
            {
                NoteViewModel noteT = new NoteViewModel();
                return PartialView(noteT);
            }
            

            Note note = NoteRepository.LoadById(noteid);
            NoteViewModel model = new NoteViewModel(note);

            var result = PartialView(model);

            return result;
            

        }


        // GET: Note
        [HttpPost]
        public ActionResult EditNote(NoteViewModel model)//, IEnumerable<HttpPostedFileBase> files)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Проверьте, что заполнены все поля! 😊");
                return PartialView(model);
            }

            var UserRepository = new IH.IhudBlog.Core.NHibernate.NHUserRepository();

            User UserNote = UserRepository.LoadById(model.UserId);

            model.User = UserNote;

            Note SaveNote = new Note();

            
            

            if(model.Id == null || model.Id == -1)
            {
                model.Id = NoteRepository.Create().Id;
            }
            
            SaveNote = NoteViewModel.Conversion(model);

            NoteRepository.Save(SaveNote);

            IEnumerable<Note> all = NoteRepository.GetAllValid();

            List<NoteListModel> modelList = new List<NoteListModel>();


            foreach (Note note in all)
            {
                modelList.Add(new NoteListModel(note));
            }

            //return RedirectToAction("Index");
            return View("Index", modelList);

        }

        [HttpGet]
        public ActionResult DeleteNote(int noteid)
        {
            //return View(StartData.Notes);
            Note note = NoteRepository.LoadById(noteid);
            NoteViewModel model = new NoteViewModel(note);

            return PartialView(model);
            //return PartialView(new NoteViewModel ());

        }


        // GET: Note
        [HttpPost]
        public ActionResult DeleteNote(NoteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var UserRepository = new IH.IhudBlog.Core.NHibernate.NHUserRepository();

            User UserNote = UserRepository.LoadById(model.UserId);

            model.User = UserNote;

            Note SaveNote = new Note();

            

            SaveNote = NoteViewModel.Conversion(model);
            SaveNote.NoteStatus = 2;

            NoteRepository = new NHNoteRepository();

            NoteRepository.Save(SaveNote);


            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult ShowNote(int noteid)
        {
            Note note = NoteRepository.LoadById(noteid);
            NoteViewModel model = new NoteViewModel(note);
            
            var result = PartialView(model);
            return result;
            

        }

        public ActionResult NoteList()
        {
            

            
            IEnumerable<Note> all = NoteRepository.GetAllValid();
            List<NoteViewModel> model = new List<NoteViewModel>();
            foreach (Note note in all)
            {
                model.Add(new NoteViewModel(note));
            }
            return View(model);

        }

        public ActionResult DownloadFile(string fileid)
        {

            var FileRepo = new NHFileRepository(); 

            var FileT = FileRepo.LoadById(Convert.ToInt64(fileid));

            string FilePath = Server.MapPath("/Files/" + FileT.GuidName);

            byte[] Bytes = System.IO.File.ReadAllBytes(FilePath);

            return File(Bytes, "FILE", FileT.FileN);

        }

    }
}