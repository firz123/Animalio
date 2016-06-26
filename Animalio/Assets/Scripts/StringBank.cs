using UnityEngine;
using System.Collections;

public class StringBank : MonoBehaviour {
     public static readonly string TIGER_01 = "Hello! I am a Bengal tiger. I am a <b>carnivore. </b> That means that I like to eat meat, so you better not feed me veggies!";
     public static readonly string TIGER_02 = "I love to hunt birds because I am a <b>predator</b>. Birds are very tasty.";


     public static readonly string FROG_01 = "Hello! I am a poison dart frog. I love to eat insects, which makes me a predator. Flies are really yummy to eat!";
     public static readonly string FROG_02 = "Poison dart frogs like me are losing our home, or <b>habitat</b>, because people are chopping down trees! Remember to recycle!";

     public static string[] frogArray;
     public static string[] tigerArray;  

     void Start()
     {
         tigerArray = new string[] { TIGER_01, TIGER_02};
         frogArray = new string[] { FROG_01, FROG_02};
     }

     public static string chooseString(string Animal)
     {
         switch (Animal)
         { 
             case "Tiger":
                 return tigerArray[Random.Range(0, tigerArray.Length)];
               
             case "Frog":
                 return frogArray[Random.Range(0, tigerArray.Length)];
                
         }
         return null; 
     }
}
