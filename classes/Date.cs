using System;

abstract class Date {


public static string getMoisPrecedent(){
   DateTime date = DateTime.Now;
   int mois = date.Month -1;
   string result = "";
   if(mois <10){
       result = "0"+mois.ToString();
   }
   return result;
}

public static string getMoisPrecedent(DateTime date){
   int mois = date.Month -1;
   string result = "";
   if(mois <10){
       result = "0"+mois.ToString();
   }
   return result;
}

public static string getMoisSuivant(){
   DateTime date = DateTime.Now;
   int mois = date.Month +1;
   string result = "";
   if(mois <10){
       result = "0"+mois.ToString();
   }
   return result;
}
public static string getMoisSuivant(DateTime date){
   int mois = date.Month +1;
   string result = "";
   if(mois <10){
       result = "0"+mois.ToString();
   }
   return result;
}


public static bool entre(int jour1, int jour2){
   DateTime date = DateTime.Now;
   int jour = date.Day;
   if (jour1 < jour && jour < jour2)
   {
       return true;
   }
   else{
       return false;
   }
}


public static bool entre(int jour1, int jour2, DateTime date){
   int jour = date.Day;
   if (jour1 < jour && jour < jour2)
   {
       return true;
   }
   else{
       return false;
   }
}

}