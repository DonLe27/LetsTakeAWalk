using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ingredients By Index: (not finalized just an example)
//     0 : Mushrooms,    1 : Fish,   2 : Lettuce, 
//     3 : Potatoes,     4 : Carrots 
public enum IngredientID{
    SmallMushroom = 0, BigMushroom = 1, LotusRoot = 2, BokChoy = 3, Gyoza = 4, NormalSoupBase = 5, SpicySoupBase = 6
}



// public int[,,] IngredientSpawnLocations = { { { 1, 2, 3 } }, //zone 1
// { { 1, 2, 3 } }, //zone 2
// { { 1, 2, 3 } } }; //zone 3


public class IngredientInfo:MonoBehaviour
{
    //Ingredient ID to specify which type of ingredient it is
    public IngredientID id;
}
