using TMPro;
using UnityEngine;

public class coinCounter : MonoBehaviour
{
    public GameObject coinCount;
    private TextMeshProUGUI coinText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        int coins = coinCount.GetComponent<player>().getCoins();
        coinText.SetText(coins + " Coins");
    }
}
