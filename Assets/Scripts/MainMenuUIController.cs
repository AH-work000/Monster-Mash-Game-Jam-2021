using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // When the 'X' key is pressed, load the game scene
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("TEST COMMENT: Going to the Game Scene!");

            //  UNCOMMENT THE BELOW CODE ONCE THE GAME SCENE IS FINALISED
            // SceneManager.LoadSceneAsync(1);
        }
        
    }


}
