using Microsoft.EntityFrameworkCore;

public class ClientRepository : IClientRepository
{
    private readonly AppDbContext _dbContext = null!;

    public ClientRepository(AppDbContext context)
    {
        _dbContext = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<Client>> GetAllClients()
    {
        return await _dbContext.Clients.ToListAsync();
    }

    public async Task AddClient(Client client)
    {
        await _dbContext.Clients.AddAsync(client);

        await _dbContext.SaveChangesAsync();
    }
}
