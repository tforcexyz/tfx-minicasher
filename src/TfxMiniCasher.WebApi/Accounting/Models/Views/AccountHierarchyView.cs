using System;
using System.Collections.Generic;

namespace Xyz.TForce.MiniCasher.WebApi.Accounting.Models.Views
{

  public class AccountHierarchyView
  {

    public Guid Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public ICollection<AccountHierarchyView> Children { get; set; }
  }
}
