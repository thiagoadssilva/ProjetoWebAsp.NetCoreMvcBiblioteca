using Biblioteca.Models.Dtos;
using Biblioteca.Models.Enums;

namespace Biblioteca.Models.Entidades
{
    public class Cliente : EntidadeBase
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }
        public int StatusClienteId { get; set; }
        public StatusCliente StatusCliente { get; set; }

        public void Cadastrar()
        {
            StatusCliente = StatusCliente.ATIVO;
            StatusClienteId = StatusCliente.GetHashCode();
        }

        public ClienteDto ConverterParaDto()
        {
            return new ClienteDto
            {
                Id = Id,
                Nome = Nome,
                Email = Email,
                Fone = Fone,
                CPF = CPF,
                StatusClienteId = StatusClienteId.ToString(),
                Status = GerenciadorDeStatus.PesquisarStatusDoClientePeloId(StatusClienteId).ToString()
            };
        }

    }
}
