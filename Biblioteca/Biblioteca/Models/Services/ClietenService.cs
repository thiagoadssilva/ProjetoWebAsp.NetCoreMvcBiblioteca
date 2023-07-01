using Biblioteca.Models.Contracts.Repositories;
using Biblioteca.Models.Contracts.Services;
using Biblioteca.Models.Dtos;
using Biblioteca.Models.Repositories;

namespace Biblioteca.Models.Services
{
    public class ClietenService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClietenService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void Atualizar(ClienteDto cliente)
        {
            try
            {
                var objCliente = cliente.ConverterParaEntidade();
                _clienteRepository.Atualizar(objCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Cadastrar(ClienteDto cliente)
        {
            try
            {
                var objCliente = cliente.ConverterParaEntidade();
                objCliente.Cadastrar();
                _clienteRepository.Cadastrar(objCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(string id)
        {
            try
            {
                _clienteRepository.Excluir(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClienteDto> Listar()
        {
            try
            {
                var clientesDto = new List<ClienteDto>();
                var clientes = _clienteRepository.Listar();

                foreach (var item in clientes)
                {
                    clientesDto.Add(item.ConverterParaDto());
                }

                return clientesDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteDto PesquisarPorId(string id)
        {
            try
            {
                var cliente = _clienteRepository.PesquisarPorId(id);
                return cliente.ConverterParaDto();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
