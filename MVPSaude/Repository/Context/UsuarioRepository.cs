using Fiap.Api.MVPSaude.Model;
using Fiap.Web.MVPSaude.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.MVPSaude.Repository.Context
{
    public class UsuarioRepository
    {

        private readonly DataBaseContext dataBaseContext;

        public UsuarioRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }




        public IList<UsuarioModel> Listar()
        {
            var lista = new List<UsuarioModel>();

            // Efetuando a listagem (Substituindo o Select *)
            lista = dataBaseContext.Usuario.ToList();

            return lista;
        }

        public UsuarioModel Consultar(int id)
        {
            // Recuperando o objeto Usuario de um determinado Id
            var usuario = dataBaseContext.Usuario.Find(id);

            return usuario;
        }

        public void Inserir(UsuarioModel usuario)
        {
            // Adiciona o objeto preenchido pelo usuário
            dataBaseContext.Usuario.Add(usuario);

            // Salva as alterações
            dataBaseContext.SaveChanges();

        }

        public void Alterar(UsuarioModel usuario)
        {
            dataBaseContext.Usuario.Update(usuario);

            // Salva as alterações
            dataBaseContext.SaveChanges();
        }

        public void Excluir(UsuarioModel usuario)
        {


            dataBaseContext.Usuario.Remove(usuario);

            // Salva as alterações
            dataBaseContext.SaveChanges();

        }


    }
}