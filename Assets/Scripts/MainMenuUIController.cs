using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{

    // Member Variables for the Red Text of the Canvas
    [SerializeField]
    private Text pressStartText;


    // Member Variables for the timer
    private float timer;


    // Member Variables for the bool
    private bool isPressStartTextEmpty;

    private bool isPressStartTextThere;


    // Start is called before the first frame update
    void Start()
    {
        // Make isPressStartTextEmpty as false as the text concern
        // is going to be there when the menu scene is rendered
        isPressStartTextEmpty = false;

        // Make isPressStartTextThere as true as the text concern
        // is going to be there when the menu scene is rendered
        isPressStartTextThere = true;

    }

    // Update is called once per frame
    void Update()
    {
        // Timer count
        timer += Time.deltaTime;

        // When the 'X' key is pressed, load the game scene
        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadSceneAsync(1);
        }


        // Check if it have been 0.8 seconds and the Press Start Text Field is Filled in
        if (isPressStartTextThere && timer >= 0.8f)
        {
            pressStartText.text = " ";

            // Make the isPressStartTextEmpty text to be true
            isPressStartTextEmpty = true;

            // Make the isPressStartTextThere text to be false
            isPressStartTextThere = false;

            ResetTimer();
        }

        // Check if it have been 0.8 seconds and the Press Start Text Field is Empty
        if (isPressStartTextEmpty && timer >= 0.8f)
        {
            pressStartText.text = "Press 'X' to Start the Game";

            // Make the isPressStartTextEmpty text to be false
            isPressStartTextEmpty = false;

            // Make the isPressStartTextThere text to be true
            isPressStartTextThere = true;

            ResetTimer();
        }

    }


    // Method -- Reset the Timer to have a float value of 0.0f
    private void ResetTimer()
    {
        timer = 0.0f;
    }

}
