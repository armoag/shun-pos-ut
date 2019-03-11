using System;
using System.Collections.Generic;
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
            mysql.Read("a");

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
    }
}
