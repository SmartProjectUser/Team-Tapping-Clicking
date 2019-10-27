using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Boost
{
    [SerializeField]
    public int price;
    [SerializeField]
    public float multiplier;
}

public class BoostersController : MonoBehaviour
{
    public static BoostersController I;
    public BoosterUI boosterUI;

    public Boost[] clickBoosters;
    public Boost[] passiveBoosters;

    private int passiveBoost;
    public int PassiveBoost
    {
        get
        {
            return passiveBoost;
        }
        set
        {
            passiveBoost = value;
            SavingController.I.WritePassiveBoosts(value);
        }
    }

    private int activeBoost;
    public int ActiveBoost
    {
        get
        {
            return activeBoost;
        }
        set
        {
            activeBoost = value;
            SavingController.I.WriteActiveBoosts(value);
        }
    }

    void Start()
    {
        I = this;
        passiveBoost = SavingController.I.ReadPassiveBoosts();
        activeBoost = SavingController.I.ReadActiveBoosts();
    }

    public static float PassiveMultiplier()
    {
        return I.passiveBoosters[I.PassiveBoost].multiplier;
    }

    public static float ActiveMultiplier()
    {
        return I.clickBoosters[I.ActiveBoost].multiplier;
    }
}
