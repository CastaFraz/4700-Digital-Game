using UnityEngine;
using System;

public class NavigationButton : MonoBehaviour
{
    //[SerializeField] private float speed;
    //private float currentPosX;

    // BUTTON OBJECTS - SET IN EDITOR
    public GameObject leftB;
    public GameObject rightB;

    // WALL OBJECTS - SET IN EDITOR
    public GameObject leftWall; 
    [SerializeField] public GameObject rightWall;
    [SerializeField] public GameObject middleWall;

    // CAMERA OBJECT - SET IN EDITOR
    public GameObject cameraObject;

    //ARRAY OF WALL POSITIONS
    Vector3[] values = new Vector3[3];
    int index = 1;

    void Start()
    {
        // INPUT VALUES INTO ARRAY | 0 - left wall , 1 - middle wall , 2 - right wall
        // Z position stays the same throughout. x and y positions change depending on where the wall sprite is
        values[0] = new Vector3(leftWall.transform.position.x, leftWall.transform.position.y, cameraObject.transform.position.z);
        values[1] = new Vector3(middleWall.transform.position.x, middleWall.transform.position.y, cameraObject.transform.position.z);
        values[2] = new Vector3(rightWall.transform.position.x, rightWall.transform.position.y, cameraObject.transform.position.z);
        
    }

    public void leftButton()
    {
        //Debug.Log(message:index);

        // GET CURRENT INDEX / WHAT WALL
        index = System.Array.IndexOf(values, cameraObject.transform.position);

        // Test if able to go left (error handling)
        if (index >0) {
            // If larger than 0, go to next wall
            index = index - 1;
            // Set camera position to the wall
            cameraObject.transform.position = values[index];
            // Set right button visible again (no longer at right further wall)
            rightB.SetActive(true);

            // If at left most wall, disable left button
            if (index == 0) {
                leftB.SetActive(false);
            }
        }
        else {
            Debug.Log(message:"End of Walls");
        }

        Debug.Log(message:"New Index: " + index);
        
    }

    public void rightButton()
    {
        //Debug.Log(message:"Right wall");

        // GET CURRENT INDEX / WHAT WALL
        index = System.Array.IndexOf(values, cameraObject.transform.position);

        // Test if able to go right (error handling)
        if (index <2) {
            // If less than 2, go to next wall
            index = index + 1;
            // Set camera position to the wall
            cameraObject.transform.position = values[index];
            // Set left button visible again (no longer at left further wall)
            leftB.SetActive(true);

            // If at right most wall, disable right button
            if (index == 2) {
                rightB.SetActive(false);
            }
        }
        else {
            Debug.Log(message:"End of Walls");
        }
        Debug.Log(message:"New Index: " + index);
    }

    public void Update()
    {
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed * Time.deltaTime);
    }

    public void moveWall(Transform _newWall)
    {
        //currentPosX = _newWall.position.x;
    }
}
