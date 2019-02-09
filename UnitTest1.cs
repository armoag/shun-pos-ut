using System;
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
    }
}
