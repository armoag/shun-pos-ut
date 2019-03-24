using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
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
            //Insert 1 row, update it, verify data, and then delete it
            var server = "wibsarlicencias.csqn2onotlww.us-east-1.rds.amazonaws.com";
            var database = "Licenses";
            var userID = "armoag";
            var password = "Yadira00";

            var mysql = new MySqlDatabase(server, database, userID, password);
            var test1 = new Tuple<string, string>("LicenseKey", "0x1546ACVFHB");
            var test2 = new Tuple<string, string>("CurrentUser", "TestUserName");
            var test3 = new Tuple<string, string>("Perpetual", "1");
            var dateNow = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");
            var test4 = new Tuple<string, string>("LastCheckIn", dateNow);
            var expDate = new DateTime(2020, 12, 1, 19, 19, 0).ToString("yyyy-MM-dd H:mm:ss");
            var test5 = new Tuple<string, string>("ExpirationDate", expDate);
            var test6 = new Tuple<string, string>("SoftwareName", "Wibsar Retail");
            var test7 = new Tuple<string, string>("SoftwareRevision", "1.1.0");
            var list = new List<Tuple<string, string>> { test1, test2, test3, test4, test5, test6, test7 };

            //Insert
            mysql.Insert(list);
            //Update
            var update1 = new Tuple<string, string>("SoftwareName", "Wibsar Updated");
            var update2 = new Tuple<string, string>("SoftwareRevision", "9.9.9");
            var updateList = new List<Tuple<string, string>>{update1, update2};
            mysql.Update("LicenseKey", "0x1546ACVFHB", updateList);
            //Verify all columns
            mysql.Read(new List<Tuple<string, string>> { new Tuple<string, string>("LicenseKey", "0x1546ACVFHB") }, out var foundData);
            Assert.AreEqual(foundData.First().Item2[6].Item2, "Wibsar Updated");
            Assert.AreEqual(foundData.First().Item2[7].Item2, "9.9.9");

            //Remove
            mysql.Delete("CurrentUser", "TestUserName");
            mysql.Read(new List<Tuple<string, string>> { new Tuple<string, string>("LicenseKey", "0x1546ACVFHB") }, out var foundData2);
            Assert.AreEqual(foundData2.Count, 0);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //Insert 2 rows, verify data, and then delete the same 2 rows
            var server = "wibsarlicencias.csqn2onotlww.us-east-1.rds.amazonaws.com";
            var database = "Licenses";
            var userID = "armoag";
            var password = "Yadira00";

            var mysql = new MySqlDatabase(server, database, userID, password);
            var test1 = new Tuple<string, string>("LicenseKey", "0x1546ACVFHB");
            var test2 = new Tuple<string, string>("CurrentUser", "TestUserName");
            var test3 = new Tuple<string, string>("Perpetual", "1");
            var dateNow = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");
            var test4 = new Tuple<string, string>("LastCheckIn", dateNow);
            var expDate = new DateTime(2020, 12, 1, 19, 19, 0).ToString("yyyy-MM-dd H:mm:ss");
            var test5 = new Tuple<string, string>("ExpirationDate", expDate);
            var test6 = new Tuple<string, string>("SoftwareName", "Wibsar Retail");
            var test7 = new Tuple<string, string>("SoftwareRevision", "1.1.0");
            var list = new List<Tuple<string, string>> {test1, test2, test3, test4, test5, test6, test7};

            //Insert
            mysql.Insert(list);
            //Verify all columns
            mysql.Read(new List<Tuple<string, string>>{new Tuple<string, string>("LicenseKey", "0x1546ACVFHB")}, out var foundData);
            Assert.AreEqual(foundData.First().Item2[1].Item2, "0x1546ACVFHB");
            Assert.AreEqual(foundData.First().Item2[2].Item2, "TestUserName");
            Assert.AreEqual(foundData.First().Item2[3].Item2, "1");
            Assert.AreEqual(DateTime.Parse(foundData.First().Item2[5].Item2), DateTime.Parse(expDate));
            Assert.AreEqual(foundData.First().Item2[6].Item2, "Wibsar Retail");
            Assert.AreEqual(foundData.First().Item2[7].Item2, "1.1.0");

            //Remove
            mysql.Delete("CurrentUser", "TestUserName");
            mysql.Read(new List<Tuple<string, string>> { new Tuple<string, string>("LicenseKey", "0x1546ACVFHB") }, out var foundData2);
            Assert.AreEqual(foundData2.Count, 0);
        }

        [TestMethod]
        public void TestMethod3()
        {


        }
    }
}
