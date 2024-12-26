using System.Data;

namespace CashBook.Core.Abstractions.IFactories
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateTransactionsDbConnection();
    }
}
