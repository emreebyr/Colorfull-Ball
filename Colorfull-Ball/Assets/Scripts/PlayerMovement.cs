using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
   private Touch touch;

   [Range(1,10)]
   public float speedModifier;

   private Rigidbody rb;

   public int forwardSpeed;

   public GameObject cam;
   public Transform vectorback;
   public Transform vectorforward;



   

public  void Start() 
{
    rb = GetComponent<Rigidbody>();
}

   public void Update()
   {
        if(Variables.firstTouch ==1)
        {
            transform.position += new Vector3(0,0,forwardSpeed*Time.deltaTime);
            cam.transform.position += new Vector3(0,0,forwardSpeed*Time.deltaTime);
            vectorback.transform.position += new Vector3(0,0,forwardSpeed*Time.deltaTime);
            vectorforward.transform.position += new Vector3(0,0,forwardSpeed*Time.deltaTime);
        }


        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                Variables.firstTouch = 1;
            }

            if(touch.phase == TouchPhase.Moved)
            {
                rb.velocity = new Vector3         (touch.deltaPosition.x * speedModifier,
                                                  transform.position.y,
                                                  touch.deltaPosition.y * speedModifier);
            }
            else if(touch.phase ==TouchPhase.Ended)
            {
                //rb.velocity = new Vector3(0,0,0);
                rb.velocity = Vector3.zero;
            }
        }
   }


}

