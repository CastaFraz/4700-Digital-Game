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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 10; i++) {
            PuzzleStatus[i] = 0;
        }

        PuzzleIndex = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PuzzleCompleted(int PuzzleNum) 
    {
        if (PuzzleIndex < 10) {
            PuzzleStatus[PuzzleIndex] = 1;

            PuzzleIndex = PuzzleIndex + 1;
        }
        
        switch(PuzzleNum)
        {
            case 1: // Ghost Button Awaken
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }

    public void GhostAwaken()
    {

    }

    public void TestDone() 
    {
        Debug.Log("Done");
        PuzzleStatus[3] = 1;
    }
}
