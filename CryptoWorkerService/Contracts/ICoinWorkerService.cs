namespace CryptoWorkerService.Contracts
{
    public interface ICoinWorkerService
    {
         public Task UpdateCoins(CancellationToken cancellationToken = default);
       
    }
}
