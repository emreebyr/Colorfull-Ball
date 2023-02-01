using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uimanager;
    
    public static int firstTouch = 0;
    public static bool movable=true;
    public static bool firstTouchControl=false;


    private void Start()
    {
        CoinCalculator(0);

        //CameraFollow camFollow = GetComponent<CameraFollow>();
   
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && gameObject.CompareTag("Finish"))
        {
            CoinCalculator(100);
            Debug.Log(PlayerPrefs.GetInt("moneyy"));
            uimanager.coinText_Update();

            Invoke("finisher", 1.25f);

        }
    }

    public void CoinCalculator(int money)
    {
        if (PlayerPrefs.HasKey("moneyy"))
        {
            int oldScore = PlayerPrefs.GetInt("moneyy");
            PlayerPrefs.SetInt("moneyy", oldScore + money);
            
        }

        else
            PlayerPrefs.SetInt("moneyy", 0);
    }

    public void finisher ()
    {
        movable = false;
            
    }
}
