namespace CashBook.Core.Models
{
    public record Transaction
    {
        public string? Id { get; set; }

        public string? Date { get; init; }

        public float Amount { get; init; }

        public string? Type { get; init; }

        public string? Subtype { get; init; }

        public string? Description { get; init; }
    }
}