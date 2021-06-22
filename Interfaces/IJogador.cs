using System.Collections.Generic;
using Eplayers_AspNetCore.Models;

namespace Eplayers_AspNetCore.Interfaces
{
    public interface IJogador
    {
        //Criar
        void Criar(Jogador j);
        //Ler
        List<Jogador> LerTodos();
        //Alterar
        void Alterar(Jogador j);
        //Excluir
        void Deletar(int id);  
    }
}