using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xyz.TForce.Data;

namespace Xyz.TForce.MiniCasher.Data.Repositories.Accounting.Entities.Specifications
{

  public class OptionEntitySpecification : IEntityTypeConfiguration<Option>
  {

    public void Configure(EntityTypeBuilder<Option> builder)
    {
      builder.MapToTable("Accounting_Options");
      builder.PrimaryKey(x => x.Id, isAutoGenerated: true);
      builder.Index(x => x.OptionId, name: "UX_OptionId", isUnique: true);
      builder.Require(x => x.OptionId);
      builder.Index(x => x.OptionCode, name: "UX_OptionCode", isUnique: true);
      builder.MaxLength(x => x.OptionCode, ColumnLengths.KeyLength);
      builder.Require(x => x.OptionCode);
      builder.MaxLength(x => x.OptionName, ColumnLengths.NameLength);
      builder.Require(x => x.OptionName);
      builder.MaxLength(x => x.OptionDescription, ColumnLengths.SummaryLength);
      builder.MaxLength(x => x.OptionGroup, ColumnLengths.KeyLength);
      builder.MaxLength(x => x.LanguageCode, ColumnLengths.KeyLength);
      builder.RowVersion(x => x.MetaRowVersion);
    }
  }
}
