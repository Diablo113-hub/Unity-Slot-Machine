using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    // Audio source component
    [SerializeField] AudioSource sfx;

    // Win sound effect
    public AudioClip MoneyRecived;

    // Coin button sound
    public AudioClip coin;

    // Play win sound
    public void Click()
    {
        sfx.PlayOneShot(MoneyRecived);
    }

    // Play coin sound
    public void yesbt()
    {
        sfx.PlayOneShot(coin);
    }
}