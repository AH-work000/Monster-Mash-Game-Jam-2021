using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    // Member Variable
    public GameObject goblinPrefab;

    public Vector3 generationPosition;

    private float floatInterval;

    // Timer Member Variable
    private float timer;

    // Bool Member Variable
    private bool isFloatGeneratorOn = true;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if floatInterval already have a value
        if (isFloatGeneratorOn)
        {
            floatInterval = GenerateFloatNumber(1.0f, 8.0f);
            Debug.Log("The float interval is " + floatInterval);
            isFloatGeneratorOn = false;
        }
       
        

        if (timer >= floatInterval)
        {
            // Generate a Goblin Enemy
            Instantiate(goblinPrefab, generationPosition, Quaternion.identity);

            // Reset the timer
            ResetTimer();

            // Set the isFloatGeneratorOn bool to true as a
            // Goblin Enemy have been generated
            isFloatGeneratorOn = true;
        }

        // Timer count
        timer += Time.deltaTime;
    }


    // Method: Generate a random float number for the time interval between the
    // instantiation of the goblin
    private float GenerateFloatNumber(float minFloat, float maxFloat)
    {
        float number = Random.Range(minFloat, maxFloat);
        return number;
    }


    // Method: Reset the timer back to zero float
    private void ResetTimer()
    {
        timer = 0.0f;
    }


}
