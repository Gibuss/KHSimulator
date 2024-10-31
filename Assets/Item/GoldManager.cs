using UnityEngine;
using TMPro;

public class GoldManager : MonoBehaviour
{
    public int currentGold = 0;
    public TMP_Text goldText;

    private void Start()
    {
        UpdateGoldText();
    }

    public void AddGold(int amount)
    {
        currentGold += amount;
        UpdateGoldText();
    }

    private void UpdateGoldText()
    {
        if (goldText != null)
        {
            goldText.text = "Gold: " + currentGold.ToString();
        }
    }
}
