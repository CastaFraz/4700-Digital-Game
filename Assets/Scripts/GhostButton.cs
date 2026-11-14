using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GhostButton : MonoBehaviour
{

    // ARRAY OF 'VISUAL BUTTONS' - Set in Inspector
    // These buttons will be phyiscal buttons
    public GameObject[] buttons = new GameObject[9];

    // ARRAY OF VISUAL BUTTONS'S POSITION - Set in Start()
    private Transform[] buttonPos = new Transform[9];

    // ARRAY OF LINE OBJECTS - Set in Inspector
    // The lines that are used to connect buttons
    public Image[] lines = new Image[3];

    // THE AMOUNT OF TIMES BUTTONS ARE PRESSED
    int buttonAmt;
    // THE AMOUNT OF LINES THAT HAVE BEEN DRAWN
    int imageAmt;

    // VECTOR THAT SAVES THE PREVIOUS BUTTON POSITION
    Vector3 prevPos;
    // VECTOR THAT HOLDS THE CURRENT BUTTON POSITION
    Vector3 curPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Saves the position of each button visual into corresponding index of buttonPos
        int indx = 0;
        while (indx < 9) {
            // RectTransform -> the position
            buttonPos[indx] = buttons[indx].GetComponent<RectTransform>();

            //Debug.Log(indx + ": " + buttons[indx].GetComponent<RectTransform>().position.ToString());

            indx = indx + 1; 
        }

        // Reset the values to 0
        buttonAmt = 0;
        imageAmt = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called when a button (will be physical) is pressed. Index number is linked to the number the button sends in
    public void inputIn(int index)
    {

        Debug.Log("Button " + index.ToString());

        // When the first button is pressed (where no lines will be rendered)
        if (buttonAmt == 0) {
            //Debug.Log(buttonPos[0].position.ToString());
            curPos = buttonPos[index].position;
        }
        // After 1st button is pressed (imageAmt < 3 so it won't try to do a 4th image)
        else if (imageAmt < 3) {
            // Save the last current position to previous position
            prevPos = curPos;
            // Get the position of button linked in
            curPos = buttonPos[index].position;

            // Get the inbetween position between the two positions
            lines[imageAmt].rectTransform.position = (prevPos + curPos) / 2f;

            // Get the distance between the two positions
            float distance = Vector3.Distance(prevPos, curPos);
            lines[imageAmt].rectTransform.sizeDelta = new Vector2(distance, 5f);
            Debug.Log("PrevPos: " + prevPos.ToString());
            Debug.Log("CurPos: " + curPos.ToString());
            Debug.Log(Vector2.Distance(prevPos, curPos).ToString());

            // Get the angle the line is pointing too
            Vector3 direction = curPos - prevPos;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            lines[imageAmt].rectTransform.rotation = Quaternion.Euler(0, 0, angle);

            // Updates imageAmt to do the next image in the array
            imageAmt = imageAmt + 1;
        }
        // Update value to next button
        buttonAmt = buttonAmt + 1;
    }
}
