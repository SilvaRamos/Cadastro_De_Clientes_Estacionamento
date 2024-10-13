using System.ComponentModel.DataAnnotations;

namespace Cadastro_De_Clientes_Estacionamento.Models
{
    public class Cliente : IValidatableObject
    {
        public Guid Id { get; set; }
        public int Tipo { get; set; }
        public string? Nome { get; set; }
        public string? Sexo { get; set; }
        public DateOnly? Data_Nascimento { get; set; }
        public string? RG { get; set; }
        public string? Endereco  { get; set; }
        public string? Telefone  { get; set; }
        public string? Celular { get; set; }
        public string? Email { get; set; }
        public string? CPF { get; set; }
        public string? CNPJ { get; set; }
        public string? Razao_Social  { get; set; }
        public string? Nome_Fantasia { get; set; }


    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //Valida Pessoa Física
            if (Tipo == 1)
            {
                if(String.IsNullOrEmpty(CPF))
                    yield return new ValidationResult("O campo 'Cpf' deve ser preenchido", new[] { nameof(CPF) });
                if (String.IsNullOrEmpty(Nome))
                    yield return new ValidationResult("O campo 'Nome' deve ser preenchido", new[] { nameof(Nome) });
            }

            if (Tipo == 2)
            {
                 if(String.IsNullOrEmpty(CNPJ))
                    yield return new ValidationResult("O campo 'Cnpj' deve ser preenchido", new[] { nameof(CNPJ) });
                if (String.IsNullOrEmpty(Razao_Social))
                    yield return new ValidationResult("O campo 'Razão Social' deve ser preenchido", new[] { nameof(CNPJ) });
            }

            //throw new NotImplementedException();
        }
    }
}
