using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public string nextSceneName;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
