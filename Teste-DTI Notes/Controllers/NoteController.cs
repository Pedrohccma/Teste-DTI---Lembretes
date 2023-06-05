using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
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

        //Adicao novo lembrete
        [HttpPost]
        public ActionResult AddNotes() {

            var name = Request.Form["name"][0];
            var possibleInvalidDate = Request.Form["date"][0];

            string? errorMessage = AddNoteValidations(name, possibleInvalidDate);

            if (errorMessage != null) 
                return new BadRequestObjectResult(errorMessage);

            var date = DateTime.Parse(Request.Form["date"][0]);

            int id = IdCreation();

            Note note = new() { Id = id, Name = name, Date = date };

            Notes.Add(note);

            Notes = Notes.OrderBy(note => note.Date).ToList();

            return Redirect("https://localhost:7217/");
        }
         
        //Remocao do lembrete
        [HttpPost]
        public IActionResult RemoveNotes(int id)
        {
            Note note = Notes.First(note => note.Id == id);
            if (note != null)
            {
                Notes.Remove(note);
            }

            return new OkResult();
        }

        #region Métodos Privados

        private static int IdCreation()
        {
            int id = 0;
            int count = Notes.Count;

            if (count != 0)
            {
                id = Notes[count - 1].Id;
            }
            return id + 1;
        }

        private string? AddNoteValidations(string name, string possibleInvalidDate) {

            if (string.IsNullOrEmpty(possibleInvalidDate))
            {
                return "O campo data é obrigatório";
            }

            var date = DateTime.Parse(Request.Form["date"][0]);

            if (string.IsNullOrEmpty(name))
            {
                return "O campo nome é obrigatório";
            }
            if (date < DateTime.Now)
            {
                return "A data informada deve ser posterior a data de hoje";
            }

            return null;

        }

        #endregion
    }

}