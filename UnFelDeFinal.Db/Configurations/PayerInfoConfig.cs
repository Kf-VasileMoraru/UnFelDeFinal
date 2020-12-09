using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternProj.Domain;

namespace InternProj.Db.Configurations
{

    //public class PayerInfoConfig : IEntityTypeConfiguration<ElectronicServicePaymentInfo>
    //{
    //    public void Configure(EntityTypeBuilder<ElectronicServicePaymentInfo> builder)
    //    {
    //        builder.Property(x => x.PayerName).HasMaxLength(100).IsRequired();
    //        builder.Property(x => x.Idnx).HasColumnType("char(13)").IsRequired();
    //        builder.Property(x => x.Amount).HasColumnType("SMALLMONEY").IsRequired();
    //        builder.Property(x => x.DataTime).HasColumnType("DATETIME2").HasDefaultValueSql("GETDATE()");
    //        builder.HasCheckConstraint("CK_PayerInfo_Amount", "Amount Like '%[0-9]%'");
    //        builder.HasCheckConstraint("CK_PayerInfo_Idnx", "Idnx Like '[012]____________'");
    //        builder.HasCheckConstraint("CK_PayerInfo_PayerName", "PayerName Like '%_____%'");
    //    }
    //}
}
