using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string sqlQuery = @"SELECT 
                    C.reseller_id as ResellerId,
                    O.product_type as ProductType,
                    O.ean as Ean, 
                    O.usage_type as UsageType,
                    O.profile_category as ProfileCategory,
                    O.grid_operator as GridOperator,
                    O.physical_capacity as PhysicalCapacity,
                    O.double_meter as DoubleMeter,
                    O.is_smart_meter as IsSmartMeter,
                    O.is_residence as IsResidence,
                    O.green_energy as IsGreenEnergy,
                    O.green_energy_type_name as GreenEnergyType,
                    C.contract_duration as ContractDuration,
                    O.normal_usage_estimation as UsageAmountNormal,
                    O.dal_usage_estimation as UsageAmountDal,
                    O.single_usage_estimation as UsageAmountSingle,
                    O.return_delivery as ReturnDelivery,
                    O.grid_operator_tariff as GridOperatorTariff,
                    C.start_date as ContractStartDate,
                    C.created_date as ContractCreatedDate
                    FROM kk_order as O, kk_contract as C
                    WHERE O.contract_id = C.id
                    AND O.ean IN ('871687120051667973',
                    '871694840000985858',
                    '871694840002117011',
                    '871692192900785482',
                    '871694840001507653',
                    '871687110001460686',
                    '871687940005195143',
                    '871687940004615338',
                    '871688540030360319',
                    '871687940006053961',
                    '871688540001240558',
                    '871687120053563457',
                    '871687940000619996',
                    '871687120058705234',
                    '871685900005653878',
                    '871688540030356480',
                    '871694840008345173',
                    '871694840000337251',
                    '871688540002997055',
                    '871687120056113000',
                    '871687120056194412',
                    '871688540001524016',
                    '871687110000819508',
                    '871694840008482281',
                    '871694840002117035',
                    '871694840008224126',
                    '871694840008774751',
                    '871688540002033449',
                    '871688540002997529',
                    '871687120054327812',
                    '871687120051106021',
                    '871688540000655872',
                    '871688540030419680',
                    '871688540002414026',
                    '871688540001601014')";

            using (var context = new CoreContext())
            {

                List<PricingEstimationRequestVM> data = context.PricingEstimationRequestVM.FromSqlRaw(sqlQuery).ToListAsync().Result;

                Console.WriteLine("TEst!");
            }
            Console.WriteLine("Done!");
        }

        private static void CallWeb(PricingEstimationRequestVM d)
        {

        }
    }

    


    public class PricingEstimationRequestVMs
    {
        public List<PricingEstimationRequestVM> pricingEstimationRequestVMs { get; set; }
    }

    public class PricingEstimationRequestVM
    {
        public int ResellerId { get; set; }
        public string ProductType { get; set; }
        public string Ean { get; set; }
        public string UsageType { get; set; }
        public string ProfileCategory { get; set; }
        public string GridOperator { get; set; }
        public string PhysicalCapacity { get; set; }
        public string DoubleMeter { get; set; }
        public bool IsSmartMeter { get; set; }
        public bool IsResidence { get; set; }
        public bool IsGreenEnergy { get; set; }
        public string GreenEnergyType { get; set; }
        public string ContractDuration { get; set; }
        public double? UsageAmountNormal { get; set; }
        public double? UsageAmountDal { get; set; }
        public double? UsageAmountSingle { get; set; }
        public double? ReturnDelivery { get; set; }
        public decimal GridOperatorTariff { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractCreatedDate { get; set; }
    }


    public class CoreContext : DbContext
    {
        public virtual DbSet<PricingEstimationRequestVM> PricingEstimationRequestVM { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Necessary, since our model isnt a EF model
            modelBuilder.Entity<PricingEstimationRequestVM>(entity =>
            {
                entity.HasNoKey();
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string mysqlConnection = @"Server=;User Id=root;Password=;port=30885;Database=kikkercorePROD;TreatTinyAsBoolean=false;Convert Zero Datetime=True;Pooling=true;Min Pool Size=3;Max Pool Size=100;Connection Lifetime=0;";
            optionsBuilder.UseMySql(
                        mysqlConnection,
                        mysqlOptions =>
                        {
                            mysqlOptions.ServerVersion(new System.Version("5.7"), ServerType.MySql);
                            mysqlOptions.CharSet(CharSet.Utf8);
                        }
                        );
        }
    }
}
