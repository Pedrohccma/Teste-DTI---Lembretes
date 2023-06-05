using LembretesDTI.Controllers;
using System.Xml.Linq;
using Teste_DTI_Notes.Models;

namespace TesteUnitário

{
    public class TesteUnitárioId
    {
        [Fact]
        public void TestIdCreatorQuandoAListaDeNotasEstaVazia()
        {
            List<Note> Notes = new List<Note>();

            Assert.Equal(1, NoteController.IdCreation(Notes));
        }

        [Fact]
        public void TestAddNote()
        {
            List<Note> Notes = new List<Note>();

            Notes.Add(new Note { Id = 1, Name = "teste", Date = DateTime.Now });

            Assert.Equal(2, NoteController.IdCreation(Notes));
        }

        [Fact]
        public void TestRemoverPosicao1() {

            List<Note> Notes = new List<Note>();

            Notes.Add(new Note { Id = 1, Name = "teste", Date = DateTime.Now });
            Notes.Add(new Note { Id = 2, Name = "teste2", Date = DateTime.Now });
            Notes.RemoveAt(1);

            Assert.Equal(2, NoteController.IdCreation(Notes));

            Notes.RemoveAt(0);

            Assert.Equal(1, NoteController.IdCreation(Notes));
        }
    }
}

    