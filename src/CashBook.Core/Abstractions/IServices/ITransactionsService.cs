using CashBook.Core.Models;

namespace CashBook.Core.Abstractions.IServices
{
    public interface ITransactionsService
    {
        Task<List<Transaction>?> GetAllTransactions();

        Task<int> DeleteTransaction(string transactionId);

        Task<int> UpdateTransaction(Transaction transaction);

        Task<Transaction?> GetTransaction(string transactionId);

        Task<int> CreateTransaction(Transaction transaction);
    }
}