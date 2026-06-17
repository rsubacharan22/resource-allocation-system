namespace EnterprisePlatform.Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<ClientDto>> GetAllClients()
        {
            var clients = await _clientRepository.GetAllClients();

            return clients.Select(client => new ClientDto
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Phone = client.Phone
            }).ToList();
        }

        public async Task AddClient(CreateClientDto createClientDto)
        {
            var client = new Client
            {
                Name = createClientDto.Name,
                Email = createClientDto.Email,
                Phone = createClientDto.Phone
            };

            await _clientRepository.AddClient(client);
        }
    }
}