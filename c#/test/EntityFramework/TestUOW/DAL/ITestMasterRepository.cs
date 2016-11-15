using System;
using System.Collections.Generic;
using TestUOW.Models;

namespace TestUOW.DAL
{
    public interface ITestMasterRepository : IDisposable
    {
        IEnumerable<TestMaster> GetTestMasters();
        TestMaster GetTestMasterByID(int testMasterId);
        void InsertTestMaster(TestMaster testMaster);
        void DeleteTestMaster(int testMasterID);
        void UpdateTestMaster(TestMaster testMaster);
        void Save();
    }
}
