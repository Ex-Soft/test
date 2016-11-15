using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TestDB.Models.Mapping;

namespace TestDB.Models
{
    public partial class testdbContext : DbContext
    {
        static testdbContext()
        {
            Database.SetInitializer<testdbContext>(null);
        }

        public testdbContext()
            : base("Name=testdbContext")
        {
        }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<TableWithHierarchy> TableWithHierarchies { get; set; }
        public DbSet<TableWithImgSrc> TableWithImgSrcs { get; set; }
        public DbSet<TableWithTrigger1> TableWithTrigger1 { get; set; }
        public DbSet<TableWithTrigger1WD> TableWithTrigger1WD { get; set; }
        public DbSet<TableWithTrigger2> TableWithTrigger2 { get; set; }
        public DbSet<TableWithTrigger2WD> TableWithTrigger2WD { get; set; }
        public DbSet<TableWithTriggerAfter> TableWithTriggerAfters { get; set; }
        public DbSet<TableWithTriggerAfterStub> TableWithTriggerAfterStubs { get; set; }
        public DbSet<TableWithTriggerIUD> TableWithTriggerIUDs { get; set; }
        public DbSet<TableWithTriggerIUDHistory> TableWithTriggerIUDHistories { get; set; }
        public DbSet<TableWithTriggerU> TableWithTriggerUs { get; set; }
        public DbSet<TestAllAnyDepartment> TestAllAnyDepartments { get; set; }
        public DbSet<TestAllAnyEmployee> TestAllAnyEmployees { get; set; }
        public DbSet<TestDE> TestDEs { get; set; }
        public DbSet<TestDetail> TestDetails { get; set; }
        public DbSet<TestDuplicate> TestDuplicates { get; set; }
        public DbSet<TestMaster> TestMasters { get; set; }
        public DbSet<TestTable4ApplyI> TestTable4ApplyI { get; set; }
        public DbSet<TestTable4ApplyII> TestTable4ApplyII { get; set; }
        public DbSet<TestTable4IUDDest> TestTable4IUDDest { get; set; }
        public DbSet<TestTable4IUDSrc> TestTable4IUDSrc { get; set; }
        public DbSet<TestTable4Types> TestTable4Types { get; set; }
        public DbSet<TestTableWDefault> TestTableWDefaults { get; set; }
        public DbSet<TestTableWithNullField> TestTableWithNullFields { get; set; }
        public DbSet<Victim> Victims { get; set; }
        public DbSet<XPObjectType> XPObjectTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StaffMap());
            modelBuilder.Configurations.Add(new TableWithHierarchyMap());
            modelBuilder.Configurations.Add(new TableWithImgSrcMap());
            modelBuilder.Configurations.Add(new TableWithTrigger1Map());
            modelBuilder.Configurations.Add(new TableWithTrigger1WDMap());
            modelBuilder.Configurations.Add(new TableWithTrigger2Map());
            modelBuilder.Configurations.Add(new TableWithTrigger2WDMap());
            modelBuilder.Configurations.Add(new TableWithTriggerAfterMap());
            modelBuilder.Configurations.Add(new TableWithTriggerAfterStubMap());
            modelBuilder.Configurations.Add(new TableWithTriggerIUDMap());
            modelBuilder.Configurations.Add(new TableWithTriggerIUDHistoryMap());
            modelBuilder.Configurations.Add(new TableWithTriggerUMap());
            modelBuilder.Configurations.Add(new TestAllAnyDepartmentMap());
            modelBuilder.Configurations.Add(new TestAllAnyEmployeeMap());
            modelBuilder.Configurations.Add(new TestDEMap());
            modelBuilder.Configurations.Add(new TestDetailMap());
            modelBuilder.Configurations.Add(new TestDuplicateMap());
            modelBuilder.Configurations.Add(new TestMasterMap());
            modelBuilder.Configurations.Add(new TestTable4ApplyIMap());
            modelBuilder.Configurations.Add(new TestTable4ApplyIIMap());
            modelBuilder.Configurations.Add(new TestTable4IUDDestMap());
            modelBuilder.Configurations.Add(new TestTable4IUDSrcMap());
            modelBuilder.Configurations.Add(new TestTable4TypesMap());
            modelBuilder.Configurations.Add(new TestTableWDefaultMap());
            modelBuilder.Configurations.Add(new TestTableWithNullFieldMap());
            modelBuilder.Configurations.Add(new VictimMap());
            modelBuilder.Configurations.Add(new XPObjectTypeMap());
        }
    }
}
