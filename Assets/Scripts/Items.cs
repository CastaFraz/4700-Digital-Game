using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Items : MonoBehaviour
{

    // HANDS THE ITEM INTERACTIONS, BOTH SEEING AN ITEM CLOSE UP AND INTERACTING WITH PUZZLE ITEMS
    // POP-UP REFERS TO THE ITEM 'POPPING UP' OVER THE SCREEN WHEN CLICKED AND INTERACTED WITH

    // CANVAS OBJECTS - SET IN EDITOR
    //public Canvas Item1PopUp;
    //public Canvas Item2PopUp;

    // ItemPopUp is parent Pop-up. This holds the item-specific Pop-up & the exit button
    public Canvas ItemPopUp;
    public GameObject canvasGameObject;

    // ARRAY OF PUZZLE-SPECIFIC SCENES - SET IN EDITOR
    // Number of indexes = amount of puzzle items + 1
    // Scenes get called by their scene name, so strings are used
    public string[] PopUpScenes = new string[3];

    // STRING OF CURRENT PUZZLE SCENE
    // Empty means no puzzle interacted
    public string puzzleScene;

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
        // Set string to empty, no puzzle being interacted with
        puzzleScene = "";

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

        // Don't need to disable scene loaded
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // CALLED WHEN PUZZLE ITEM GETS CLICKED ON
    // intemID is set in the item's GameObject's event handler
    public void ItemInteraction(int itemID)
    {
        // Set the canvas active so it appears
        canvasGameObject.SetActive(true);
        //Debug.Log(message: "Puzzle Clicked");
        
        // Enables parent Pop-up
        ItemPopUp.enabled = true;

        // Set the puzzleScene string to the string associated in Scene array based on given index
        puzzleScene = PopUpScenes[itemID];
        Debug.Log(message: "Scene: " + puzzleScene);

        // Checks if the puzzleScene points to an existing Scene (if no existing scene, will cause an error)
        if (!string.IsNullOrEmpty(puzzleScene)) {
            // Loads scene into main based on puzzleScene
            // Mode additive so it appears with MainScene
            SceneManager.LoadScene (puzzleScene, LoadSceneMode.Additive);
        }

    }

    // CALLED WHEN ITEM (NON-PUZZLE) GETS CLICKED ON
    public void ItemLook(int itemID)
    {
        // Set the canvas active so it appears
        canvasGameObject.SetActive(true);
        //Debug.Log(message: "Looking Clicked");

        // Enables parent Pop-up
        ItemPopUp.enabled = true;

        // Set ItemNumber to reflect current item being interacted with
        ItemNumber = itemID;

        // Enable item-specific canvas using itemID
        PopUps[itemID].enabled = true;
    }

    // CALLED WHEN EXIT BUTTON IS PRESSED
    public void exitInteraction() 
    {
        //Debug.Log(message: "exit" + ItemNumber);

        // Disable canvas object
        canvasGameObject.SetActive(false);

        // Goes through all item-specific canvas and disables
        foreach (Canvas canvas in PopUps) {
            // Skips any null canvas
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

        //Debug.Log(message: "Scene: " + puzzleScene);

        // Unload Puzzle Scene (If a puzzle scene is active)
        if (!string.IsNullOrEmpty(puzzleScene)) {
            SceneManager.UnloadSceneAsync (puzzleScene);
        }
        // Set string to empty
        puzzleScene = "";
    }

}
