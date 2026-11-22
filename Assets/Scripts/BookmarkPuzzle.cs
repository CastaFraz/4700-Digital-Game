using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System;

public class BookmarkPuzzle : MonoBehaviour
{

    GameObject pm;
    public PuzzleManager puzzlemanager;

    // Image1, Image2, etc, linked to the visual of the shape in the bookmark interactable
    // Images image's value is linked to their image component
    // image component is changed depending on the array corresponding
    // Array is of image loads
    // Correct order is viewed through the index of each
    // All correct -> has each array's index checked to see if correct

    // CANVAS OBJECT THAT PLAYER SELECTS SHAPES IN -> Set in Inspector
    public Canvas BookmarkInteracting;

    // SHAPE IMAGES THAT SHOWS SELECTED SHAPE -> Set in Inspector
    public Image Image1, Image2, Image3, Image4;

    // INDEX THAT SHOWS WHAT 'POSITION' THE SHAPE IS 
    // Index is updated based on button presses
    int index1, index2, index3, index4;

    // ARRAY OF SPRITES -> Set in Inspector
    // This holds the 4 shapes that will be set to the shape image depending on the index
    public Sprite[] shapeArray = new Sprite[4];

    //int shapes, rows;
    //public int[,] tArray;
    //public int[] testArray = new int[4];

    bool isSolved;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        pm = GameObject.FindWithTag("PuzzleManager");
        puzzlemanager = pm.GetComponent<PuzzleManager>();

        if (puzzlemanager.PuzzleStatus[1] == 1) {
            isSolved = true;
        }
        else { isSolved = false; }

        // Hide sub-canvas at start
        BookmarkInteracting.enabled = false;

        // Set all indexes 0 (so shapes start as squares)
        index1 = 0;
        index2 = 0;
        index3 = 0;
        index4 = 0;

        //tArray = new int[shapes,rows];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Gets called when small bookmark image gets clicked and summons interactable bookmark
    public void bookmarkClicked() 
    {
        BookmarkInteracting.enabled = true;
    }

    // 'Clicked#' functions called by the buttons depending on which 'row' they're in
    // Seperated so information can be passed to ShapeClicked function
    public void Clicked1(int dir)
    {
        Shape1Clicked(1, dir);
    }

    public void Clicked2(int dir)
    {
        Shape1Clicked(2, dir);
    }

    public void Clicked3(int dir)
    {
        Shape1Clicked(3, dir);
    }

    public void Clicked4(int dir)
    {
        Shape1Clicked(4, dir);
    }

    // Called from Clicked# functions, taking which row and which direction button is pressed
    public void Shape1Clicked(int s, int dir)
    {
        // Checks which row is being changed
        switch(s)
        {
            // If row 1
            case 1:
                if (dir == 1)
                {
                    if (index1 > 0) { index1--; }
                    else { index1 = 3; }
                }
                else if (dir == 2)
                {
                    if (index1 < 3) { index1++; }
                    else { index1 = 0; }
                }
                Image1.GetComponent<Image>().sprite = shapeArray[index1];
                break;
            // If row 2
            case 2:
                if (dir == 1)
                {
                    if (index2 > 0) { index2--; }
                    else { index2 = 3; }
                }
                else if (dir == 2)
                {
                    if (index2 < 3) { index2++; }
                    else { index2 = 0; }
                }
                Image2.GetComponent<Image>().sprite = shapeArray[index2];
                break;
            // If row 3
            case 3:
                if (dir == 1)
                {
                    if (index3 > 0) { index3--; }
                    else { index3 = 3; }
                }
                else if (dir == 2)
                {
                    if (index3 < 3) { index3++; }
                    else { index3 = 0; }
                }
                Image3.GetComponent<Image>().sprite = shapeArray[index3];
                break;
            // If row 4
            case 4:
                if (dir == 1)
                {
                    if (index4 > 0) { index4--; }
                    else { index4 = 3; }
                }
                else if (dir == 2)
                {
                    if (index4 < 3) { index4++; }
                    else { index4 = 0; }
                }
                Image4.GetComponent<Image>().sprite = shapeArray[index4];
                break;
        }

        testShapes(index1, index2, index3, index4);
    }

    public void testShapes(int int1, int int2, int int3, int int4)
    {
        // Tests the index numbers to see if they match up
        // int1 == 2 (Star)
        // int2 == 1 (Circle)
        // int3 == 3 (Triangle)
        // int4 == 0 (Square)

        if (int1 == 2 && int2 == 1 && int3 == 3 && int4 == 0)
        {
            Debug.Log("Puzzle correct");
            isSolved = true;

            puzzlemanager.BookmarkDone();
        }
    }
}
