using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH04
{
    public class Payroll
    {
        private EmployeeDatabase _employeeDatabase;
        private CheckWriter _checkWriter;
        //private Employee _employee;
        //public Payroll(EmployeeDatabase employeeDatabase, CheckWriter checkWriter,Employee employee)
        //{
        //    _employeeDatabase = employeeDatabase;
        //    _checkWriter = checkWriter;
        //    _employee = employee;
        //}
        public Payroll()
        {
            _employeeDatabase = new EmployeeDatabase();
            _checkWriter = new CheckWriter();
            //_employee = new Employee();
        }
        /// <summary>
        /// User Story: Payroll 類別使用 employeeDatabase 取得員工資料 (Employee 物件)，
        /// 要求 Employee 計算自己的薪水
        /// 把計算結果傳遞給 CheckWriter 物件，產生出一張支票
        /// Empolyee 物件中記錄下支付訊息，並把 Empolyee 物件寫回到資料庫中
        /// 我們要寫 unit test，驗證 Payroll 類別的 PayEmployees() 方法是否正確
        /// 由於 Payroll 類別的 PayEmployees() 方法中，會使用到 EmployeeDatabase & CheckWriter 類別，
        /// 需要使用 Mock 物件來模擬這兩個類別
        /// 但由於 EmployeeDatabase & CheckWriter 類別都是在 Payroll 類別的建構子中被建立出來的，
        /// 要改成使用 Mock 物件，就必須要修改 Payroll 類別的建構子
        /// 如何修改 Payroll 類別的建構子，才能夠讓我們在測試時，使用 Mock 物件來模擬 EmployeeDatabase & CheckWriter 類別呢？
        /// 改成使用建構子注入 (Constructor Injection) 的方式
        /// interface IEmployeeDatabase & interface ICheckWriter
        /// </summary>
        public void PayEmployee()
        {
            var employee=_employeeDatabase.GetEmployee();
            var pay = employee.CalculatePay();
            var payCheck =_checkWriter.WriteCheck(pay);
            employee.PostPayment(payCheck);
            _employeeDatabase.PutEmployee(employee);
        }


    }

    public class EmployeeDatabase
    {
        public EmployeeDatabase()
        {
        }
        public Employee GetEmployee()
        {
            //return new Employee();
            throw new NotImplementedException();
        }
        public bool PutEmployee(Employee employee)
        {
            //return true;
            throw new NotImplementedException();
        }
    }

    public class Employee
    {
        public Employee()
        {
        }
        public decimal CalculatePay()
        {
            throw new NotImplementedException();
        }

        public bool PostPayment(PayCheck payCheck)
        {
            throw new NotImplementedException();
        }
    }

    public class CheckWriter
    {
        public CheckWriter()
        {
        }
        public PayCheck WriteCheck(decimal pay)
        {
            throw new NotImplementedException();
        }

    }

    public class PayCheck
    {
    }
}
