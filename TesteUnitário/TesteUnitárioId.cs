using LembretesDTI.Controllers;
using System.Xml.Linq;
using Teste_DTI_Notes.Models;

namespace TesteUnitário

{
    public class TesteUnitárioId
    {
        [Fact]
        public void TestIdCreatorEmptyList()
        {
            //Teste averigua se em uma lista vazia a função cria o id = 1!
            List<Note> Notes = new List<Note>();

            Assert.Equal(1, NoteController.IdCreation(Notes));
        }

        [Fact]
        public void TestIdCreationSecondPosition()
        {
            //Teste averigua se em uma lista que ja contem o id = 1 o id = 2 será criado!
            List<Note> Notes = new List<Note>();

            Notes.Add(new Note { Id = 1, Name = "teste", Date = DateTime.Now });

            Assert.Equal(2, NoteController.IdCreation(Notes));
        }

        [Fact]
        public void TestRemovePosition() {

            List<Note> Notes = new List<Note>();

            //Teste averigua se caso a posição 1 e 0 sejam removidas a função criará as proximas posições com o id correto!
            Notes.Add(new Note { Id = 1, Name = "teste", Date = DateTime.Now });
            Notes.Add(new Note { Id = 2, Name = "teste2", Date = DateTime.Now });
            Notes.RemoveAt(1);

            Assert.Equal(2, NoteController.IdCreation(Notes));

            Notes.RemoveAt(0);

            Assert.Equal(1, NoteController.IdCreation(Notes));
        }
    }
}

    