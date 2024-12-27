using System.ComponentModel.DataAnnotations;

namespace CashBook.Core.Models
{
    public enum TransactionSubtype
    {
        [Display(Name = "Airtime Purchase")]
        AirtimePurchase,

        [Display(Name = "Monthly Salary")]
        MonthlySalary,

        [Display(Name = "Food and Other Edibles")]
        FoodAndEdibles,

        [Display(Name = "Transportation")]
        Transportation
    }
}