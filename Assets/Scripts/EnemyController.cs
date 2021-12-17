using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    // Member Variables for the Red Text of the Canvas
    private GameObject gameOverGameObject;

    private Text gameOverText;

    // Member Variables
    [SerializeField]
    private float duration;

    private Transform goblinEnemyTransform;

    // Bool Member Variables
    private bool hasGoblinMeetWall;

    private bool isGoblinGoingLeft;

    private bool isGoblinClimbingDown;

    private bool hasTheChest;



    // Start is called before the first frame update
    void Start()
    {
        // Initialize the goblinEnemyTransform
        goblinEnemyTransform = gameObject.transform;

        // Initialize all the bool variables as false
        hasGoblinMeetWall = false;

        isGoblinGoingLeft = false;

        isGoblinClimbingDown = false;

        hasTheChest = false;

        // Get the gameOverText
        gameOverGameObject = GameObject.FindGameObjectWithTag("GameOver");

        gameOverText = gameOverGameObject.GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        if (hasGoblinMeetWall)
        {
            // Y Axis Lerp going up
            DoLerp(0.0f, 1.0f);
        }
        else if (isGoblinClimbingDown)
        {
            // Y Axis Lerp going down
            DoLerp(0.0f, -1.0f);
        }
        else 
        {
            // X Axis Lerp in a left direction
            DoLerp(-1.0f, 0.0f);
        }

        // Check if the x position of the transform is equal
        // or less than -27.8f 
        if (hasTheChest)
        {
            // Destroy the Goblin (this gameObject)
            DoLerp(0.0f, 0.0f);
        }

    }


    // Method: Lerp Movement for the Goblin
    void DoLerp(float xAxisMovement, float yAxisMovement)
    {
        // Designate the end position of the goblin enemy
        Vector3 endPos = new Vector3(goblinEnemyTransform.position.x + xAxisMovement, goblinEnemyTransform.position.y + yAxisMovement);

        // Calculate the timeFraction
        float timeFraction = Time.deltaTime / duration;

        // Perform Lerp using Vector3.lerp Unity function
        goblinEnemyTransform.position = Vector3.Lerp(goblinEnemyTransform.position, endPos, timeFraction);

    }


    // Message: OnCollisionEnter to detect when a collider/rigidbody touches this gameObject
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Impassable")
        {
            // Make the hasGoblinMeetWall bool to be true as the Goblin is at the wall!!!
            hasGoblinMeetWall = true;
            isGoblinGoingLeft = false;
            isGoblinClimbingDown = false;
        }

        if (collision.tag == "Go Left")
        {
            // Make the isGoblinGoingLeft bool to be true as the Goblin have finished dealing with the wall!!!
            isGoblinGoingLeft = true;
            hasGoblinMeetWall = false;
            isGoblinClimbingDown = false;
        }

        if (collision.tag == "Go Down")
        {
            // Make the isGoblinClimbingDown bool to be true as the Goblin is at the edge!
            isGoblinClimbingDown = true;
            isGoblinGoingLeft = false;
            hasGoblinMeetWall = false;
        }

        if (collision.tag == "Chest")
        {
            hasTheChest = true;
            gameOverText.text = "Game Over!";
        }
    }
}
