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
            string result = "0"+(DateTime.Now.Month -1).ToString();
            Assert.Equal(result,Date.getMoisPrecedent());
        }

        [Theory]
        [InlineData("2018-02-01")]    
        public void TestgetMoisPrecedentWithParam(string dateTest)
        {
            DateTime date = DateTime.Parse(dateTest);
            string result = "01";
            Assert.Equal(result,Date.getMoisPrecedent(date));
        }
    }
}
