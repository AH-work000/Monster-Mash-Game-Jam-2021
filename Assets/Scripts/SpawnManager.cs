using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Member Variables
    public GameObject goblinGeneratorPrefab;

    // Timer member variable
    private float timer;

    // Bool member variables
    private bool isSecondGeneratorOn;

    private bool isThirdGeneratorOn;

    // Start is called before the first frame update
    void Start()
    {
        // Generate the first Goblin Generator
        Instantiate(goblinGeneratorPrefab, new Vector3(26.49f, -16.49f, 0.00f), Quaternion.identity);

        // Initialize all bool variables
        isSecondGeneratorOn = false;

        isThirdGeneratorOn = false;
    }

    // Update is called once per frame
    void Update()
    {

        // After 40 seconds 
        if (timer >= 5.0f && !isSecondGeneratorOn) // 5 second right now for testing -- CHANGE AT THE END
        {
            // Generate the second Goblin Generator
            Instantiate(goblinGeneratorPrefab, new Vector3(14.7f, -6.4f, 0.00f), Quaternion.identity);
            isSecondGeneratorOn = true;
        }


        // After 120 seconds
        if (timer >= 10.0f && !isThirdGeneratorOn) // 10 seeconds right now for testing -- CHANGE AT THE END
        {
            // Generate the third Goblin Generator
            Instantiate(goblinGeneratorPrefab, new Vector3(-5.46f, -7.36f, 0.00f), Quaternion.identity);

            // Generate the fourth Goblin Generator
            Instantiate(goblinGeneratorPrefab, new Vector3(-24.5f, -3.13f, 0.00f), Quaternion.identity);

            isThirdGeneratorOn = true;
        }

        // Timer count
        timer += Time.deltaTime;
        
    }


    // Method: Reset the timer back to zero float
    private void ResetTimer()
    {
        timer = 0.0f;
    }
}
