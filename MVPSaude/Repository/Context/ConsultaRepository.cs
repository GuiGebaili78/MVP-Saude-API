using Fiap.Api.MVPSaude.Model;
using Fiap.Web.MVPSaude.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Api.MVPSaude.Repository.Context
{
    public class ConsultaRepository
    {
        private readonly DataBaseContext _dataBaseContext;

        public ConsultaRepository(DataBaseContext ctx)
        {
            _dataBaseContext = ctx;
        }

        public IList<ConsultaModel> Listar()
        {
            return _dataBaseContext.Consulta.ToList();
        }

        public ConsultaModel Consultar(int id)
        {
            return _dataBaseContext.Consulta.Find(id);
        }

        public void Inserir(ConsultaModel consulta)
        {
            _dataBaseContext.Consulta.Add(consulta);
            _dataBaseContext.SaveChanges();
        }

        public void Alterar(ConsultaModel consulta)
        {
            _dataBaseContext.Consulta.Update(consulta);
            _dataBaseContext.SaveChanges();
        }

        public void Excluir(ConsultaModel consulta)
        {
            _dataBaseContext.Consulta.Remove(consulta);
            _dataBaseContext.SaveChanges();
        }
    }
}
