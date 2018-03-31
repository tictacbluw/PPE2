using System;
using Xunit;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ppe2
{
    public class UnitTestDate
    {
        [Fact]
        public void TestgetMoisPrecedent()
        {
            string result = Date.format(DateTime.Now.Month -1).ToString();
            Assert.Equal(result,Date.getMoisPrecedent());
        }

        [Theory]
        [InlineData("2018-12-01")]    
        public void TestgetMoisPrecedentWithParam(string dateTest)
        {
            DateTime date = DateTime.Parse(dateTest);
            string result = "11";
            Assert.Equal(result,Date.getMoisPrecedent(date));
        }

        [Fact]
        public void TestgetMoisSuivant()
        {
            string result = Date.format(DateTime.Now.Month +1).ToString();
            Assert.Equal(result,Date.getMoisSuivant());
        }

        [Theory]
        [InlineData("2018-12-01")]    
        public void TestgetMoisSuivantWithParam(string dateTest)
        {
            DateTime date = DateTime.Parse(dateTest);
            string result = "01";
            Assert.Equal(result,Date.getMoisSuivant(date));
        }

        [Fact]
        public void TestEntre()
        {
            Assert.True(Date.entre(1,31));
        }

        [Theory]
        [InlineData("2018-12-01")] 
        public void TestEntreWithParams(string dateTest)
        {
            DateTime date = DateTime.Parse(dateTest);
            Assert.True(Date.entre(1,31,date));
        }

        [Fact]
        public void TestFormat()
        {
            string result = Date.format(10).ToString();
            Assert.Equal("10",result);
        }

        [Fact]
        public void TestCheckEstDansInterval()
        {
           int a = new Random().Next();
           Assert.True(Date.checkEstDansInterval(a-1,a+1,a));
        }
        
    }
}
