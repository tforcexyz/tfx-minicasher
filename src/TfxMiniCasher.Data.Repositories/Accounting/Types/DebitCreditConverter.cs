using System;
using System.Collections.Generic;
using DomainTypes = Xyz.TForce.MiniCasher.Domain.Accounting.Types;

namespace Xyz.TForce.MiniCasher.Data.Repositories.Accounting.Types
{

  public static class DebitCreditConverter
  {

    private static readonly Lazy<IDictionary<DebitCredit, DomainTypes.DebitCredit>> ForwardDictionary = new Lazy<IDictionary<DebitCredit, DomainTypes.DebitCredit>>(() =>
    {
      return new Dictionary<DebitCredit, DomainTypes.DebitCredit>
      {
        { DebitCredit.NotSpecified, DomainTypes.DebitCredit.NotSpecified },
        { DebitCredit.Credit, DomainTypes.DebitCredit.Credit },
        { DebitCredit.Debit, DomainTypes.DebitCredit.Debit },
      };
    });

    private static readonly Lazy<IDictionary<DomainTypes.DebitCredit, DebitCredit>> ReverseDictionary = new Lazy<IDictionary<DomainTypes.DebitCredit, DebitCredit>>(() =>
    {
      return new Dictionary<DomainTypes.DebitCredit, DebitCredit>
      {
        { DomainTypes.DebitCredit.NotSpecified, DebitCredit.NotSpecified },
        { DomainTypes.DebitCredit.Credit, DebitCredit.Credit },
        { DomainTypes.DebitCredit.Debit, DebitCredit.Debit },
      };
    });

    public static DomainTypes.DebitCredit ToDomainType(this DebitCredit type)
    {
      return ForwardDictionary.Value[type];
    }

    public static DebitCredit ToType(this DomainTypes.DebitCredit type)
    {
      return ReverseDictionary.Value[type];
    }
  }
}
