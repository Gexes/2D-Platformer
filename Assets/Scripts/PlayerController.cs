using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //importing SceneManagement library

public class PlayerController : MonoBehaviour
{
    public float speed = 0.5f;
    public bool hasKey = false;

    public GameObject key;

    public static PlayerController instance; //creating an object of the class to be findable

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null) //check if instance is in the scene
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        if (Input.GetKey("w"))
        {
            //player moves up
            newPosition.y += speed;
        }

        if (Input.GetKey("s"))
        {
            //player moves down
            newPosition.y -= speed;
        }

        //player moves left
        if (Input.GetKey("a"))
        {
            newPosition.x -= speed;
        }

        //player moves right
        if (Input.GetKey("d"))
        {
            newPosition.x += speed;
        }

        transform.position = newPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("door"))
        {
            Debug.Log("hit");
            SceneManager.LoadScene(1); //access SceneManager class for LoadScene function
        }

        if (collision.gameObject.tag.Equals("key"))
        {
            Debug.Log("obtained key");
            //key.SetActive(false); //key disappears
            hasKey = true; //player has the key now
        }

        //write code for exiting second scene and go back to first scene
        if (collision.gameObject.tag.Equals("exit"))
        {
            Debug.Log("hit");
            SceneManager.LoadScene(0);
        }

        if (collision.gameObject.tag.Equals("end") && hasKey == true) //needs to satisfy both
                                                                      //conditions to enter the end door
        {
            Debug.Log("hit");
            SceneManager.LoadScene(2);
        }
    }
}
