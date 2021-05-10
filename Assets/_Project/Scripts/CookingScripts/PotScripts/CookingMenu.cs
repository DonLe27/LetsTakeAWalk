using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingMenu : MonoBehaviour
{
    public GameObject ingredientButton;
    public GameObject MenuCanvas;

    private int numIngredients = 5; //the total number of ingredients in the game

    public void CreateMenu(GameObject player){
        //create Menu
        GameObject newCanvas = Instantiate(MenuCanvas);
        GameObject newButton;
        ManagePlayerData managePlayerData = gameObject.GetComponent<ManagePlayerData>();
        //Loop through players Items to check what items they have
        int buttonIndex = 0;
        for (int i = 0; i < numIngredients; i++){
            if(managePlayerData.getIngredientCount(i)>0){ //if the player has at least one of this ingredient make a button for it
               newButton = Instantiate(ingredientButton); 
               newButton.transform.SetParent(newCanvas.transform, false);
                newButton.GetComponent<RectTransform>().position.Set(20, 100 - 30 * buttonIndex, 0);
                newButton.GetComponentInChildren<Text>().text = ((IngredientID)i).ToString();
            }
        }
        //GameObject buttonText = newButton.transform.GetChild(0).gameObject;
    }

}
