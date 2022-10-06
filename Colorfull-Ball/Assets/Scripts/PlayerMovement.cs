using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
   private Touch touch;
   public float speedModifier;
   private Rigidbody rb;

public  void Start() 
{
    rb = GetComponent<Rigidbody>();
}

   public void Update()
   {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                rb.velocity = new Vector3         (touch.deltaPosition.x * speedModifier,
                                                  transform.position.y,
                                                  touch.deltaPosition.y * speedModifier);
            }
        }
   }


}

