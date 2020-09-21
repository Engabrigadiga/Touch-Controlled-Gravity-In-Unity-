using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovementTest : MonoBehaviour
{
        
    public GameObject DragIndcator;
    private DragIndicatorScript _dragIndicatorScript;
    private Vector3 dir;
    
    
    private float speed;
    public Vector2 movement;
    public Rigidbody2D rb2d;
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        _dragIndicatorScript = DragIndcator.GetComponent<DragIndicatorScript>();
    }

    void Update()
    {
        //get a vector of the line drawn
        speed = _dragIndicatorScript.lineLength;
        
        Debug.Log("PLEASE HAVE VALUES: " + _dragIndicatorScript.lineLength + "\t" + _dragIndicatorScript.lineAngle);
        
        //movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Debug.Log( "movement vector is: "+movement);

       // float angle = _dragIndicatorScript.lineAngle;
        dir = Quaternion.AngleAxis(_dragIndicatorScript.lineAngle, Vector3.forward) * Vector3.right;
    }

    private void FixedUpdate() //is run every psysics step instead of every frame
    {
        MoveCharacter(movement);
    }


    void MoveCharacter(Vector2 direction)
    {
        /* Ways to move our object with rigid body: 
         1)RigidBody.AddForce()
                Adds a force to a object
         2)RigidBody.velocity
         3)RigidBody.movePosition
         */
        
        Vector2 vertTest = new Vector2(direction.x,(direction.y) * 10);

         rb2d.AddForce(dir * speed);

         //rb2d.velocity = direction * speed;
         // rb2d.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}
