 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{   
    public Image WhiteEffectImage;
    private int effectcontrol = 0;
 
    public Animator layoutAnimator;

    //buttons

    public GameObject Settings_Open;
    public GameObject Settings_Close;
    public GameObject sound_on;
    public GameObject sound_off;
    public GameObject vibration_on;
    public GameObject vibration_off;
    public GameObject iap;
    public GameObject information;


    //buttons_functions

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
    }

    public void Sound_off()
    {
        sound_on.SetActive(true);
        sound_off.SetActive(false);
    }

    public void Vibration_on()
    {
        vibration_on.SetActive(false);
        vibration_off.SetActive(true);
    }

    public void Vibration_off()
    {
        vibration_on.SetActive(true);
        vibration_off.SetActive(false);
    }

    public IEnumerator WhiteEffect()
    {
        WhiteEffectImage.gameObject.SetActive(true);
        while(effectcontrol == 0)
        {
            yield return new WaitForSeconds(0.001f);
            WhiteEffectImage.color += new Color(0,0,0.1f);
            if(WhiteEffectImage.color == new Color (WhiteEffectImage.color.r, WhiteEffectImage.color.g, WhiteEffectImage.color.b,1))
            {
                effectcontrol = 1;
            }
        }

        while(effectcontrol == 1)
        {
             yield return new WaitForSeconds(0.001f);
             WhiteEffectImage.color -= new Color(0,0,0.1f);
             if(WhiteEffectImage.color == new Color (WhiteEffectImage.color.r, WhiteEffectImage.color.g, WhiteEffectImage.color.b,0))
            {
                effectcontrol = 2;
            }
        }

        if(effectcontrol ==2)
        {
            Debug.Log("işlem tamam");
            
        }
    }
}
