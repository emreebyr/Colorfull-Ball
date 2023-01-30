using UnityEngine;

public class Destroyer : MonoBehaviour

{
    private void OnCollisionEnter(Collision collision)
    {

        collision.gameObject.SetActive(false);

    }










}

