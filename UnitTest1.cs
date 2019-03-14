using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shun;

namespace ShunUT
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var server = "wibsarlicencias.csqn2onotlww.us-east-1.rds.amazonaws.com";
            var database = "Licenses";
            var userID = "armoag";
            var password = "Yadira00";

            var mysql = new MySqlDatabase(server, database, userID, password);

            var x = 1;
        }

        [TestMethod]
        public void TestMethod2()
        {
            var server = "wibsarlicencias.csqn2onotlww.us-east-1.rds.amazonaws.com";
            var database = "Licenses";
            var userID = "armoag";
            var password = "Yadira00";

            var mysql = new MySqlDatabase(server, database, userID, password);
            var test1 = new Tuple<string, string>("LicenseKey", "ABC");
            var test2 = new Tuple<string, string>("CurrentUser", "YadiraLeonaDormida");
            var list = new List<Tuple<string, string>>();
            list.Add(test1);
            list.Add(test2);
            mysql.Insert(list);

            var x = 1;
        }

        [TestMethod]
        public void TestMethod3()
        {
            //Insert 2 rows, verify data, and then delete the same 2 rows
            var server = "wibsarlicencias.csqn2onotlww.us-east-1.rds.amazonaws.com";
            var database = "Licenses";
            var userID = "armoag";
            var password = "Yadira00";

            var mysql = new MySqlDatabase(server, database, userID, password);
            var test1 = new Tuple<string, string>("LicenseKey", "0x1546ACVFHB");
            var test2 = new Tuple<string, string>("CurrentUser", "TestUserName");
            var list = new List<Tuple<string, string>> {test1, test2};

            //Insert
            mysql.Insert(list);
            //Verify
            mysql.Read("0x1546ACVFHB", out var foundData);
            Assert.AreEqual(foundData.First().Item2, "TestUserName");
            //Remove
            mysql.Delete("CurrentUser", "TestUserName");
            mysql.Read("0x1546ACVFHB", out var foundData2);
            Assert.IsNull(foundData2.First().Item2, "TestUserName");
        }

        [TestMethod]
        public void TestMethod4()
        {

        }

        [TestMethod]
        public void TestMethod5()
        {

        }

        [TestMethod]
        public void TestMethod6()
        {

        }

        [TestMethod]
        public void TestMethod7()
        {

        }

        [TestMethod]
        public void TestMethod8()
        {

        }

        [TestMethod]
        public void TestMethod9()
        {

        }

        [TestMethod]
        public void TestMethod10()
        {

        }

    }
}
