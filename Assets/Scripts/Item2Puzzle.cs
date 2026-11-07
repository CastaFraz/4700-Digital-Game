using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Item2Puzzle : MonoBehaviour
{

    public TMP_Text counter;
    public int num;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        num = 0;

        counter.text = num.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clicked() 
    {
        Debug.Log(message: "Item2 Button pressed");
        num = num + 1;
        //Debug.Log(message: "num = " + num.ToString());

        counter.text = num.ToString();

    }
}
