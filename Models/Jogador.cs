using System.Collections.Generic;
using System.IO;
using Eplayers_AspNetCore.Interfaces;

namespace Eplayers_AspNetCore.Models
{
    public class Jogador : EPlayersBase , IJogador
    {
        public int IdJogador { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int IdEquipe { get; set; }

        private const string CAMINHO = "Database/Jogador.csv";

        public Jogador()
        {
            CriarPastaEArquivo(CAMINHO);
        }

        /// <summary>
        /// Adiciona um Jogador ao CSV
        /// </summary>
        /// <param name="j">Jogador</param>
        public void Criar(Jogador j)
        {
            string[] linha = { PrepararLinha(j) };
            File.AppendAllLines(CAMINHO, linha);
        }

        /// <summary>
        /// Prepara a linha para a estrutura do objeto Jogador
        /// </summary>
        /// <param name="j">Objeto "Jogador"</param>
        /// <returns>Retorna a linha em formato de .csv</returns>
        private string PrepararLinha(Jogador j)
        {
            return $"{j.IdJogador};{j.Nome};{j.Email};{j.Senha};{j.IdEquipe}";
        }

        /// <summary>
        /// Exclui uma Jogador
        /// </summary>
        /// <param name="idJogador"></param>
        public void Deletar(int idJogador)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            // 1;FLA;fla.png
            linhas.RemoveAll(x => x.Split(";")[0] == idJogador.ToString());                        
            ReescreverCSV(CAMINHO, linhas);
        }

        /// <summary>
        /// Lê todos as linhas do csv
        /// </summary>
        /// <returns>Lista de Jogadors</returns>
        public List<Jogador> LerTodos()
        {
            List<Jogador> jogadores = new List<Jogador>();
            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Jogador jogador = new Jogador();
                jogador.IdJogador = int.Parse(linha[0]);
                jogador.Nome = linha[1];
                jogador.Email = linha[2];
                jogador.Senha = linha[3];
                jogador.IdEquipe = int.Parse(linha[4]);

                jogadores.Add(jogador);
            }
            return jogadores;
        }

        /// <summary>
        /// Altera uma Jogador
        /// </summary>
        /// <param name="j">Jogador alterada</param>
        public void Alterar(Jogador j)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == j.IdJogador.ToString());
            linhas.Add( PrepararLinha(j) );                        
            ReescreverCSV(CAMINHO, linhas); 
        }
    }
}