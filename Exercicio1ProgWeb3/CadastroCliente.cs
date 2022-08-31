using System.ComponentModel.DataAnnotations;
using Microsoft.Win32.SafeHandles;

namespace Exercicio1ProgWeb3
{
    public class CadastroCliente
    {
        [Required(ErrorMessage = "Nome obrigat�rio")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "CPF obrigat�rio")]
        [RegularExpression("([0-9]+)", ErrorMessage = "O CPF deve conter apenas n�meros")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 n�meros")]
        public string? Cpf { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento � Obrigat�ria")]
        [DataType(DataType.Date)]
        public DateTime? Nascimento { get; set; }

        [Range(18, int.MaxValue, ErrorMessage = "Voc� deve ter mais de 18 anos para se cadastrar")]
        public int? Idade { get { return CalcularIdade(); } }

        public int CalcularIdade()
        {
            int idade = Nascimento.HasValue ? DateTime.Now.Year - Nascimento.Value.Year : 0;
            
            if (Nascimento.HasValue && 
                DateTime.Now.DayOfYear < Nascimento.Value.DayOfYear)
                idade--;

            return idade;
        }
    }
}