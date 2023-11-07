using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //importing SceneManagement library

public class PlayerController : MonoBehaviour
{
    //Movement variable
    Rigidbody2D rb;//creates reference for rigibody beause jump requires physics
    public float jumpForce;// the force that will be added to the vertical component of player's velocity
    public float speed = 0.5f;


    public static PlayerController instance; //creating an object of the class to be findable

    //Ground Check variables
    public LayerMask groundLayer;
    public Transform groundCheck;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded =
        Vector3 newPosition = transform.position;
        Vector3 newScale = transform.localScale;
        float currentScale = Mathf.Abs(transform.localScale.x);

        if (Input.GetKey("s"))
        {
            //player moves down
            newPosition.y -= speed;
        }

        //player moves left
        if (Input.GetKey("a"))
        {
            newPosition.x -= speed;
            newScale.x = -currentScale;
        }

        //player moves right
        if (Input.GetKey("d"))
        {
            newPosition.x += speed;
            newScale.x = currentScale;
        }

        transform.position = newPosition;
        transform.localScale = newScale;

        if (Input.GetKey("w") || Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
