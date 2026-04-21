namespace CryptoWorkerService.Domain.Contracts
{
    public interface ICoinWorkerService
    {
         public Task UpdateCoins(CancellationToken cancellationToken = default);
       
    }
}
