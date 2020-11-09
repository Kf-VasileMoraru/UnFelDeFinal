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

        public DbSet<ElectronicServicePaymentInfo> ElectronicServicePaymentInfo { get; set; }
        public DbSet<BillingDetails> BillingDetails { get; set; }
        public DbSet<CityHall> CityHalls { get; set; }
        public DbSet<Iban> Ibans { get; set; }
        public DbSet<ElectronicService> ElectronicService { get; set; }
        public DbSet<AddressCityHall> AddressCityHalls { get; set; }
        public DbSet<ContactCityHall> ContactCityHalls { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<AddressPerson> AddressPeople { get; set; }
        public DbSet<ContactPerson> ContactPeople { get; set; }



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

            modelBuilder.Entity<ElectronicService>().Property(x => x.Name).HasMaxLength(450).IsRequired();
            modelBuilder.Entity<ElectronicService>().Property(x => x.TreasureAccount).HasColumnType("varchar(15)").IsRequired();
            modelBuilder.Entity<ElectronicService>().HasAlternateKey(s => s.TreasureAccount);
            modelBuilder.Entity<ElectronicService>().Property(x => x.Amount).HasColumnType("SMALLMONEY").IsRequired();

            modelBuilder.Entity<BillingDetails>().Property(x => x.IsPayedDataTime).HasColumnType("SMALLDATETIME");
            modelBuilder.Entity<BillingDetails>().Property(x => x.IsPayed).HasDefaultValue(0).IsRequired();


            ////navigation property
            modelBuilder.Entity<CityHall>().HasMany(c => c.BillingDetails)
                .WithOne(s => s.CityHall)
                .HasForeignKey(s => s.CityHallId);

            modelBuilder.Entity<Iban>().HasMany(i => i.BillingDetails)
                .WithOne(s => s.Iban)
                .HasForeignKey(s => s.IbanId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<ElectronicService>().HasMany(s => s.BillingDetails)
                .WithOne(s => s.ElectronicService)
                .HasForeignKey(s => s.ElectronicServiceId);

            modelBuilder.Entity<CityHall>().HasMany(c => c.Iban)
                .WithOne(s => s.CityHall)
                .HasForeignKey(s => s.CityHallId);

            modelBuilder.Entity<ElectronicService>().HasMany(s => s.Iban)
                .WithOne(s => s.ElectronicService)
                .HasForeignKey(s => s.ElectronicServiceId);

            modelBuilder.Entity<ElectronicService>()
                .HasData(
                new ElectronicService() { Id = 1, Name = "test 1 service ", Amount = 20.52m, TreasureAccount = "Treasure1" },
                new ElectronicService() { Id = 2, Name = "test 2 service ", Amount = 12.22m, TreasureAccount = "Treasure2" },
                new ElectronicService() { Id = 3, Name = "test 3 service ", Amount = 22.12m, TreasureAccount = "Treasure3" },
                new ElectronicService() { Id = 4, Name = "test 4 service ", Amount = 2.52m, TreasureAccount = "Treasure4" },
                new ElectronicService() { Id = 5, Name = "test 5 service ", Amount = 44.42m, TreasureAccount = "Treasure5" }
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
                new Iban() { Id = 1, Name = "MD_____________________1", ElectronicServiceId = 1, CityHallId = 1 },
                new Iban() { Id = 2, Name = "MD_____________________2", ElectronicServiceId = 1, CityHallId = 2 },
                new Iban() { Id = 3, Name = "MD_____________________3", ElectronicServiceId = 1, CityHallId = 3 },
                new Iban() { Id = 4, Name = "MD_____________________4", ElectronicServiceId = 1, CityHallId = 4 },
                new Iban() { Id = 5, Name = "MD_____________________5", ElectronicServiceId = 2, CityHallId = 1 },
                new Iban() { Id = 6, Name = "MD_____________________6", ElectronicServiceId = 2, CityHallId = 2 }
                );



            modelBuilder.Entity<ElectronicServicePaymentInfo>()
                .HasData(
                new ElectronicServicePaymentInfo() { Id = 1, PayerName = "payer name 1", Idnx = "0123456789012", PayerType = PayerType.Pers_Fizica, Amount = 20.2m },
                new ElectronicServicePaymentInfo() { Id = 2, PayerName = "payer name 2", Idnx = "0123456789013", PayerType = PayerType.Pers_Juridica, Amount = 10.2m }
                );

            modelBuilder.Entity<BillingDetails>()
               .HasData(
               new BillingDetails() { Id = 1, IsPayed = false, ElectronicServiceId = 1, CityHallId = 1, ElectronicServicePaymentInfoId = 1, IbanId = 1 },
               new BillingDetails() { Id = 2, IsPayed = false, ElectronicServiceId = 2, CityHallId = 2, ElectronicServicePaymentInfoId = 1, IbanId = 2 }

               );
        }

    }
}
