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
            DbConnect database = DbConnect.GetConnect();
            DateTime maintenant = DateTime.Now;
            
            if(Date.entre(1,10,maintenant) == true){
                Console.WriteLine("Nous sommes entre le 1 et 10!");
                string moisPrecedent = Date.getMoisPrecedent(maintenant);

            }
            else{
                Console.WriteLine("Nous ne sommes pas entre le 1 et 10!");
                string moisPrecedent = DateTime.Now.Year.ToString() + Date.getMoisPrecedent(maintenant);
                moisPrecedent = "0000";
                Console.WriteLine(moisPrecedent);
                DataTable test = database.Select("*","fichefrais","");
                Console.WriteLine(test.ToString());
                foreach (DataRow row in test.Rows)
                {

                     Console.WriteLine(row["idetat"]);

                }
            }
        }
    }
}
