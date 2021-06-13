using System.Collections.Generic;
using System.IO;
using Eplayers_AspNetCore.Interfaces;

namespace Eplayers_AspNetCore.Models
{
    public class Equipe : EPlayersBase, IEquipe
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }

        private const string CAMINHO = "Database/Equipe.csv";

        public Equipe()
        {

            CriarPastaEArquivo(CAMINHO);
        }

        public string PrepararDados(Equipe e)
        {
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }

        public void Alterar(Equipe e)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);

            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());

            linhas.Add(PrepararDados(e));

            ReescreverCSV(CAMINHO, linhas);
        }

        public void Cadastrar(Equipe e)
        {
            string[] linhas = { PrepararDados(e) };
            
            File.AppendAllLines(CAMINHO, linhas);
        }

        public void Deletar(int id)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);

            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());

            ReescreverCSV(CAMINHO, linhas);
        }

        public List<Equipe> LerTodos()
        {
            List<Equipe> equipes = new List<Equipe>();

            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Equipe e = new Equipe();

                e.IdEquipe = int.Parse(linha[0]);
                e.Nome = linha[1];
                e.Imagem = linha[2];

                equipes.Add(e);
            }

            return equipes;
        }
    }
}