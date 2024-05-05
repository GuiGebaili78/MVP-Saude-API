using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.MVPSaude.Models
{

    [Table("USUARIO")]
    public class UsuarioModel
    {
        [HiddenInput]
        [Key]
        [Column("USUARIOID")]
        public int UsuarioId { get; set; }

        [Column("NOMEUSUARIO")]
        [Required(ErrorMessage = "Nome do usuário é obrigatório!")]
        [StringLength(255,
            MinimumLength = 2,
            ErrorMessage = "O nome deve ter, no mínimo, 2 e, no máximo, 255 caracteres")]
        [Display(Name = "Nome do Usuário")]
        public string? NomeUsuario { get; set; }

        [Column("SENHAUSUARIO")]
        [Required(ErrorMessage = "Senha é obrigatório!")]
        [StringLength(128,
          MinimumLength = 1,
          ErrorMessage = "A senha deve ter, no mínimo, 1 e, no máximo, 128 caracteres")]
        [Display(Name = "Senha")]
        public string? SenhaUsuario { get; set; }

        [Column("EMAILUSUARIO")]
        [Required(ErrorMessage = "Email é obrigatório!")]
        [StringLength(255,
          MinimumLength = 1,
          ErrorMessage = "O email deve ter, no mínimo, 1 e, no máximo, 255 caracteres")]
        [Display(Name = "Email")]
        public string? EmailUsuario { get; set; }

        public UsuarioModel()
        {
        }

        public UsuarioModel(int usuarioId, string? nomeUsuario)
        {
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
        }
    }
}