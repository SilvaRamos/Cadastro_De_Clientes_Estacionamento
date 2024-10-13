using System.ComponentModel.DataAnnotations;

namespace Cadastro_De_Clientes_Estacionamento.Models
{
    public class Pagamento
    {
        public Guid Id { get; set; }

        public Guid ClienteId { get; set; }

        public int mesPagamento { get; set; }

        public decimal valor { get; set; }

        public DateTime dataPagamento { get; set; }
    }
}
