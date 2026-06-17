public interface IClientService
{
    Task<List<ClientDto>> GetAllClients();
    Task AddClient(CreateClientDto clientDto);
}