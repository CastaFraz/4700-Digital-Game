using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Item1Puzzle : MonoBehaviour
{

    public TMP_Text counter;
    public int num;

    bool isSolved;

    // EventSystem evenSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // The moment this runs, it resets the numbers in inspector??
        // Debug.Log(message: "Item1 pressed");

        // num = 0;
        // counter.text = num.ToString();

        // isSolved = false;

        // LoadSceneMode mode = loadAdditive ? LoadSceneMode.Additive : LoadSceneMode.Single;
        // if (!SceneManager.GetSceneByName(sceneToLoad).isLoaded) {
        //     SceneManager.LoadScene(sceneToLoad, mode);
        // }

        //EventSystem.current.enabled = false;

        //SceneManager.LoadScene (sceneToLoad, LoadSceneMode.Additive);

        

    }

    // Update is called once per frame
    void Update()
    {

        // // This is where checks for puzzle completed is
        // if (isSolved == false) {

        //     if (num == 10) {
        //         Debug.Log(message: "Send Trigger");
        //         isSolved = true;
        //     }
        // }

        
    }

    public void clicked() 
    {
        // Debug.Log(message: "Item1 Button pressed");
        // num = num + 1;
        // //Debug.Log(message: "num = " + num.ToString());

        // counter.text = num.ToString();

    }
}
