using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragIndicatorScript : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    Camera camera;
    LineRenderer lr;

    public float lineLength; // to adjust force
    public float lineAngle;

    [SerializeField]
    private float applyForce = 20f;

    Vector3 camOffset = new Vector3(0, 0, 500); //???

    [SerializeField] AnimationCurve ac;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // might need to be changed for mobile
        {
            //if linerenderer doesnt exist create it
            if (lr == null)
            {
                lr = gameObject.AddComponent<LineRenderer>();
            }
            lr.enabled = true;
            lr.sortingLayerName = "Front";
          
           
            
            //we want a line with two points
            lr.positionCount = 2;
            //to get our mouse position to our 2d world
            startPos = camera.ScreenToWorldPoint(Input.mousePosition) + camOffset;
            lr.SetPosition(0, startPos);
            lr.useWorldSpace = true; // Disconnect click position from local position of game object
            lr.widthCurve = ac;
            lr.numCapVertices = 10;
        }



        if (Input.GetMouseButton(0))
        {
            endPos = camera.ScreenToWorldPoint(Input.mousePosition) + camOffset;
            lr.SetPosition(1, endPos);
        }

        //calculate the angle of the line
        float angle = (Mathf.Atan2(endPos.y-startPos.y, endPos.x-startPos.x)*180 / Mathf.PI);
        
       // Debug.Log( "The Angle is:" + angle);
        
        // take points from vector to calculate angle that force will be applied
        float length = ((startPos.x - endPos.x) * (startPos.x - endPos.x) +
                        (startPos.y - endPos.y) * (startPos.y - endPos.y)); // calculate the length of line and convert that into force
    
       // Debug.Log( "The Length is:" + length);
        
      
        if (Input.GetMouseButtonUp(0))
        {
           
            lineLength = length;
            lineAngle = angle; 
            lr.enabled = false;
            RigidBodyMovementTest movementTest = new RigidBodyMovementTest();

        }

        

    }
}
