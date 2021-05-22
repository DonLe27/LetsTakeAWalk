using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PotInteract: NetworkInteractable
{
    public GameObject ingredientButton;
    public GameObject MenuCanvas;

    private bool displayingMenu = false; //true if menu is currently being displayed

    private int numIngredients = 7; //the total number of ingredients in the game

    private GameObject newCanvas;

    [Server]
    public override void RespondToInteraction(GameObject player)
    {
        //Debug.Log("About to create menu");
        //CreateMenu(player);
    }

    public void CreateMenu(GameObject player){
        //if menu is already being displayed don't redisplay
        if(displayingMenu){
            return;
        }
        //create Menu
        displayingMenu = true;
        Debug.Log("Creating Menu Now");
        newCanvas = Instantiate(MenuCanvas);
        GameObject newButton;
        EventSystem eventSystem = EventSystem.current; //get current eventsystem
        ManagePlayerData managePlayerData = player.GetComponent<ManagePlayerData>();
        //Loop through players Items to check what items they have
        int buttonIndex = 0;
        int buttonHeight = (int)ingredientButton.GetComponent<RectTransform>().rect.height;
        for (int i = 0; i < numIngredients; i++){
            if(managePlayerData.getIngredientCount(i)>0){ //if the player has at least one of this ingredient make a button for it
               newButton = Instantiate(ingredientButton); 
               newButton.transform.SetParent(newCanvas.transform, false);
                //newButton.GetComponent<RectTransform>().position.Set(20, 100 - 30 * buttonIndex, 0);
                newButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(20, 100 - buttonHeight * buttonIndex);
                newButton.GetComponentInChildren<Text>().text = ((IngredientID)i).ToString();

                //Create new int to store current return value of the button
                int x = new int();
                x = i;
                newButton.GetComponent<Button>().onClick.AddListener(delegate { MenuButtonPressed(x, managePlayerData); });

                if(buttonIndex==0){ //if this is the first button set it as FirstSelected
                    eventSystem.SetSelectedGameObject(newButton);
                }

                buttonIndex++;
            }
        }
        Debug.Log("Created Menu");

        // newButton = Instantiate(ingredientButton); 
        // newButton.transform.SetParent(newCanvas.transform, false);
        // newButton.GetComponent<RectTransform>().position.Set(20, 100 - 30 * buttonIndex, 0);
        // newButton.GetComponentInChildren<Text>().text = ((IngredientID)0).ToString();

        //GameObject buttonText = newButton.transform.GetChild(0).gameObject;
    }

    //called on press of menu button
    //removes selected item from the player and adds it to the pot
    void MenuButtonPressed(int index, ManagePlayerData managePlayerData){
        Debug.Log("Pressed button: " + ((IngredientID)index).ToString());
        managePlayerData.updateIngredients((IngredientID)index, false); //remove item from players inventory
        CookFood cookFood = gameObject.GetComponent<CookFood>();
        cookFood.AddIngredient((IngredientID)index); //add item to pot
        
        //remove menu and set displaying menu to false
        Destroy(newCanvas);
        displayingMenu = false;

    }


}
