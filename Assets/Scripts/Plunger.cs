using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Plunger : MonoBehaviour
{

    public float distance = 50f;
    public float speed = 1f;
    public GameObject ball;
    public float power = 2000f;

    private bool ready = true;
    private bool fire = false;
    private float moveCount = 0f;
    private Vector3 initialPosition;


    public InputAction buttonAction;
    //private new HingeJoint hingeJoint;

    private void OnEnable()
    {
        buttonAction.Enable();
    }
    private void OnDisable()
    {
        buttonAction.Disable();
    }

    private void Awake()
    {
        Debug.Log("Plunger");
        
    }

    private void Start()
    {
        // Store the initial position of the object
        initialPosition = transform.position;
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            ready = true;
        }
    }


    public void OnKeyPress(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            fire = true;
        }
        else if (context.canceled)
        {
            fire = false;
            if (Gameplay.ball <= 3)
            {
                Gameplay.gameplay = true;
                Sounds.instance.Plunger();
                Sounds.instance.Game();
            }
        }
    }

    public void OnTouch(bool touchDown) {
        if (touchDown)
        {
            fire = true;
        }
        else
        {
            fire = false;
            if (Gameplay.ball <= 3)
            {
                Gameplay.gameplay = true;
                Sounds.instance.Plunger();
                Sounds.instance.Game();
            }
        }
    }

    private void FixedUpdate()
    {
        if (fire && moveCount < distance)
        {
            transform.Translate(0f, 0f, -speed * Time.deltaTime);
            moveCount += speed * Time.deltaTime;
        }
        // Shoot the ball
        if (!fire && moveCount > 0f)
        {
            if (ready)
            {
                ball.transform.TransformDirection(Vector3.forward * 10);
                ball.GetComponent<Rigidbody>().AddForce(0f, 0f, moveCount * power);
                ready = false;
            }

            transform.Translate(0f, 0f, 10f * Time.deltaTime);//20f * Time.deltaTime);
            moveCount -= 10f * Time.deltaTime;
        }
        // Reset the object to its initial position
        if (moveCount <= 0f)
        {
            fire = false;
            moveCount = 0f;
            transform.position = initialPosition;
            
        }
    }

}

