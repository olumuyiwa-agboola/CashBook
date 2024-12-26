using System.Data;
using Microsoft.Data.Sqlite;
using CashBook.Core.Utilities.Configuration;
using CashBook.Core.Abstractions.IFactories;

namespace CashBook.Infrastructure.Factories
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection CreateTransactionsDbConnection()
        {
            return new SqliteConnection(AppSettings.ConnectionStrings!.TransactionsDb);
        }
    }
}