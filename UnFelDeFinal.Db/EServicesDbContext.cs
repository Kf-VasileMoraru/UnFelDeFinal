using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnFelDeFinal.Db.Configurations;
using UnFelDeFinal.Domain;

namespace UnFelDeFinal.Db
{
    public class EServicesDbContext : DbContext
    {
        private const string _connectionString = @"Data Source=MDDSK40119;Initial Catalog=UnFelDeFinal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public DbSet<PayerInfo> PayerInfo { get; set; }
        public DbSet<ServiceList> ServiceList { get; set; }
        public DbSet<CityHall> CityHalls { get; set; }
        public DbSet<Iban> Ibans { get; set; }
        public DbSet<Eservice> Eservices { get; set; }


        public EServicesDbContext() { }
        public EServicesDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(_connectionString)
                .ConfigureWarnings(wornings => wornings.Throw(CoreEventId.IncludeIgnoredWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PayerInfoConfig());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(EServicesDbContext)));

            modelBuilder.Entity<CityHall>(entity =>
                entity.HasCheckConstraint("CK_CityHall_Name", "Name Like '%___%'"));

            modelBuilder.Entity<Iban>().Property(x => x.Name).HasColumnType("char(24)").IsRequired();
            modelBuilder.Entity<Iban>(entity =>
                entity.HasCheckConstraint("CQ_Iban_Name", "Name Like 'MD______________________'"));

            modelBuilder.Entity<Eservice>().Property(x => x.Name).HasMaxLength(450).IsRequired();
            modelBuilder.Entity<Eservice>().Property(x => x.TreasureAccount).HasColumnType("varchar(15)").IsRequired();
            modelBuilder.Entity<Eservice>().HasAlternateKey(s => s.TreasureAccount);
            modelBuilder.Entity<Eservice>().Property(x => x.Amount).HasColumnType("SMALLMONEY").IsRequired();

            modelBuilder.Entity<ServiceList>().Property(x => x.IsPayedDataTime).HasColumnType("SMALLDATETIME");
            modelBuilder.Entity<ServiceList>().Property(x => x.IsPayed).HasDefaultValue(0).IsRequired();


            ////navigation property
            modelBuilder.Entity<CityHall>().HasMany(c => c.ServiceLists)
                .WithOne(s => s.CityHall)
                .HasForeignKey(s => s.CityHallId);

            modelBuilder.Entity<Iban>().HasMany(i => i.ServiceLists)
                .WithOne(s => s.Iban)
                .HasForeignKey(s => s.IbanId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Eservice>().HasMany(s => s.ServiceLists)
                .WithOne(s => s.Service)
                .HasForeignKey(s => s.ServiceId);

            modelBuilder.Entity<CityHall>().HasMany(c => c.Iban)
                .WithOne(s => s.CityHall)
                .HasForeignKey(s => s.CityHallId);

            modelBuilder.Entity<Eservice>().HasMany(s => s.Iban)
                .WithOne(s => s.Service)
                .HasForeignKey(s => s.ServiceId);

            modelBuilder.Entity<Eservice>()
                .HasData(
                new Eservice() { Id = 1, Name = "test 1 service ", Amount = 20.52m, TreasureAccount = "Treasure1" },
                new Eservice() { Id = 2, Name = "test 2 service ", Amount = 12.22m, TreasureAccount = "Treasure2" },
                new Eservice() { Id = 3, Name = "test 3 service ", Amount = 22.12m, TreasureAccount = "Treasure3" },
                new Eservice() { Id = 4, Name = "test 4 service ", Amount = 2.52m, TreasureAccount = "Treasure4" },
                new Eservice() { Id = 5, Name = "test 5 service ", Amount = 44.42m, TreasureAccount = "Treasure5" }
                );


            modelBuilder.Entity<CityHall>()
                .HasData(
                new CityHall() { Id = 1, Name = "Ciorescu", BanckAccount = "BanckAccount1" },
                new CityHall() { Id = 2, Name = "Bacioi", BanckAccount = "BanckAccount2" },
                new CityHall() { Id = 3, Name = "Bubuieci", BanckAccount = "BanckAccount3" },
                new CityHall() { Id = 4, Name = "Budesti", BanckAccount = "BanckAccount4" }
                );

            modelBuilder.Entity<Iban>()
                .HasData(
                new Iban() { Id = 1, Name = "MD_____________________1", ServiceId = 1, CityHallId = 1 },
                new Iban() { Id = 2, Name = "MD_____________________2", ServiceId = 1, CityHallId = 2 },
                new Iban() { Id = 3, Name = "MD_____________________3", ServiceId = 1, CityHallId = 3 },
                new Iban() { Id = 4, Name = "MD_____________________4", ServiceId = 1, CityHallId = 4 },
                new Iban() { Id = 5, Name = "MD_____________________5", ServiceId = 2, CityHallId = 1 },
                new Iban() { Id = 6, Name = "MD_____________________6", ServiceId = 2, CityHallId = 2 }
                );



            modelBuilder.Entity<PayerInfo>()
                .HasData(
                new PayerInfo() { Id = 1, PayerName = "payer name 1", Idnx = "0123456789012", PayerType = PayerType.Pers_Fizica, Amount = 20.2f },
                new PayerInfo() { Id = 2, PayerName = "payer name 2", Idnx = "0123456789013", PayerType = PayerType.Pers_Juridica, Amount = 10.2f }
                );

            modelBuilder.Entity<ServiceList>()
               .HasData(
               new ServiceList() { Id = 1, IsPayed = false, ServiceId = 1, CityHallId = 1, PayerInfoId = 1, IbanId = 1 },
               new ServiceList() { Id = 2, IsPayed = false, ServiceId = 2, CityHallId = 2, PayerInfoId = 1, IbanId = 2 }

               );
        }

    }
}
