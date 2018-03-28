using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace PPE2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lancement du programme!");
            DbConnect abc = new DbConnect();
            abc.Connect();
            Dictionary <string, string> data = new Dictionary<string, string>();
            data.Add("nom","Doe");
            data.Add("prenom","John");
            data.Add("login","TESTLOGIN");
            data.Add("mdp","TESTMDP");
            data.Add("idCompte","1");
            DataTable test = abc.Select("nom, prenom","utilisateur", "WHERE idCompte=1");
            foreach (DataRow row in test.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
