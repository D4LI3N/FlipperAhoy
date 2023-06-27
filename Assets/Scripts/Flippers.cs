using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Flippers : MonoBehaviour
{

    public GameObject flipperButton;
    public float restPosition = 0f;
    public float pressedPosition = 45f;
    public float strength = 12000f;
    public float damper = 1f;

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
        Debug.Log("Flippers");

    }


    //Keyboard
    public void OnFlipperPress(InputAction.CallbackContext context)
    {
        Debug.Log("OnFlipperPress");
        if (context.performed) {
            FlipperUp(true);
        } else if (context.canceled) {
            FlipperUp(false);
        }
    }

    //Touch



    public void FlipperUp(bool up) {
        //Debug.Log("Flipper");
        HingeJoint hingeJoint = GetComponent<HingeJoint>();
        hingeJoint.useSpring = true;
        JointSpring spring = new JointSpring();

        spring.spring = strength;
        spring.damper = damper;

        if (up)
        {
            spring.targetPosition = pressedPosition;
            Sounds.instance.Flipper();
        }
        else
        {
            spring.targetPosition = restPosition;
        }

        hingeJoint.spring = spring;
        hingeJoint.useLimits = true;
        JointLimits limits = hingeJoint.limits;
        limits.min = restPosition;
        limits.max = pressedPosition;
        hingeJoint.limits = limits;
    }


}

