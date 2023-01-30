using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image WhiteEffectImage;
    private int effectcontrol = 0;

    public Animator layoutAnimator;
    public TextMeshProUGUI coin_Text;

    //buttons

    public GameObject Settings_Open;
    public GameObject Settings_Close;
    public GameObject layout_Background;
    public GameObject sound_on;
    public GameObject sound_off;
    public GameObject vibration_on;
    public GameObject vibration_off;
    public GameObject iap;
    public GameObject information;
    public GameObject Restart_Screen;

    //startingUIcontrol

    public GameObject easyuse;
    public GameObject startingtext;
    public GameObject noads_button;
    public GameObject shop_button;

    public void Start()
    {
        if (PlayerPrefs.HasKey("Sound") == false)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }

        if (PlayerPrefs.HasKey("Vibration") == false)
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }

        coinText_Update();
    }

    //buttons_functions

    public void firstTouch_Destroy()
    {

        Settings_Open.SetActive(false);
        Settings_Close.SetActive(false);
        sound_on.SetActive(false);
        sound_off.SetActive(false);
        vibration_on.SetActive(false);
        vibration_off.SetActive(false);
        iap.SetActive(false);
        information.SetActive(false);
        easyuse.SetActive(false);
        startingtext.SetActive(false);
        noads_button.SetActive(false);
        shop_button.SetActive(false);
        layout_Background.SetActive(false);

    }

    public void coinText_Update()
    {
        coin_Text.text = PlayerPrefs.GetInt("moneyy").ToString();
    }

    public void RestartButtonActive()
    {
        Restart_Screen.SetActive(true);
    }

    public void restart_scene()
    {
        GameManager.firstTouch = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }


    public void privacy_Policy()
    {
        Application.OpenURL("https://www.google.com.tr/");
    }

    public void TermOff_Use()
    {
        Application.OpenURL("https://www.google.com.tr/");
    }

    public void settings_Open()
    {
        Settings_Open.SetActive(false);
        Settings_Close.SetActive(true);
        layoutAnimator.SetTrigger("Slide_in");


        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            sound_on.SetActive(true);
            sound_off.SetActive(false);
            AudioListener.volume = 1;
        }

        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            sound_on.SetActive(false);
            sound_off.SetActive(true);
            AudioListener.volume = 2;
        }

        if (PlayerPrefs.GetInt("Vibration") == 1)
        {

            vibration_on.SetActive(true);
            vibration_off.SetActive(false);

        }

        else if (PlayerPrefs.GetInt("Vibration") == 2)
        {
            vibration_on.SetActive(false);
            vibration_off.SetActive(true);
        }

    }

    public void settings_Close()
    {
        Settings_Open.SetActive(true);
        Settings_Close.SetActive(false);
        layoutAnimator.SetTrigger("Slide_out");
    }

    public void Sound_on()
    {
        sound_on.SetActive(false);
        sound_off.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);
    }

    public void Sound_off()
    {
        sound_on.SetActive(true);
        sound_off.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);
    }

    public void Vibration_on()
    {
        vibration_on.SetActive(false);
        vibration_off.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 2);
    }

    public void Vibration_off()
    {
        vibration_on.SetActive(true);
        vibration_off.SetActive(false);
        PlayerPrefs.SetInt("Vibration", 1);
    }

    public IEnumerator WhiteEffect()
    {
        WhiteEffectImage.gameObject.SetActive(true);
        while (effectcontrol == 0)
        {
            yield return new WaitForSeconds(0.001f);
            WhiteEffectImage.color += new Color(0, 0, 0.1f);
            if (WhiteEffectImage.color == new Color(WhiteEffectImage.color.r, WhiteEffectImage.color.g, WhiteEffectImage.color.b, 1))
            {
                effectcontrol = 1;
            }
        }

        while (effectcontrol == 1)
        {
            yield return new WaitForSeconds(0.001f);
            WhiteEffectImage.color -= new Color(0, 0, 0.1f);
            if (WhiteEffectImage.color == new Color(WhiteEffectImage.color.r, WhiteEffectImage.color.g, WhiteEffectImage.color.b, 0))
            {
                effectcontrol = 2;
            }
        }
    }
}
