using System.ComponentModel.DataAnnotations;

namespace ProjetoDesenvolvido.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o seu Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o seu Email")]
        [EmailAddress(ErrorMessage = "Informe o e-mail correto")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o sua Idade")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "Informe o seu Cpf")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Informe a sua Empresa")]
        public string Empresa { get; set; }
    }
}
