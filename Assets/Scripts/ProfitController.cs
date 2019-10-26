using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfitController : MonoBehaviour
{
    public CoinsUIController coinsCntrllrUI;

    private int coins;
    public int Coins
    {
        get
        {
            return coins;
        }
        set
        {
            coins = value;
            SavingController.I.WriteCoins(value);
            coinsCntrllrUI.coinTxt.text = coins.ToString();
        }
    }

    static public ProfitController I;

    void Start()
    {
        I = this;
        Coins = SavingController.I.ReadCoins();
    }
}
