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
            DbConnect database = DbConnect.GetConnect();
            DateTime maintenant = DateTime.Now;
            string moisPrecedent = DateTime.Now.Year.ToString() + Date.getMoisPrecedent(maintenant);
            if(Date.entre(1,10,maintenant) == true){
                Dictionary <string, string> tmp = new Dictionary <string, string>();
                tmp.Add("idetat","CR");
                database.Update("fichefrais",tmp,"WHERE mois='"+moisPrecedent+"'");

            }
            if(Date.entre(20,31,maintenant) == true){
                Dictionary <string, string> tmp = new Dictionary <string, string>();
                tmp.Add("idetat","RB");
                database.Update("fichefrais",tmp,"WHERE mois='"+moisPrecedent+"' AND idetat='VA'");



             
            }
        }
    }
}
