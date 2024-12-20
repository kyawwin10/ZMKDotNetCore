using ATMProject.ConsoleApp;
using Microsoft.Data.SqlClient;
using System.Data;

user users = new user();
//users.Read();
users.Create("Mg Mg", "mgmg@123", 5000.00m, true, DateTime.Now, DateTime.Now);

Console.ReadKey();