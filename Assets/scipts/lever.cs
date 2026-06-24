using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Lever : MonoBehaviour
{
    // ================= SCORE =================
    [Header("SCORE")]
    [Space(10)]

    // Player total coins
    public int coin = 200;

    // Coins used per spin
    public int SpinCost = 10;

    // Score text UI
    public TMP_Text score;

    // ================= UI =================
    [Space(10)]
    [Header("UI")]
    [Space(10)]

    // Lever visuals
    public GameObject leverUP;
    public GameObject leverDown;

    // Win panels
    public GameObject JackpotPanel;
    public GameObject CherryPanel;
    public GameObject bellPanel;
    public GameObject barPanel;

    // ================= SYMBOLS =================
    [Header("SYMBOLS")]
    [Space(10)]

    // All slot symbols
    public Sprite[] symbols;

    // Specific winning symbols
    public Sprite jackpot;
    public Sprite cherry;
    public Sprite bell;
    public Sprite bar;

    // ================= SLOTS =================
    [Header("SLOTS")]
    [Space(10)]

    // Slot sprite renderers
    public SpriteRenderer slot1;
    public GameObject Slot1;

    public SpriteRenderer slot2;
    public GameObject Slot2;

    public SpriteRenderer slot3;
    public GameObject Slot3;

    // ================= BUTTON =================
    [Header("BT")]
    [Space(10)]

    // Spin button
    public Button leaverbt;

    // ================= ANIMATION =================
    [Space(20)]
    [Header("Anim")]
    [Space(10)]

    // Reel animators
    public Animator spin;
    public Animator spin2;
    public Animator spin3;

    // Runs at game start
    void Start()
    {
        UpdateScore();
    }

    // Spin button function
    public void LeverButton()
    {
        // Lever animation
        leverDown.SetActive(true);
        leverUP.SetActive(false);

        // Disable button while spinning
        leaverbt.interactable = false;

        // Start reel animations
        spin.SetTrigger("Spin");
        spin2.SetTrigger("spin2");
        spin3.SetTrigger("spin3");

        // Stop reel animations with delay
        Invoke(nameof(StopSpin), 2f);
        Invoke(nameof(onsprite), 2.4f);
        Invoke(nameof(onsprite2), 2.7f);
        Invoke(nameof(onsprite3), 3f);

        // Remove spin cost
        coin -= SpinCost;
        UpdateScore();

        // Hide symbols while spinning
        Slot1.SetActive(false);
        Slot2.SetActive(false);
        Slot3.SetActive(false);

        // Generate random symbols
        int randomSymbol = Random.Range(0, symbols.Length);
        int randomSymbol2 = Random.Range(0, symbols.Length);
        int randomSymbol3 = Random.Range(0, symbols.Length);

        // Store selected symbols
        Sprite selectedSymbol1 = symbols[randomSymbol];
        Sprite selectedSymbol2 = symbols[randomSymbol2];
        Sprite selectedSymbol3 = symbols[randomSymbol3];

        // Apply symbols to slots
        slot1.sprite = selectedSymbol1;
        slot2.sprite = selectedSymbol2;
        slot3.sprite = selectedSymbol3;

        // Check win condition
        if (selectedSymbol1 == selectedSymbol2 &&
            selectedSymbol2 == selectedSymbol3)
        {
            // Jackpot reward
            if (selectedSymbol1 == jackpot)
            {
                Invoke(nameof(jackPrize), 3.5f);
            }

            // Cherry reward
            if (selectedSymbol1 == cherry)
            {
                Invoke(nameof(CherryPrize), 3.5f);
            }

            // Bar reward
            if (selectedSymbol1 == bar)
            {
                Invoke(nameof(BarPrize), 3.5f);
            }

            // Bell reward
            if (selectedSymbol1 == bell)
            {
                Invoke(nameof(BellPrize), 3.5f);
            }

            UpdateScore();
        }

        // Reset lever animation
        Invoke(nameof(ResetLever), 1f);
    }

    // Update score text
    public void UpdateScore()
    {
        score.text = "Coin = " + coin;
    }

    // Jackpot reward
    public void jackPrize()
    {
        JackpotPanel.SetActive(true);

        coin += 200;

        UpdateScore();
    }

    // Cherry reward
    public void CherryPrize()
    {
        CherryPanel.SetActive(true);

        coin += 50;

        UpdateScore();
    }

    // Bar reward
    public void BarPrize()
    {
        barPanel.SetActive(true);

        coin += 100;

        UpdateScore();
    }

    // Bell reward
    public void BellPrize()
    {
        bellPanel.SetActive(true);

        coin += 150;

        UpdateScore();
    }

    // Reset lever visuals
    public void ResetLever()
    {
        leverDown.SetActive(false);
        leverUP.SetActive(true);
    }

    // Stop first reel
    public void StopSpin()
    {
        spin.SetTrigger("stop");
    }

    // Show first slot symbol
    public void onsprite()
    {
        spin2.SetTrigger("stop2");

        Slot1.SetActive(true);
    }

    // Show second slot symbol
    public void onsprite2()
    {
        spin3.SetTrigger("stop3");

        Slot2.SetActive(true);
    }

    // Show third slot symbol
    public void onsprite3()
    {
        // Enable button again
        leaverbt.interactable = true;

        Slot3.SetActive(true);
    }
}