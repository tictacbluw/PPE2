using System;
using Xunit;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ppe2
{
    /// <sumary>
    /// Tests Unitaires de la classe Date
    /// </sumary>
    public class UnitTestDate
    {
        /// <sumary>
        /// Test Unitaire de la methode getMoisPrecedent()
        /// </sumary>
        [Fact]
        public void TestgetMoisPrecedent()
        {
            string result = Date.format(DateTime.Now.Month -1).ToString();
            Assert.Equal(result,Date.getMoisPrecedent());
        }

        /// <sumary>
        /// Test Unitaire de la methode getMoisPrecedent(date) 
        /// </sumary>
        ///<param name="dateTest">string date à tester YYYY-MM-DD</param>
        [Theory]
        [InlineData("2018-12-01")]    
        public void TestgetMoisPrecedentWithParam(string dateTest)
        {
            DateTime date = DateTime.Parse(dateTest);
            string result = "11";
            Assert.Equal(result,Date.getMoisPrecedent(date));
        }

        /// <sumary>
        /// Test Unitaire de la methode getMoisSuivant()
        /// </sumary>
        [Fact]
        public void TestgetMoisSuivant()
        {
            string result = Date.format(DateTime.Now.Month +1).ToString();
            Assert.Equal(result,Date.getMoisSuivant());
        }

        /// <sumary>
        /// Test Unitaire de la methode getMoisSuivant(date)
        /// </sumary>
        ///<param name="dateTest">string date à tester YYYY-MM-DD</param>
        [Theory]
        [InlineData("2018-12-01")]    
        public void TestgetMoisSuivantWithParam(string dateTest)
        {
            DateTime date = DateTime.Parse(dateTest);
            string result = "01";
            Assert.Equal(result,Date.getMoisSuivant(date));
        }

        /// <sumary>
        /// Test Unitaire de la methode entre() 
        /// </sumary>
        [Fact]
        public void TestEntre()
        {
            Assert.True(Date.entre(1,31));
        }

        /// <sumary>
        /// Test Unitaire de la methode entre(date)
        /// </sumary>
        ///<param name="dateTest">string date à tester YYYY-MM-DD</param>
        ///<param name="expected">bool résultat attendu</param>
        [Theory]
        [InlineData("2018-12-01",true)] 
        [InlineData("2010-04-18",false)] 

        public void TestEntreWithParams(string dateTest, bool expected)
        {
            DateTime date = DateTime.Parse(dateTest);
            Assert.Equal(expected, Date.entre(1,15,date));
        }

        /// <sumary>
        /// Test Unitaire de la methode format(mois) 
        /// </sumary>
        ///<param name="mois">int mois à formatter</param>
        ///<param name="expected">string résultat attendu</param>
        [Theory]
        [InlineData(1,"01")]
        [InlineData(2,"02")] 
        [InlineData(3,"03")] 
        [InlineData(4,"04")] 
        [InlineData(5,"05")] 
        [InlineData(6,"06")] 
        [InlineData(7,"07")]
        [InlineData(8,"08")] 
        [InlineData(9,"09")]
        [InlineData(10,"10")] 
        [InlineData(11,"11")] 
        [InlineData(12,"12")]    
        public void TestFormat(int mois, string expected)
        {
           
            Assert.Equal(Date.format(mois),expected);
        }

        /// <sumary>
        /// Test Unitaire de la methode checkEstDansInterval(start, end, value) 
        /// </sumary>
        [Fact]
        public void TestCheckEstDansInterval()
        {
           int a = new Random().Next();
           Assert.True(Date.checkEstDansInterval(a-1,a+1,a));
        }
        
    }
}
