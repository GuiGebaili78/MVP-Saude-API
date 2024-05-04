using Fiap.Api.MVPSaude.Model;
using Fiap.Web.MVPSaude.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.MVPSaude.Repository.Context
{
    public class ConsultaRepository
    {

        private readonly DataBaseContext dataBaseContext;

        public ConsultaRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }



        public IList<ConsultaModel> Listar()
        {
            var lista = new List<ConsultaModel>();

            // Efetuando a listagem (Substituindo o Select *)
            lista = dataBaseContext.Consulta.ToList();

            return lista;
        }

        public ConsultaModel Consultar(int id)
        {
            // Recuperando o objeto Consulta de um determinado Id
            var consulta = dataBaseContext.Consulta.Find(id);

            return consulta;
        }

        public void Inserir(ConsultaModel consulta)
        {
            // Adiciona o objeto preenchido pelo usuário
            dataBaseContext.Consulta.Add(consulta);

            // Salva as alterações
            dataBaseContext.SaveChanges();

        }

        public void Alterar(ConsultaModel consulta)
        {
            dataBaseContext.Consulta.Update(consulta);

            // Salva as alterações
            dataBaseContext.SaveChanges();
        }

        public void Excluir(ConsultaModel consulta)
        {


            dataBaseContext.Consulta.Remove(consulta);

            // Salva as alterações
            dataBaseContext.SaveChanges();

        }


    }
}