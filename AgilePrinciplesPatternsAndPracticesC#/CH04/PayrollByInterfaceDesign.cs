using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH04.PayrollByInterfaceDesign
{
    public class PayrollByInterfaceDesign
    {
        private IEmployeeDatabase _employeeDatabase;
        private ICheckWriter _checkWriter;
        public PayrollByInterfaceDesign(IEmployeeDatabase employeeDatabase, ICheckWriter checkWriter)
        {   
            _employeeDatabase = employeeDatabase;
            _checkWriter = checkWriter;
        }
        public void PayEmployee()
        {
            IEmployee employee = _employeeDatabase.GetEmployee();
            var pay = employee.CalculatePay();
            var payCheck = _checkWriter.WriteCheck(pay);
            employee.PostPayment(payCheck);
            _employeeDatabase.PutEmployee(employee);
        }
    }
    public interface IEmployee
    {
        decimal CalculatePay();
        void PostPayment(PayCheck payCheck);

    }
    public class Employee : IEmployee
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

    public interface ICheckWriter
    {
        PayCheck WriteCheck(decimal pay);
    }

    public class CheckWriter : ICheckWriter
    {
        public CheckWriter()
        {
        }
        public PayCheck WriteCheck(decimal pay)
        {
            throw new NotImplementedException();
        }
    }

    public interface IEmployeeDatabase
    {
        IEmployee GetEmployee();
        bool PutEmployee(IEmployee employee);
    }
    public class EmployeeDatabase : IEmployeeDatabase
    {
           public EmployeeDatabase()
        {
        }
        public IEmployee GetEmployee()
        {
            throw new NotImplementedException();
        }
        //public bool PutEmployee(Employee employee)
        //{
        //    throw new NotImplementedException();
        //}

        public bool PutEmployee(IEmployee employee)
        {
            throw new NotImplementedException();
        }
    }
}
