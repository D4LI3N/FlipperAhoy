using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject ball;
    public float force;

    private Rigidbody rigidbodyBall;


    private void Awake()
    {
       rigidbodyBall = ball.GetComponent<Rigidbody>();
    }


    //void OnTriggerEnter(Collider other)
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Untagged") Debug.Log("Hit " + other.gameObject.tag);

        switch (other.gameObject.tag)
        {
            case "Sea":
                Gameplay.instance.RestartLevel();
                break;
            case "Barrel1":
                rigidbodyBall.AddExplosionForce(force, other.contacts[0].point, 3);
                Gameplay.instance.AddPoints(1);
                break;
            case "Barrel2":
                rigidbodyBall.AddExplosionForce(force, other.contacts[0].point, 3);
                Gameplay.instance.AddPoints(2);
                break;
            case "Barrel3":
                rigidbodyBall.AddExplosionForce(force, other.contacts[0].point, 3);
                Gameplay.instance.AddPoints(3);
                break;
            case "Bumper":
                rigidbodyBall.AddExplosionForce(force-2, other.contacts[0].point,1);
                Sounds.instance.Plunger();
                break;

        }
        //yield return new WaitForSeconds(1);

    }


}
