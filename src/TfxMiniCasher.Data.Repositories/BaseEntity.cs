namespace Xyz.TForce.MiniCasher.Data.Repositories
{

  public abstract class BaseEntity : IEntityAutoId
  {

    public long Id { get; set; }
  }
}
