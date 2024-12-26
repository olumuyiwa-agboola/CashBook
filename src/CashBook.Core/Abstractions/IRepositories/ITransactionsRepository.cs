using CashBook.Core.Models;

namespace CashBook.Core.Abstractions.IRepositories;

public interface ITransactionsRepository
{
    Task<List<Transaction>?> GetAllTransactions();

    Task<int> DeleteTransaction(string transactionId);

    Task<int> AddTransaction(Transaction transaction);

    Task<int> UpdateTransaction(Transaction transaction);

    Task<Transaction?> GetTransaction(string transactionId);
}
