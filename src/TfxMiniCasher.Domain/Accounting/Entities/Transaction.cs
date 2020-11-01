namespace Xyz.TForce.MiniCasher.Domain.Accounting.Entities
{

  public class Transaction
  {

    public long TransactionId { get; set; }

    public string TransactionCode { get; set; }

    public string TransactionName { get; set; }

    public string DebitAccountCode { get; set; }

    public string CreditAccountCode { get; set; }

    public decimal TransactionAmount { get; set; }

    public long IssuedTimeCode { get; set; }
  }
}
