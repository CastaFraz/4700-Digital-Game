using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzleManager : MonoBehaviour
{
    // Script that handles Room changes & Puzzle triggers
    // This includes puzzle outcomes

    // ORDER OF PUZZLES
    // Ghost Awaken Button (P)
    // Bookmark (D)
    // Picture Rearrange (P)
    // Clock (D)
    // Bird Map (P)
    // Typewriter (D)
    // Mirror (P)
    // Light Switch (D)
    // Shadow (P)
    // Box Unlocking (D)

    public int[] PuzzleStatus = new int[10];

    public int PuzzleIndex;

    // Room changing stuff ---------------------------------------
    //public GameObject[] pictures = new GameObject[4];
    public GameObject[] pictures = new GameObject[4];

    public Sprite[] picNoUV = new Sprite[4];
    public Sprite[] picUV = new Sprite[4];

    public bool isState2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 10; i++) {
            PuzzleStatus[i] = 0;
        }

        PuzzleIndex = 0;

        isState2 = false;
        for (int i = 0; i < 4; i++) {
               pictures[i].GetComponent<SpriteRenderer>().sprite = picNoUV[i];
            }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When puzzle is DONE
    public void PuzzleCompleted(int PuzzleNum) 
    {
        if (PuzzleIndex < 10) {
            PuzzleStatus[PuzzleIndex] = 1;

            PuzzleIndex = PuzzleIndex + 1;
        }
        
        switch(PuzzleNum)
        {
            case 1: // Ghost Button Awaken
                GhostAwaken();
                break;
            case 2:
                BookmarkDone();
                break;
            case 3:
                // isState2 = true
                    // have isState2 set to false when UV lights turn off
                PictureArrange();
                break;
            case 4:
                ClockDone();
                break;
            case 5:
                BirdMap();
                break;
        }
    }

    // THESE FUNCTIONS ARE CALLED WHEN PUZZLE IS FINISHED
    // Finished either digital or physical depending on the puzzle
    public void GhostAwaken()
    {
        // Not sent from digital game, but from physical tech
        // Canvas overlay / background toggled off
    }

    public void BookmarkDone()
    {
        Debug.Log("Bookmark Done");
        PuzzleStatus[1] = 1;

        // Outcome trigger
        // Physical call to show the paper (?)
    }

    public void PictureArrange()
    {
        // Not sent from digital game, but from physical tech
        // Physical signal in triggers this

        // Sprites of pictures set to correct sprites
            // Take from sprite change branch

        Debug.Log("Button Hit");

        // This may need to be commented out depending on if function gets double called
        isState2 = !isState2;

        if (isState2) {
            Debug.Log("State2");
            for (int i = 0; i < 4; i++) {
                pictures[i].GetComponent<SpriteRenderer>().sprite = picUV[i];
            }

        }
        else {
            Debug.Log("State1");
            for (int i = 0; i < 4; i++) {
                pictures[i].GetComponent<SpriteRenderer>().sprite = picNoUV[i];
            }
        }

        // Trigger for UV lighting
    }

    public void ClockDone() 
    {
        Debug.Log("Clock Done");
        PuzzleStatus[3] = 1;

        // Outcome trigger
        // Physical clock time update + Bird call
    }

    public void BirdMap()
    {
        // Not sent from digital game, but from physical tech
    }
}
