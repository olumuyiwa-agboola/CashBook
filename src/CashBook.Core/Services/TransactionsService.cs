using CashBook.Core.Models;
using CashBook.Core.Abstractions.IServices;
using CashBook.Core.Abstractions.IRepositories;

namespace CashBook.Core.Services
{
    public class TransactionsService(ITransactionsRepository _transactionsRepository) : ITransactionsService
    {
        public async Task<int> CreateTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteTransaction(string transactionId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Transaction>?> GetAllTransactions()
        {
            return await _transactionsRepository.GetAllTransactions();
        }

        public async Task<Transaction?> GetTransaction(string transactionId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}