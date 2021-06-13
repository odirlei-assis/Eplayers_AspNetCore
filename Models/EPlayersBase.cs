using System.Collections.Generic;
using System.IO;

namespace Eplayers_AspNetCore.Models
{
    public abstract class EPlayersBase
    {
        public void CriarPastaEArquivo(string caminho){
            string pasta = caminho.Split("/")[0];

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(caminho))
            {
                File.Create(caminho);
            }
        }


        public List<string> LerTodasLinhasCSV(string caminho){
            List<string> linhas = new List<string>();

            using (StreamReader arquivo = new StreamReader(caminho))
            {
                string linha;
                while ((linha = arquivo.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }

            return linhas;
        }

        public void ReescreverCSV(string caminho, List<string> linhas){

            using (StreamWriter arquivo = new StreamWriter(caminho))
            {
                foreach (var item in linhas)
                {
                    arquivo.Write(item + "\n");
                }
            }
        }
    }
}