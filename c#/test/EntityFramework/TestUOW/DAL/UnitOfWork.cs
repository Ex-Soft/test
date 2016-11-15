using System;
using TestUOW.Models;

namespace TestUOW.DAL
{
    public class UnitOfWork : IDisposable
    {
        private TestDbContext context = new TestDbContext();

        private TestMasterRepository testMasterRepository;
        private TestDetailRepository testDetailRepository;
        private GenericRepository<Staff> staffRepository;

        public TestMasterRepository TestMasterRepository
        {
            get
            {

                if (this.testMasterRepository == null)
                {
                    this.testMasterRepository = new TestMasterRepository(context);
                }
                return testMasterRepository;
            }
        }

        public TestDetailRepository TestDetailRepository
        {
            get
            {

                if (this.testDetailRepository == null)
                {
                    this.testDetailRepository = new TestDetailRepository(context);
                }
                return testDetailRepository;
            }
        }

        public GenericRepository<Staff> StaffRepository
        {
            get
            {

                if (this.staffRepository == null)
                {
                    this.staffRepository = new GenericRepository<Staff>(context);
                }
                return staffRepository;
            }
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
