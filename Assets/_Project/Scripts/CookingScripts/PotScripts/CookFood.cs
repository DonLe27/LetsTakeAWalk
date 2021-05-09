using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MealID{
    DefaultItem=0, MushroomSoup=1 
}
public class CookFood : MonoBehaviour
{
    //Int array that represents the ingredients of each type that the pot currently has
    //Ingredients By Index: (not finalized just an example)
    //0 : Mushrooms,    1 : Fish,   2 : Lettuce, 
    //3 : Potatoes,     4 : Carrots 
    public int[] ingredients = { 0, 0, 0, 0, 0 };
    private int ingredientTypes = 5; //makes it easy to change how many ingredients we have

    public Dictionary<string, MealID> recipes = new Dictionary<string, MealID>(){
        {"30000",MealID.MushroomSoup} //MushroomSoup
    };
    private int numItems;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //add an ingredient to the pot
    public void AddIngredient(IngredientID id){
        ingredients[(int)id]+=1;
        numItems+=1;
    }

    public void cook(){
        MealID mealId = MealID.DefaultItem; //set to default Item
        string recipeCode = "";
        for (int i = 0; i < ingredientTypes; i++){
            recipeCode += ingredients[i].ToString();
        }
        if(recipes.ContainsKey(recipeCode)){
            mealId = recipes[recipeCode];
        }
    }

}
