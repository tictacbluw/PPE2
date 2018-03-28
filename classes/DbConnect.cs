using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

/*
    Classe d'accès aux données
    Permet d'intéragir avec une base MySql
*/

/// <summary>
/// Classe d'accès aux données
/// Permet d'intéragir avec une base MySql
/// </summary>
/// <remarks>
/// Permet d'éxecuter des requêtes de type INSERT UPDATE DELETE et SELECT
/// </remarks>
public class DbConnect {


private static string serveur = "s18538332.domainepardefaut.fr" ;

private static string bdd = "gsb_frais";
private static string utilisateur = "userGsb";
private static string mdp = "secret";


private static  MySqlConnection conn =null;

/*
    Se connecte à la base de données
*/
/// <summary>
/// Se connecte à la base de données
/// </summary>
/// <returns>
/// Retourne Vrai si la connection à la BDD a réussie sinon faux 
/// </returns>

public bool Connect() {
    try {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.DataSource = serveur;
        builder.UserID = utilisateur;
        builder.Password = mdp;
        builder.InitialCatalog = bdd;
        conn = new MySqlConnection(builder.ConnectionString);
        conn.Open();
        Console.WriteLine("Connection base de donnée réussie!");
        return true;
    }
    catch (MySqlException e){
        Console.WriteLine(e);
        return false;
    }    
}



/* 
    Se déconnecte de la base de données
*/
/// <summary>
/// Se déconnecte de la base de données
/// </summary>
/// <returns>
/// Retourne Vrai si la déconnection à la BDD a réussie sinon faux 
/// </returns>
private bool Disconnect(){
    try{
        conn.Close();
        return true;
    }
    catch (MySqlException e){
         Console.WriteLine(e);
         return false;
    }
}

/* 
    Insert des données dans une table
*/
/// <summary>
/// Insert des données dans une table
/// </summary>
///<param name="table"> Table dans laquelle inserer les données </param>
///<param name="data">Dictionnaire <string clé, string value> des données à inserer </param>
public void Insert(string table,Dictionary <string, string> data){
    string keys = "("+string.Join(",", data.Keys)+")";
    string values = "('"+string.Join("','", data.Values)+"')";
    string query = "INSERT INTO "+table+" "+keys+" VALUES"+values;

    Console.WriteLine(keys);
    Console.WriteLine(values);
    Console.WriteLine(query);

    MySqlCommand sql = new MySqlCommand(query,conn);

    sql.ExecuteNonQuery();
    this.Disconnect();
}

/* 
    Update des données dans une table
*/
/// <summary>
/// Update des données dans une table
/// </summary>
///<param name="table"> Table dans laquelle update les données </param>
///<param name="data">Dictionnaire <string clé, string value> des données à mettre à jour </param>
///<param name="clause">clause (exemple: WHERE id=2)</param>
public void Update(string table,Dictionary <string, string> data, string clause){
    string values = "";
    string query = "INSERT INTO "+table+" SET ";
    foreach (KeyValuePair<string, string> entry in data)
    {
        values += entry.Key+"="+entry.Value+", ";
    }
    values = values.Substring(0,values.Length-2);
    query += values+" "+clause;
    Console.WriteLine(query);
    MySqlCommand sql = new MySqlCommand(query,conn);
    sql.ExecuteNonQuery();
    this.Disconnect();

}

/* 
   Supprime des données dans une table
*/
/// <summary>
/// Supprime des données dans une table
/// </summary>
///<param name="table"> Table dans laquelle supprimer les données </param>
///<param name="clause">clause (exemple: WHERE id=2)</param>
public void Delete(string table, string clause){
    string query = "DELETE FROM "+table+" "+clause; 
    MySqlCommand sql = new MySqlCommand(query,conn);
    sql.ExecuteNonQuery();
    this.Disconnect();

}


/* 
    Select des données dans une table
*/
/// <summary>
/// Select des données dans une table
/// </summary>
///<param name="data">données à selectionner (exemple: id,name </param>
///<param name="table"> Table dans laquelle select les données </param>
///<param name="clause">clause (exemple: WHERE id=2)</param>
/// <returns>
/// Retourne DataTable élements selectionnés 
/// </returns>
public DataTable Select(string data, string table, string clause){
    string query = "SELECT "+data+" from "+table+" "+clause;
    DataTable result = new DataTable();
    MySqlCommand sql = new MySqlCommand(query,conn);
    using (MySqlDataReader reader = sql.ExecuteReader()){
        if(reader.Read()){
            result.Load(reader);
        }
    }
    this.Disconnect();
    return result;
}




}

