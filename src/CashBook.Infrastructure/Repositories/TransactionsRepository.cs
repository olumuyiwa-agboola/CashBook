using Dapper;
using System.Data;
using CashBook.Core.Models;
using CashBook.Core.Abstractions.IFactories;
using CashBook.Core.Abstractions.IRepositories;

namespace CashBook.Infrastructure.Repositories
{
    public class TransactionsRepository(IDbConnectionFactory _dbConnectionFactory) : ITransactionsRepository
    {
        public async Task<int> AddTransaction(Transaction transaction)
        {
            DynamicParameters parameters = new();

            parameters.Add("Id", transaction.Id);
            parameters.Add("Date", transaction.Date);
            parameters.Add("Type", transaction.Type);
            parameters.Add("Amount", transaction.Amount);
            parameters.Add("Subtype", transaction.Subtype);
            parameters.Add("Description", transaction.Description);

            string query = @"INSERT INTO Transactions (Id, Date, Type, Amount, Subtype, 
                    Description) VALUES (@Id, @Date, @Type, @Amount, @Subtype, @Description)";

            using IDbConnection dbConnection = _dbConnectionFactory.CreateTransactionsDbConnection();

            return await dbConnection.ExecuteAsync(query, parameters);
        }

        public async Task<int> DeleteTransaction(string transactionId)
        {
            DynamicParameters parameters = new();

            parameters.Add("TransactionId", transactionId);

            string query = "DELETE FROM Transactions WHERE Id = @TransactionId";

            using IDbConnection dbConnection = _dbConnectionFactory.CreateTransactionsDbConnection();

            return await dbConnection.ExecuteAsync(query, parameters);
        }

        public async Task<List<Transaction>?> GetAllTransactions()
        {
            string query = "SELECT * FROM Transactions";

            using IDbConnection dbConnection = _dbConnectionFactory.CreateTransactionsDbConnection();

            var transactions = (await dbConnection.QueryAsync<Transaction>(query)).ToList();

            return transactions;
        }

        public async Task<Transaction?> GetTransaction(string transactionId)
        {
            DynamicParameters parameters = new();

            parameters.Add("TransactionId", transactionId);

            string query = "SELECT * FROM Transactions WHERE Id = @TransactionId";

            using IDbConnection dbConnection = _dbConnectionFactory.CreateTransactionsDbConnection();

            Transaction? transaction = (await dbConnection.QueryAsync<Transaction>(query, parameters)).FirstOrDefault();

            return transaction;
        }

        public async Task<int> UpdateTransaction(Transaction transaction)
        {
            DynamicParameters parameters = new();

            parameters.Add("Id", transaction.Id);
            parameters.Add("Date", transaction.Date);
            parameters.Add("Type", transaction.Type);
            parameters.Add("Amount", transaction.Amount);
            parameters.Add("Subtype", transaction.Subtype);
            parameters.Add("Description", transaction.Description);

            string query = @"UPDATE Transactions SET TransactionId = @Id, TransactionDate = @Date, TransactionType = @Type, 
                TransactionAmount = @Amount, TransactionSubtype = @Subtype, TransactionDescription = @Description";

            using IDbConnection dbConnection = _dbConnectionFactory.CreateTransactionsDbConnection();

            return await dbConnection.ExecuteAsync(query, parameters);
        }
    }
}
