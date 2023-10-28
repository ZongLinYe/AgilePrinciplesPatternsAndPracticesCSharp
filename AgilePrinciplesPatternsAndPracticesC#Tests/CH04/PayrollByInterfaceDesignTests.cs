using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgilePrinciplesPatternsAndPracticesC_.CH04.PayrollByInterfaceDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace AgilePrinciplesPatternsAndPracticesC_.CH04.PayrollByInterfaceDesign.Tests
{
    [TestClass()]
    public class PayrollByInterfaceDesignTests
    {
        [TestMethod()]
        public void TestPayroll()
        {
            var db=new MockEmployeeDatabase();
            var w = new MockCheckWriter();
            var p=new PayrollByInterfaceDesign(db,w);
            p.PayEmployee();
            // ???
            //Assert.IsTrue(w.CheckWrittenCorrectly());
            //Assert.IsTrue(db.PaymentsWerePostedCorrectly());
        }
        private class MockEmployeeDatabase : IEmployeeDatabase
        {
            public MockEmployeeDatabase()
            {
            }

            public IEmployee GetEmployee()
            {
                throw new NotImplementedException();
            }

            public bool PutEmployee(IEmployee employee)
            {
                throw new NotImplementedException();
            }
        }

        private class MockCheckWriter :ICheckWriter
        {
            public MockCheckWriter()
            {
            }

            public PayCheck WriteCheck(decimal pay)
            {
                throw new NotImplementedException();
            }
        }

        [TestMethod()]
        public void PayEmployeeTest()
        {


            // chatGpt
            // Arrange
            var employeeDatabase = Substitute.For<IEmployeeDatabase>();
            var checkWriter = Substitute.For<ICheckWriter>();
            var employee = new Employee(); // 實際的 Employee 物件，你可以根據需要設定其行為
            var payCheck = new PayCheck(); // 實際的 PayCheck 物件，你可以根據需要設定其行為

            // 設置模擬行為
            employeeDatabase.GetEmployee().Returns(employee);
            checkWriter.WriteCheck(Arg.Any<decimal>()).Returns(payCheck);

            var payroll = new PayrollByInterfaceDesign(employeeDatabase, checkWriter);

            // Act
            payroll.PayEmployee();

            // Assert
            // 在這裡添加斷言 (assertions) 以驗證 PayEmployee 方法的行為
            employeeDatabase.Received(1).GetEmployee(); // 確保 GetEmployee 方法被呼叫了一次
            checkWriter.Received(1).WriteCheck(Arg.Any<decimal>()); // 確保 WriteCheck 方法被呼叫了一次
            employee.Received(1).PostPayment(payCheck); // 確保 PostPayment 方法被呼叫，且參數為模擬的 payCheck 物件
            employeeDatabase.Received(1).PutEmployee(employee); // 確保 PutEmployee 方法被呼叫，且參數為 employee 物件
        }

 
    }

    [TestClass]
    public class PayrollByInterfaceDesignTests2
    {
        private class MockEmployee : IEmployee
        {
            public decimal CalculatePay()
            {
                return 1000m; // 設定預期的薪資
            }

            public void PostPayment(PayCheck payCheck)
            {
                // 在這裡可以添加測試邏輯
            }
        }

        private class MockCheckWriter : ICheckWriter
        {
            public PayCheck WriteCheck(decimal pay)
            {
                // 返回模擬的 PayCheck 物件
                return new PayCheck();
            }
        }

        private class MockEmployeeDatabase : IEmployeeDatabase
        {
            private IEmployee _employee;
            public MockEmployeeDatabase(IEmployee employee)
            {
                _employee = employee;
            }

            public IEmployee GetEmployee()
            {

                // 返回模擬的 Employee 物件
                return _employee;
            }

            //public bool PutEmployee(Employee employee)
            //{
            //    // 在這裡可以添加測試邏輯
            //    return true;
            //}

            public bool PutEmployee(IEmployee employee)
            {
                throw new NotImplementedException();
            }
        }

        private class MockEmpolyee : IEmployee
        {
            public decimal CalculatePay()
            {
                throw new NotImplementedException();
            }

            public void PostPayment(PayCheck payCheck)
            {
                throw new NotImplementedException();
            }
        }


        [TestMethod]
        public void PayEmployee_Should_PayEmployeeAndPostPayment()
        {
            // Arrange
            var employee = new MockEmployee();
            var employeeDatabase = new MockEmployeeDatabase(employee);
            var checkWriter = new MockCheckWriter();
            var payroll = new PayrollByInterfaceDesign(employeeDatabase, checkWriter);

            // Act
            payroll.PayEmployee();

            // Assert
            // 添加斷言來驗證 PayEmployee 方法的行為
        }
    }
}