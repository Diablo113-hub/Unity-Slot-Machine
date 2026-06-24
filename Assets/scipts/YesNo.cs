using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesNo : MonoBehaviour
{
    // Jackpot panel
    public GameObject jackpot;

    // Cherry win panel
    public GameObject cherry;

    // Bar win panel
    public GameObject bar;

    // Bell win panel
    public GameObject bell;

    // YES button function
    public void Yes()
    {
        // Hide all win panels
        jackpot.SetActive(false);
        cherry.SetActive(false);
        bar.SetActive(false);
        bell.SetActive(false);
    }
    }