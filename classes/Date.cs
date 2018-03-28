using System;

abstract class Date {


public static string getMoisPrecedent(){
   DateTime date = DateTime.Now;
   int mois = date.Month -1;
   string result = format(mois);
   return result;
}

public static string getMoisPrecedent(DateTime date){
   int mois = date.Month -1;
   string result = format(mois);
   return result;
}

public static string getMoisSuivant(){
   DateTime date = DateTime.Now;
   int mois = date.Month +1;
   string result = format(mois);
   return result;
}
public static string getMoisSuivant(DateTime date){
   int mois = date.Month +1;
   string result = format(mois);

   return result;
}


public static bool entre(int jour1, int jour2){
   DateTime date = DateTime.Now;
   int jour = date.Day;
   return checkEstDansInterval(jour1,jour2,jour);
}


public static bool entre(int jour1, int jour2, DateTime date){
   int jour = date.Day;
   return checkEstDansInterval(jour1,jour2,jour);
}

private static string format(int mois){
    string result = "";
   if( mois <10){
       result = "0"+mois.ToString();
   }
   return result;
}


private static bool checkEstDansInterval(int start, int end, int value){
   if (start < value && value < end)
   {
       return true;
   }
   else{
       return false;
   }
}

}