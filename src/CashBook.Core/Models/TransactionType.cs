using System.ComponentModel.DataAnnotations;

namespace CashBook.Core.Models
{
    public enum TransactionType
    {
        [Display(Name = "Income")]
        Income,

        [Display(Name = "Expenditure")]
        Expenditure,

        [Display(Name = "Saving")]
        Saving,

        [Display(Name = "Investment")]
        Investment
    }
}