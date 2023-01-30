using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public int forwardCamSpeed;


    // Update is called once per frame
    void Update()
    {
        if (GameManager.firstTouch == 1)
        {
            transform.position += new Vector3(0, 0, forwardCamSpeed * Time.deltaTime);
        }
    }
}
