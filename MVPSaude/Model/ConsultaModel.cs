using Fiap.Api.MVPSaude.Model;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.MVPSaude.Models
{

    [Table("CONSULTA")]
    public class ConsultaModel
    {
        [HiddenInput]
        [Key]
        [Column("CONSULTAID")]
        public int ConsultaId { get; set; }

        [Display(Name = "Paciente")]
        [Column("PACIENTEID")]
        public int PacienteId { get; set; }
        public PacienteModel? Paciente { get; set; }

        [Display(Name = "Médico")]
        [Column("MEDICOID")]
        public int MedicoId { get; set; }
        public MedicoModel? Medico { get; set; }

        [Display(Name = "Data da Consulta")]
        [Required(ErrorMessage = "Data da consulta é obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "Data da consulta inválida")]
        [Column("DATACONSULTA")]
        public DateTime DataConsulta { get; set; }

        [Column("HORACONSULTA")]
        [StringLength(30,
         MinimumLength = 1,
         ErrorMessage = "A hora da consulta deve ter, no mínimo, 1 e, no máximo, 30 caracteres")]
        [Display(Name = "Hora")]
        public string? HoraConsulta { get; set; }


        [Column("LOCALCONSULTA")]
        [StringLength(255,
          MinimumLength = 1,
          ErrorMessage = "O endereço deve ter, no mínimo, 1 e, no máximo, 30 caracteres")]
        [Display(Name = "Local Consulta")]
        public string? LocalConsulta { get; set; }

        [Column("MENSAGEM")]
        [StringLength(4000,
          MinimumLength = 1,
          ErrorMessage = "A mensagem deve ter, no mínimo, 1 e, no máximo, 4000 caracteres")]
        [Display(Name = "Mensagem")]
        public string? Mensagem { get; set; }

        public ConsultaModel()
        {
        }

        public ConsultaModel(int consultaId, int pacienteId, PacienteModel? paciente, int medicoId, MedicoModel? medico, DateTime dataConsulta, string? horaConsulta, string? localConsulta, string? mensagem)
        {
            ConsultaId = consultaId;
            PacienteId = pacienteId;
            Paciente = paciente;
            MedicoId = medicoId;
            Medico = medico;
            DataConsulta = dataConsulta;
            HoraConsulta = horaConsulta;
            LocalConsulta = localConsulta;
            Mensagem = mensagem;
        }
    }
}