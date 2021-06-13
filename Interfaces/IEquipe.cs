using System.Collections.Generic;
using Eplayers_AspNetCore.Models;

namespace Eplayers_AspNetCore.Interfaces
{
    public interface IEquipe
    {
        void Cadastrar(Equipe e);

        List<Equipe> LerTodos();

        void Alterar(Equipe e);

        void Deletar(int id);
    }
}