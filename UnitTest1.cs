using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var table = "Licenses";
            var userID = "armoag";
            var password = "Yadira00";

            var mysql = new MySqlDatabase(server, database, table, userID, password);
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
            //Update
            var update1 = new Tuple<string, string>("SoftwareName", "Wibsar Updated");
            var update2 = new Tuple<string, string>("SoftwareRevision", "9.9.9");
            var updateList = new List<Tuple<string, string>> {update1, update2};
            mysql.Update("LicenseKey", "0x1546ACVFHB", updateList);
            //Verify all columns
            mysql.Read(new List<Tuple<string, string>> {new Tuple<string, string>("LicenseKey", "0x1546ACVFHB")},
                out var foundData);
            Assert.AreEqual(foundData.First().Item2[6].Item2, "Wibsar Updated");
            Assert.AreEqual(foundData.First().Item2[7].Item2, "9.9.9");

            //Remove
            mysql.Delete("CurrentUser", "TestUserName");
            mysql.Read(new List<Tuple<string, string>> {new Tuple<string, string>("LicenseKey", "0x1546ACVFHB")},
                out var foundData2);
            Assert.AreEqual(foundData2.Count, 0);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //Insert 2 rows, verify data, and then delete the same 2 rows
            var server = "wibsarlicencias.csqn2onotlww.us-east-1.rds.amazonaws.com";
            var database = "Licenses";
            var table = "Licenses";
            var userID = "armoag";
            var password = "Yadira00";

            var mysql = new MySqlDatabase(server, database, table, userID, password);
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
            mysql.Read(new List<Tuple<string, string>> {new Tuple<string, string>("LicenseKey", "0x1546ACVFHB")},
                out var foundData);
            Assert.AreEqual(foundData.First().Item2[1].Item2, "0x1546ACVFHB");
            Assert.AreEqual(foundData.First().Item2[2].Item2, "TestUserName");
            Assert.AreEqual(foundData.First().Item2[3].Item2, "1");
            Assert.AreEqual(DateTime.Parse(foundData.First().Item2[5].Item2), DateTime.Parse(expDate));
            Assert.AreEqual(foundData.First().Item2[6].Item2, "Wibsar Retail");
            Assert.AreEqual(foundData.First().Item2[7].Item2, "1.1.0");

            //Remove
            mysql.Delete("CurrentUser", "TestUserName");
            mysql.Read(new List<Tuple<string, string>> {new Tuple<string, string>("LicenseKey", "0x1546ACVFHB")},
                out var foundData2);
            Assert.AreEqual(foundData2.Count, 0);
        }

        [TestMethod]
        public void TestMethod3()
        {
            //Inventory Table Privileges
            //Insert 2 rows, verify data, and then delete the same 2 rows
            var server = "wibsarlicencias.csqn2onotlww.us-east-1.rds.amazonaws.com";
            var database = "Conteiner";
            //var userID = "conteiner";
            //var password = "Conteiner00!";
            var table = "Inventario";
            var userID = "armoag";
            var password = "Yadira00";

            var mysql = new MySqlDatabase(server, database, table, userID, password);
            var test1 = new Tuple<string, string>("Codigo", "13450001");
            var test2 = new Tuple<string, string>("CodigoAlterno", "NA");
            var test3 = new Tuple<string, string>("ProveedorProductoId", "NA");
            var test4 = new Tuple<string, string>("Descripcion", "Honda Civic puerta izquierda");
            var test5 = new Tuple<string, string>("VIN", "10934709DSDV12450");
            var test6 = new Tuple<string, string>("Marca", "Honda");
            var test7 = new Tuple<string, string>("Modelo", "Honda Civic puerta izquierda");
            var test8 = new Tuple<string, string>("Anho", "2010");
            var test9 = new Tuple<string, string>("Transmision", "Standard");
            var test30 = new Tuple<string, string>("Motor", "2.0T");
            var test10 = new Tuple<string, string>("Color", "Blanco");
            var test11 = new Tuple<string, string>("Proveedor", "SDParts");
            var test12 = new Tuple<string, string>("Categoria", "Carroceria");
            var dateNow = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");
            var test13 = new Tuple<string, string>("UltimoPedidoFecha", dateNow);
            var test14 = new Tuple<string, string>("Costo", "10");
            var test15 = new Tuple<string, string>("CostoMoneda", "USD");
            var test16 = new Tuple<string, string>("CostoImportacion", "2");
            var test17 = new Tuple<string, string>("CostoImportacionMoneda", "USD");
            var test18 = new Tuple<string, string>("Precio", "50");
            var test19 = new Tuple<string, string>("PrecioMoneda", "USD");
            var test20 = new Tuple<string, string>("Ubicacion", "Benton");
            var test21 = new Tuple<string, string>("Pasillo", "1A");
            var test22 = new Tuple<string, string>("CantidadInternoHistorial", "0");
            var test23 = new Tuple<string, string>("CantidadVendidoHistorial", "0");
            var test24 = new Tuple<string, string>("VendidoHistorial", "0");
            var test25 = new Tuple<string, string>("CantidadLocal", "1");
            var test26 = new Tuple<string, string>("CantidadDisponibleTotal", "1");
            var test27 = new Tuple<string, string>("CantidadMinima", "0");
            var expDate = new DateTime(2020, 12, 1, 19, 19, 0).ToString("yyyy-MM-dd H:mm:ss");
            var test28 = new Tuple<string, string>("UltimaTransaccionFecha", expDate);
            var test29 = new Tuple<string, string>("Imagen", "NA.jpg");

            var list = new List<Tuple<string, string>>
            {
                test1,
                test2,
                test3,
                test4,
                test5,
                test6,
                test7,
                test8,
                test9,
                test10,
                test11,
                test12,
                test13,
                test14,
                test15,
                test16,
                test17,
                test18,
                test19,
                test20,
                test21,
                test22,
                test23,
                test24,
                test25,
                test26,
                test27,
                test28,
                test29,
                test30
            };

            //Insert
            mysql.Insert(list);
            //Verify all columns
            mysql.Read(new List<Tuple<string, string>> {new Tuple<string, string>("Codigo", "13450001")},
                out var foundData);
            Assert.AreEqual(foundData.First().Item2[1].Item2, "13450001");
            Assert.AreEqual(foundData.First().Item2[5].Item2, "10934709DSDV12450");
            Assert.AreEqual(foundData.First().Item2[8].Item2, "2010");
            Assert.AreEqual(DateTime.Parse(foundData.First().Item2[14].Item2), DateTime.Parse(dateNow));
            Assert.AreEqual(foundData.First().Item2[15].Item2, "10");

            //Remove
            mysql.Delete("Codigo", "13450001");
            mysql.Read(new List<Tuple<string, string>> {new Tuple<string, string>("Codigo", "13450001")},
                out var foundData2);
            Assert.AreEqual(foundData2.Count, 0);

        }

        [TestMethod]
        public void TestMethod4()
        {
            //Inventory Table Privileges
            //Insert 2 rows, verify data, and then delete the same 2 rows
            var server = "wibsarlicencias.csqn2onotlww.us-east-1.rds.amazonaws.com";
            var database = "ConteinerTest";
            //var userID = "conteiner";
            //var password = "Conteiner00!";
            var table = "Clientes";
            var userID = "armoag";
            var password = "Yadira00";

            var mysql = new MySqlDatabase(server, database, table, userID, password);
            var columns = new List<string>
            {
                "Id",
                "Nombre",
                "Email",
                "Telefono",
                "FechaRegistro",
                "RFC",
                "PuntosDisponibles",
                "PuntosUsados",
                "TotalVisitas",
                "TotalVendido",
                "UltimaVisitaFecha",
                "Codigo"
            };

            var dataTable = mysql.SelectAll(columns);
            var test1 = dataTable.Rows[0];
            var test2 = test1["RFC"].ToString();
            var test3 = dataTable.Rows[1];
            var test4 = test3["UltimaVisitaFecha"].ToString();
        }

        [TestMethod]
        public void TestMethod5()
        {
            //Inventory Table Privileges
            //Insert 2 rows, verify data, and then delete the same 2 rows
            var server = "wibsarlicencias.csqn2onotlww.us-east-1.rds.amazonaws.com";
            var database = "EstrellaTest";
            var table = "Inventario";
            var userID = "armoag";
            var password = "Yadira00";

            var mysql = new MySqlDatabase(server, database, table, userID, password);
            List<string> data = new List<string>()
            {
                "Id",
                "Codigo",
                "CodigoAlterno",
                "ProveedorProductoId",
                "Descripcion",
                "Proveedor",
                "Categoria",
                "Costo",
                "CostoMoneda",
                "Precio",
                "PrecioMoneda",
                "CantidadInternoHistorial",
                "CantidadVendidoHistorial",
                "VendidoHistorial",
                "CantidadLocal",
                "CantidadDisponibleTotal",
                "CantidadMinima",
                "Imagen"
            };

            List<string> longData = new List<string>()
            {
                "Id",
                "Codigo",
                "CodigoAlterno",
                "ProveedorProductoId",
                "Descripcion",
                "Proveedor",
                "Categoria",
                "UltimoPedidoFecha",
                "Costo",
                "CostoMoneda",
                "Precio",
                "PrecioMoneda",
                "CantidadInternoHistorial",
                "CantidadVendidoHistorial",
                "VendidoHistorial",
                "CantidadLocal",
                "CantidadDisponibleTotal",
                "CantidadMinima",
                "UltimaTransaccionFecha",
                "Imagen"
            };

            List<int> dataIndex = new List<int>()
            {
                1, 4, 6, 10, 11, 15, 16
            };

            var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here
            var dataTable = mysql.Select(longData);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            watch.Start();
            var longDataTable = mysql.Select(data);
            watch.Stop();
            var elapsedMs2 = watch.ElapsedMilliseconds;
        }

        [TestMethod]
        public void TestMethod6()
        {
            ////Entity Framework Testing
            //Database.SetInitializer<DemoContext>(new DropCreateDatabaseAlways<DemoContext>());
            //Console.WriteLine("Inserting registers");
            //var dbContext = new DemoContext();
            //Person person = new Person();
            //person.Name = "arturo";
            //person.Birthdate = new DateTime(1987,10,03);
            //person.Id = 1;
            //person.Age = 32;

            //Person person2 = new Person();
            //person.Name = "yadira";
            //person.Birthdate = new DateTime(1987, 03, 31);
            //person.Id = 1;
            //person.Age = 32;
            //dbContext.People.Add(person);
            //dbContext.People.Add(person2);

            //dbContext.SaveChanges();

            //var peopleList = from p in dbContext.People select p;
            //foreach (var p in peopleList)
            //{
            //    Console.WriteLine(p);
            //}


            //Console.ReadLine();
        }

        [TestMethod]
        public void TestMethod7()
        {

        }

        [TestMethod]
        public void TestMethod8()
        {
            //Insert 2 rows, verify data, and then delete the same 2 rows
            var server = "wibsarlicencias.csqn2onotlww.us-east-1.rds.amazonaws.com";
            var database = @"C:\Projects\wibsar-pos-solution\shun-pos\PosDB.db";
            var table = "Customers";
            var userID = "armoag";
            var password = "Yadira00";

            var mysql = new SqliteDatabase(server, database, table, userID, password);
            var test1 = new Tuple<string, string>("Nombre", "Arturo");
            var test2 = new Tuple<string, string>("Codigo", "123456c");
            var dateNow = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");
            var test3 = new Tuple<string, string>("FechaRegistro", dateNow);
            var test4 = new Tuple<string, string>("Telefono", "6192077187");
            var list = new List<Tuple<string, string>> { test1, test2, test3, test4 };

            //Insert
            mysql.Insert(list);
            //Verify all columns
            mysql.Read("Codigo", "123456b", out var foundData1);

            //mysql.Read(new List<Tuple<string, string>> { new Tuple<string, string>("Nombre", "Arturo") },
            //    out var foundData);
            Assert.AreEqual(foundData1.First().Item2[1].Item2, "Arturo");
            Assert.AreEqual(foundData1.First().Item2[2].Item2, "123456b");

            //Remove
            mysql.Delete("Nombre", "Arturo");
            mysql.Read("Codigo", "123456b", out var foundData2);
            Assert.AreEqual(foundData2.Count, 0);
        }
    }
}
    