using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Member Variables
    [SerializeField]
    private float duration;

    /* [SerializeField]
    private float lerpDirection; */

    private Transform goblinEnemyTransform;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the goblinEnemyTransform
        goblinEnemyTransform = gameObject.transform;

    }

    // Update is called once per frame
    void Update()
    {
        DoLerp();
    }


    // Method: Lerp Movement for the Goblin
    void DoLerp()
    {
        // Designate the end position of the goblin enemy
        Vector3 endPos = new Vector3(goblinEnemyTransform.position.x - 1.0f, goblinEnemyTransform.position.y, goblinEnemyTransform.position.z);

        Debug.Log("EndPos: " + endPos);

        // Calculate the timeFraction
        float timeFraction = Time.deltaTime / duration;

        // Perform Lerp using Vector3.lerp Unity function
        goblinEnemyTransform.position = Vector3.Lerp(goblinEnemyTransform.position, endPos, timeFraction);

        Debug.Log("Final Position: " + goblinEnemyTransform.position);
    }

}
