using Microsoft.AspNetCore.Mvc;
using Teste_DTI_Notes.Models;

namespace LembretesDTI.Controllers
{
    public class NoteController : Controller
    {
        private static List<Note> Notes = new List<Note>();

        [HttpGet]
        public List<Note> GetNotes()
        {
            return Notes;
        }

        //Criacao do Id do lembrete
        protected int IdCreation()
        {
            int id = 0;
            int count = Notes.Count();

            if (count != 0)
            {
                Note nts = new Note();
                nts = Notes[count - 1];
                id = nts.Id;
            }
            return id + 1;
        }

        //Adicao novo lembrete
        [HttpPost]
        public ActionResult AddNotes() {

            var name = Request.Form["name"][0];
            var date = DateTime.Parse(Request.Form["date"][0]);

            int id = IdCreation();

            if (String.IsNullOrEmpty(name))
            {
                ModelState.AddModelError("Name", "O campo nome é obrigatório");
                return RedirectToAction("Index");
            }
            if (date < DateTime.Now)
            {
                ModelState.AddModelError("Date", "A data informada não pode ser anterior a data de hoje");
                return RedirectToAction("Index");
            }

            Note note = new Note { Id = id, Name = name, Date = date };

            Notes.Add(note);

            Notes = Notes.OrderBy(l => l.Date).ToList();

            return Redirect("https://localhost:7217/");
        }
         
        //Remocao do lembrete
        [HttpPost]
        public IActionResult RemoveNotes(int id)
        {
            Note note = Notes.FirstOrDefault(lmbt => lmbt.Id == id);
            if (note != null)
            {
                Notes.Remove(note);
            }

            return new OkResult();
        }

    }

}