using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class displayNumbers : MonoBehaviour
{
    [SerializeField]
    private Sprite[] digits;
    [SerializeField]
    private Image[] characters;
    private string codeSequence;

    void Start()
    {
        codeSequence = "";

        for (int i = 0; i <= characters.Length - 1; i++)
        {
            characters[i].sprite = digits[9];
        }

        PushTheButton.ButtonPressed += AddDigitToCodeSequence;
    }

    private void AddDigitToCodeSequence(string digitEntered)
    {
        switch (digitEntered)
        {
            case "Star":
                ResetDisplay();
                return;

            case "Hash":
                if (codeSequence.Length > 0)
                {
                    CheckResults();
                }
                return;
        }
        if (codeSequence.Length < 4)
        {
            switch (digitEntered)
            {
                case "One":
                    codeSequence += "1";
                    DisplayCodeSequence(0);
                    break;
                case "Two":
                    codeSequence += "2";
                    DisplayCodeSequence(1);
                    break;
                case "Three":
                    codeSequence += "3";
                    DisplayCodeSequence(2);
                    break;
                case "Four":
                    codeSequence += "4";
                    DisplayCodeSequence(3);
                    break;
                case "Five":
                    codeSequence += "5";
                    DisplayCodeSequence(4);
                    break;
                case "Six":
                    codeSequence += "6";
                    DisplayCodeSequence(5);
                    break;
                case "Seven":
                    codeSequence += "7";
                    DisplayCodeSequence(6);
                    break;
                case "Eight":
                    codeSequence += "8";
                    DisplayCodeSequence(7);
                    break;
                case "Nine":
                    codeSequence += "9";
                    DisplayCodeSequence(8);
                    break;
            }
        }
    }

    private void ResetDisplay()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].sprite = digits[9];
        }

        codeSequence = "";
    }


    private void DisplayCodeSequence(int digitJustEntered)
    {
        switch (codeSequence.Length)
        {
            case 1:
                characters[0].sprite = digits[9];
                characters[1].sprite = digits[9];
                characters[2].sprite = digits[9];
                characters[3].sprite = digits[digitJustEntered];
                break;
            case 2:
                characters[0].sprite = digits[9];
                characters[1].sprite = digits[9];
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitJustEntered];
                break;
            case 3:
                characters[0].sprite = digits[9];
                characters[1].sprite = characters[2].sprite;
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitJustEntered];
                break;
            case 4:
                characters[0].sprite = characters[1].sprite;
                characters[1].sprite = characters[2].sprite;
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitJustEntered];
                break;
        }
    }

    private void CheckResults()
    {
        if (codeSequence == "9325")
        {
            SceneManager.LoadScene("the memories");
        }
        else
        {
            ResetDisplay();
        }
    }


    private void OnDestroy()
    {
        PushTheButton.ButtonPressed -= AddDigitToCodeSequence;
    }
}

