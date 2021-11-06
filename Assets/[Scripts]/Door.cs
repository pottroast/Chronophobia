using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Goes to main menu for now
    private void OnTriggerEnter2D(Collider2D collision)
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
