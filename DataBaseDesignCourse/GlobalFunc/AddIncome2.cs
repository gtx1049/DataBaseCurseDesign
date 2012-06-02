using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DataBaseDesignCourse;

namespace DataBaseDesignCourse.GlobalFunc
{
    class AddIncome2
    {
        private DataManager dataManager = DataManager.createInstance();
        private int allIncome = 0;

        public AddIncome2()
        {
        }
        public int GetAllIncome(int months)
        {
            AllTax allTax = new AllTax();
            AllPlaceSpending allSpending = new AllPlaceSpending();
            AllPoliceSalary allSalary = new AllPoliceSalary();

            dataManager.exeProcessSQL(allTax);
            dataManager.exeProcessSQL(allSpending);
            dataManager.exeProcessSQL(allSalary);

            allIncome = allTax.GetAllTax() - allSpending.GetAllSpending() - allSalary.GetAllSalary();

            return allIncome * months;
        }
    }
    
    class AllTax : Process
    {
        private int allTax = 0;

        public AllTax()
        {
        }
        public override string getSQL()
        {
            return "SELECT SUM(tax) FROM Citizen";
        }
        public override void dealReader(SqlDataReader reader)
        {
            reader.Read();
            allTax = (int)reader.GetValue(0);
        }
        public int GetAllTax()
        {
            return this.allTax;
        }
    }
    class AllPlaceSpending : Process
    {
        private int allSpending = 0;

        public AllPlaceSpending()
        {
        }

        public override string getSQL()
        {
            return "SELECT SUM(spending) FROM Publicplace";
        }
        public override void dealReader(SqlDataReader reader)
        {
            reader.Read();
            allSpending = (int)reader.GetValue(0);
        }
        public int GetAllSpending()
        {
            return this.allSpending;
        }
    }
    class AllPoliceSalary : Process
    {
        private int allSalary = 0;

        public AllPoliceSalary()
        {
        }

        public override string getSQL()
        {
            return "SELECT SUM(salary) FROM Police";
        }
        public override void dealReader(SqlDataReader reader)
        {
            reader.Read();
            allSalary = (int)reader.GetValue(0);
        }
        public int GetAllSalary()
        {
            return this.allSalary;
        }
    }
}
