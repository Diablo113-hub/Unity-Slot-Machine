using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    [SerializeField] AudioSource sfx;
    public AudioClip MoneyRecived;
    public AudioClip coin;
    // Start is called before the first frame update
  public void Click()
    {
        sfx.PlayOneShot(MoneyRecived);
        
    }
    public void yesbt()
    {
        sfx.PlayOneShot(coin);
    }
  
}
