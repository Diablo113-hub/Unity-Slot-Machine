using TMPro;
using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.UI;

public class Lever : MonoBehaviour
{[Header("SCORE")]
  [Space(10)]
    public int coin = 200;
    public int SpinCost = 10;
    public TMP_Text score;

    [Space(10)]
    [Header("UI")]
[Space(10)]
    public GameObject leverUP;
    public GameObject leverDown;
    public GameObject JackpotPanel;
    public GameObject CherryPanel;
    public GameObject bellPanel;
    public GameObject barPanel;
[Header("SYMBOLS")]
[Space(10)]
    public Sprite[] symbols;
    public Sprite jackpot;
    public Sprite cherry ;
    public Sprite bell; 
    public Sprite bar;
[Header("SLOTS")]
[Space(10)]
    public SpriteRenderer slot1;
    public GameObject Slot1;
    public SpriteRenderer slot2;
    public GameObject Slot2;
    public SpriteRenderer slot3;
    public GameObject Slot3;

[Header("BT")]
[Space(10)]
public Button leaverbt;
[Space(20)]
[Header("Anim")]
[Space(10)]

public Animator spin;
public Animator spin2;
public Animator spin3;

     void Start()
    {
        UpdateScore();
    }

    public void LeverButton()
    {
        leverDown.SetActive(true);
        leverUP.SetActive(false);
        leaverbt.interactable = false;
        spin.SetTrigger("Spin");
        Invoke(nameof(StopSpin),2f);
        Invoke(nameof(onsprite),2.4f);
        spin2.SetTrigger("spin2");
        Invoke(nameof(onsprite2),2.7f);
        spin3.SetTrigger("spin3");
        Invoke(nameof(onsprite3),3f);


        coin -= SpinCost;
        UpdateScore();
        

        Slot1.SetActive(false);
        Slot2.SetActive(false);
        Slot3.SetActive(false);

        int randomSymbol = Random.Range(0, symbols.Length);
        int randomSymbol2 = Random.Range(0, symbols.Length);
        int randomSymbol3 = Random.Range(0, symbols.Length);

        Sprite selectedSymbol1 = symbols[randomSymbol];
        Sprite selectedSymbol2 = symbols[randomSymbol2];
        Sprite selectedSymbol3 = symbols[randomSymbol3];

        slot1.sprite = selectedSymbol1;
        slot2.sprite = selectedSymbol2;
        slot3.sprite = selectedSymbol3;

        if (selectedSymbol1 == selectedSymbol2 &&
            selectedSymbol2 == selectedSymbol3 )
        {
            if(selectedSymbol1 == jackpot)
            { 
             Invoke(nameof(jackPrize),3.5f);
             
            }
            if (selectedSymbol1 == cherry)
            {
                Invoke(nameof(CherryPrize),3.5f);
                
            }
            if (selectedSymbol1 == bar)
            {
                Invoke(nameof(BarPrize),3.5f);
               
            }
            if (selectedSymbol1 == bell)
            {
                Invoke(nameof(BellPrize),3.5f);
               
            }
            UpdateScore();
        }

        Invoke(nameof(ResetLever), 1f);
    }
    public void UpdateScore()
    {
        score.text = "Coin = " + coin;
    }

    public void jackPrize()
    {
         JackpotPanel.SetActive(true);
             coin+=200;
               UpdateScore();
    }
    public void CherryPrize()
    {
        CherryPanel.SetActive(true);
                coin+=50;
                  UpdateScore();
    }
    public void BarPrize()
    {
         barPanel.SetActive(true);
                coin+=100;
                  UpdateScore();
    }
    public void BellPrize()
    {
         bellPanel.SetActive(true);
                coin+=150;
                  UpdateScore();
    }

    public void ResetLever()
    {
        
        leverDown.SetActive(false);
        leverUP.SetActive(true);
        
    }
    public void StopSpin()
    {
        spin.SetTrigger("stop");
        
    }
    public void onsprite()
    {   spin2.SetTrigger("stop2");
        Slot1.SetActive(true);
        
       
    }
    public void onsprite2()
    {
        spin3.SetTrigger("stop3");
        Slot2.SetActive(true);
    }
    public void onsprite3()
    {   leaverbt.interactable=true;
        Slot3.SetActive(true);
    }
}