using Biblioteca.Models.Entidades;
using Biblioteca.Models.Enums;

namespace Biblioteca.Models.Dtos
{
    public class ClienteDto : EntidadeBase
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }
        public string StatusClienteId { get; set; }
        public string Status { get; set; }

        public Cliente ConverterParaEntidade() {
            return new Cliente
            {
                Id = Id,
                Nome = Nome,
                Email = Email,
                Fone = Fone,
                CPF = CPF,
                StatusClienteId = !string.IsNullOrEmpty(StatusClienteId) ? Int32.Parse(StatusClienteId) : StatusCliente.ATIVO.GetHashCode(),
                StatusCliente = !string.IsNullOrEmpty(StatusClienteId) ? GerenciadorDeStatus.PesquisarStatusDoClientePeloId(Int32.Parse(StatusClienteId)) : StatusCliente.ATIVO
            };
        }
    }
}
