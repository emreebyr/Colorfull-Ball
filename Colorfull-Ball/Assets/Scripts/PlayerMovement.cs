using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    private Touch touch;

    [Range(1, 10)]
    public float speedModifier;

    public Rigidbody rb;

    public int forwardSpeed;

    public GameObject cam;
    public GameObject effect;
    public Transform vectorback;
    public Transform vectorforward;

    public CameraShake cameraShake;
    public UIManager uimanager;
    private bool movable;
    private bool firstTouchControl = false;


    // deneme

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        movable = true;
    }

    public void Update()
    {

        // Debug.Log(AudioListener.volume);

        if (movable == true)
        {

            if (GameManager.firstTouch == 1)
            {
                transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
                //effect.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
                vectorback.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
                vectorforward.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);

            }

            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))

                    {
                        if (firstTouchControl == false)
                        {
                            GameManager.firstTouch = 1;
                            uimanager.firstTouch_Destroy();
                            firstTouchControl = true;
                        }
                    }
                }

                if (touch.phase == TouchPhase.Moved)
                {

                    if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))

                    {
                        rb.velocity = new Vector3(touch.deltaPosition.x * speedModifier,
                                              transform.position.y,
                                              touch.deltaPosition.y * speedModifier);

                        if (firstTouchControl == false)
                        {

                            GameManager.firstTouch = 1;
                            uimanager.firstTouch_Destroy();
                            firstTouchControl = true;
                            
                        }
                    }

                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    //rb.velocity = new Vector3(0,0,0);
                    rb.velocity = Vector3.zero;
                }
            }
        }
    }

    public GameObject[] FractureItems;


    public void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Obstacles"))
        {

            cameraShake.cameraShakesCall();
            uimanager.StartCoroutine("WhiteEffect");
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            movable = false;

            foreach (GameObject item in FractureItems)
            {
                item.GetComponent<CapsuleCollider>().enabled = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
            }

            StartCoroutine(TimeScaleControl());

        }
    }

    public IEnumerator TimeScaleControl()
    {

        Time.timeScale = 0.4f;
        yield return new WaitForSecondsRealtime(3);
        uimanager.RestartButtonActive();
        rb.velocity = Vector3.zero;
    }

}

