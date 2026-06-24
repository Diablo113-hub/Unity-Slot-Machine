using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesNo : MonoBehaviour
{
    public GameObject jackpot;
    public GameObject cherry;
    public GameObject bar;
    public GameObject bell;
    // Start is called before the first frame update
   public void Yes()
    {
        jackpot.SetActive(false);
        cherry.SetActive(false);
        bar.SetActive(false);
        bell.SetActive(false);
    }

    // Update is called once per frame
   public void No()
    {
        
    }
}
