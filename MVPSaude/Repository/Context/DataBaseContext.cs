﻿using Fiap.Api.MVPSaude.Model;
using Fiap.Web.MVPSaude.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.MVPSaude.Repository.Context
{
    public class DataBaseContext : DbContext
    {

        // Propriedade que será responsável pelo acesso a tabela de Pacientes
        public DbSet<PacienteModel> Paciente { get; set; }

        // Propriedade que será responsável pelo acesso a tabela de Medicos
        public DbSet<MedicoModel> Medico { get; set; }

        // Propriedade que será responsável pelo acesso a tabela de Prontuários
        public DbSet<ProntuarioModel> Prontuario { get; set; }

        // Propriedade que será responsável pelo acesso a tabela de Consultas
        public DbSet<ConsultaModel> Consulta { get; set; }

        // Propriedade que será responsável pelo acesso a tabela de Usuários
        public DbSet<UsuarioModel> Usuario { get; set; }


        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DataBaseContext()
        {
        }

    }
}