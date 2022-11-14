 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{   
    public Image WhiteEffectImage;
    private int effectcontrol = 0;

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
