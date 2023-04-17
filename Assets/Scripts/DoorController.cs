using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
            Debug.Log("Next LvL");    
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
