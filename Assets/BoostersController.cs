using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostersController : MonoBehaviour
{
    public static BoostersController I;
    public BoosterUI boosterUI;

    public int passiveProfitMultiplier;
    public int activeProfitMultiplier;

    public int costOfPassiveProfit;

    public int costOfActiveProfit;

    public int costOfNewVegetable;


    void Awake()
    {
        I = this;
    }

    public void BuyActiveMultiplier()
    {
        activeProfitMultiplier += 1;

    }

   
}
