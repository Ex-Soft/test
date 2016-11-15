using TestUOW.Models;

namespace TestUOW.DAL
{
    public class TestDetailRepository : GenericRepository<TestDetail>
    {
        public TestDetailRepository(TestDbContext context) : base(context)
        {
        }
    }
}
