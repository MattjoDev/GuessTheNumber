using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Game Objects
    public GameObject menuView;
    public GameObject gameplayView;
    public GameObject guessView;
    public GameObject higherButton;
    public GameObject lowerButton;
    public GameObject correctButton;
    public GameObject settingsButton;
    public GameObject replayButton;
    //Text UI
    public TMP_InputField inputText;
    public TextMeshProUGUI responseText;
    public TextMeshProUGUI guessText;
    //Other Values
    private int randomNumber;
    private int guessNumber;
    private int guesses;
    public int currentMin = 0;
    public int currentMax = 100;
    public int currentNumber; //This is the number that the PC will guess

    public void StartGame()
    {
        menuView.SetActive(false);
        gameplayView.SetActive(true);
        responseText.text = "Enter a number from 1 to 100";
        guesses = 0;
    }

    public void GetInput(string input)
    {
        // This is a function that makes the player guess
        Debug.Log("You Entered " + input);
        if (int.TryParse(input, out int number))
        {
            guesses++;
            if (randomNumber == number)
            {
                responseText.text = "Congratulation, this is correct number. It took you " + guesses + " guesses";
                menuView.SetActive(true);
            }
            else if (randomNumber > number)
            {
                responseText.text = "My number is higher";
            }
            else if (randomNumber < number)
            {
                responseText.text = "My number is lower";
            }

            inputText.text = "";

        }

    }

    public void SetNumber(string input) // This function sets the number for the computer to guess
    {
        if (int.TryParse(input, out int number) && number < 101 && number > 0)
        {
            currentNumber = number;
            gameplayView.SetActive(false);
            guessView.SetActive(true);
            guessNumber = Random.Range(currentMin, currentMax);
            guessText.text = "Is your number " + guessNumber + "?"; //Prompt
        }

    }

    public void SetHigher()
    {
        currentMin = guessNumber;
        guessNumber = Random.Range(currentMin, currentMax);
        guessText.text = "Is your number " + guessNumber + "?";
    }

    public void SetLower()
    {
        currentMax = guessNumber;
        guessNumber = Random.Range(currentMin, currentMax);
        guessText.text = "Is your number " + guessNumber + "?";
    }

    public void Correct() // Function responsible for enging the game after correct guess.(Also checks if player lied)
    {
        higherButton.SetActive(false);
        lowerButton.SetActive(false);
        correctButton.SetActive(false);

        if (guessNumber == currentNumber)
        {
            guessText.text = "Yaay I guessed!!!";
        }
        else
        {
            guessText.text = "YOU LIED TO ME!";
        }

        replayButton.SetActive(true);

    }
}

