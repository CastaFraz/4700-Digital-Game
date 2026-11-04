using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Items : MonoBehaviour
{

    // POP-UP REFERS TO THE ITEM 'POPPING UP' OVER THE SCREEN WHEN CLICKED AND INTERACTED WITH

    // CANVAS OBJECTS - SET IN EDITOR
    public Canvas Item1PopUp;
    public Canvas Item2PopUp;
    // ItemPopUp is parent Pop-up. This holds the item-specific Pop-up & the exit button
    public Canvas ItemPopUp;

    // ARRAY OF ITEM-SPECIFIC CANVAS - SET IN EDITOR
    // Number of indexes = amount of items interactable + 1
    public Canvas[] PopUps = new Canvas[3];

    // NUMBER OF ITEM CURRENTLY BEING INTERACTED WITH
    // 0 means no item interacted
    public int ItemNumber;

    void Start()
    {
        // Set number to 0, no item being interacted with
        ItemNumber = 0;

        // Set parent Pop-up to disabled 
        ItemPopUp.enabled = false;

        // Goes through all item-specific canvas and disables
        foreach (Canvas canvas in PopUps) {

            // index 0 will always be null, skip this as it's empty
            if (canvas == null) {
                continue;
            }
            // disables item-specific canvas
            canvas.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // CALLED WHEN INTERACTABLE ITEM IS CLICKED
    // intemID is set in the item's GameObject's event handler
    public void ItemInteraction(int itemID)
    {

        Debug.Log(message: "Clicked");
        
        // Enables parent Pop-up
        ItemPopUp.enabled = true;

        // Set ItemNumber to reflect current item being interacted with
        ItemNumber = itemID;

        // Enable item-specific canvas using itemID
        PopUps[itemID].enabled = true;

        // Want to find a way to link canvases to numbers on start so can just use int as key (maybe array?)
        // if (ItemNumber == 1) {
        //     Debug.Log(message: "Item 1");
        //     Item1PopUp.enabled = true;
        // }
        // else if (ItemNumber == 2) {
        //     Item2PopUp.enabled = true;
        // }
    }

    // CALLED WHEN EXIT BUTTON IS PRESSED
    public void exitInteraction() 
    {
        Debug.Log(message: "exit" + ItemNumber);

        // Goes through all item-specific canvas and disables
        foreach (Canvas canvas in PopUps) {
            if (canvas == null) {
                continue;
            }
            // index 0 will always be null, skip this as it's empty
            canvas.enabled = false;
        }
        // disables item-specific canvas
        ItemPopUp.enabled = false;

        // Set ItemNumber back to 0 (no item interacting with)
        ItemNumber = 0;
    }










    public void Item1Clicked()
    {
        Debug.Log(message: "1 Clicked");

        Item1PopUp.enabled = true;

    }

    public void Item2Clicked()
    {
        Debug.Log(message: "2 Clicked");

    }
}
