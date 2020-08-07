using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestUOW.Models;

namespace TestUOW.DAL
{
    public class TestMasterRepository : ITestMasterRepository
    {
        private TestDbContext context;

        public TestMasterRepository(TestDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<TestMaster> GetTestMasters()
        {
            return context.TestMasters.ToList();
        }

        public TestMaster GetTestMasterByID(int id)
        {
            return context.TestMasters.Find(id);
        }

        public void InsertTestMaster(TestMaster testMaster)
        {
            context.TestMasters.Add(testMaster);
        }

        public void DeleteTestMaster(int testMasterID)
        {
            TestMaster testMaster = context.TestMasters.Find(testMasterID);
            context.TestMasters.Remove(testMaster);
        }

        public void UpdateTestMaster(TestMaster testMaster)
        {
            context.Entry(testMaster).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
