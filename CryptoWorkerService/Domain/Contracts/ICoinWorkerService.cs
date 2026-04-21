namespace CryptoWorkerService.Domain.Contracts
{
    public interface ICoinWorkerService
    {
         public Task InsertCoin(CancellationToken cancellationToken = default);
       
    }
}
