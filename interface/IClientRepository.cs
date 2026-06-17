public interface IClientRepository
{
    Task<List<Client>> GetAllClients();

    Task AddClient(Client client);
}