using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ClockPuzzleTest : MonoBehaviour
{

    //private Transform clockHandTransform;
    // TRANSFORM OBJECTS OF THE MINUTE AND HOUR 
    private Transform minuteTransform;
    private Transform hourTransform;

    // GAMEOBJECTS OF MINUTE AND HOUR HAND - Set in Inspector
    public GameObject minuteHand;
    public GameObject hourHand;

    // VALUES FOR CHECKING CORRECT TIME - to be updated
    // Testing time (for clock trigger) - 3:30 (15:30)
    // Hour hand - -105 , Minute hand - 180
    // int minuteHandTime, hourHandTime;

    // Values for minute and hour hand 
    float minuteDeg, hourDeg;
    float minuteTime, hourTime;

    // BOOLEAN VALUES FOR TESTING IF HANDS ARE CORRECT
    bool minTF, hrTF;

    // CALLED WHEN SCENE GETS LOADED IN
    private void Awake() {

        //Debug.Log(message: "Start");

        // Get transform values from objects
        minuteTransform = minuteHand.GetComponent<RectTransform>();
        hourTransform = hourHand.GetComponent<RectTransform>();

        // minuteHandTime = 180; //00:30
        // hourHandTime = -105; // Between 3:00 & 4:00

        // Reset all values on start (Can be changed to saved values if we want)
        minuteTime = 0;
        hourTime = 0;
        minuteDeg = 0;
        hourDeg = 0;

        minTF = false;
        hrTF = false;

    }

    private void Update() {

        hourTime = hourDeg;
        minuteTime = minuteDeg;
    }

    // CALLED WHEN MINUTE HAND IS BEING DRAGGED
    public void mDrag() 
    {
        //Debug.Log(message: "Minute Hand");

        // Gets position of the mouse on screen (2D)
        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
        // Puts position into 3D
        Vector3 conversionPos = new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, 0f);

        Vector3 rotateDirection = (conversionPos - transform.position).normalized;
        rotateDirection.z = 0;

        // Get the value of the angle that hand should go in
        float angle = Mathf.Atan2(rotateDirection.y, rotateDirection.x) * Mathf.Rad2Deg;

        // Set z rotation of minute hand to angle value
        // For some reason it only works when I remove 90 degrees...
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));

        //Debug.Log(message: "Z cord: " + angle.ToString());

    }

    // CALLED WHEN HOUR HAND IS BEING DRAGGED
    public void hDrag()
    {
        // Gets position of the mouse on screen (2D)
        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
        // Puts position into 3D
        Vector3 conversionPos = new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, 0f);

        Vector3 rotateDirection = (conversionPos - transform.position).normalized;
        rotateDirection.z = 0;

        // Get the value of the angle that hand should go in
        float angle = Mathf.Atan2(rotateDirection.y, rotateDirection.x) * Mathf.Rad2Deg;

        // Set z rotation of hour hand to angle value
        // For some reason it only works when I remove 90 degrees...
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));

        //Debug.Log(message: "Z cord: " + angle.ToString());
    }

    // CALLED WHEN EITHER MINUTE OR HOUR HAND IS STOPPED BEING DRAGGED
    public void checkSolved() 
    {
        // NEEDS TO BE REWORKED TO BE BETTER

        // Gets the current angle of minute hand
        minuteDeg = minuteTransform.localEulerAngles.z;
        if (minuteDeg > 180) {
            minuteDeg = minuteDeg - 360;
        }
        minuteTime = minuteDeg;


        // Gets the current angle of hour hand
        hourDeg = hourTransform.localEulerAngles.z;
        if (hourDeg > 180) {
            hourDeg = hourDeg - 360;
        }
        hourTime = hourDeg;



        // Gives a range of ~10 degrees
        // WILL NEED TO BE FIXED
        float minMax = 170;
        float minMin = -170;
        // float hourMax = -95;
        // float hourMin = -115;

        // Debug.Log(message: "Minute: " + minuteDeg.ToString());
        // Debug.Log(message: "Hour: " + hourDeg.ToString());
        
        // Test if minute hand is correct
        if (minMax <= minuteDeg || minuteDeg <= minMin) {
            Debug.Log(message: "Minute Correct");
            minTF = true;
        }
        else {
            minTF = false;
        }

        // Test if hour hand is correct
        if (-95 >= hourDeg && -115 < hourDeg) {
            Debug.Log(message: "Hour Correct");
            hrTF = true;
        }
        else {
            hrTF = false;
        }

        // Test if both minute hand & hour hand is correct
        if (minTF && hrTF) {
            Debug.Log(message: "PUZZLE CORRECT");

            // SEND OUT TRIGGER HERE
        }

        
    }

}
