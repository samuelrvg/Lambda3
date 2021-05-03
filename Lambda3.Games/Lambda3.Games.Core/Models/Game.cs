
namespace Lambda3.Games.Core.Models
{
    public class Game
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public double Nota { get; set; }
        public int Ano { get; set; }

        public Game(string id, string tituto, double nota, int ano)
        {
            Id = id;
            Titulo = tituto;
            Nota = nota;
            Ano = ano;
        }

        public Game() {}
    }
}
