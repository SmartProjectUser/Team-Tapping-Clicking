using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingController : MonoBehaviour
{
    static public SavingController I;

    public BoosterUI boosterUI;


    void Awake()
    {
        I = this;
    }
    
    public int ReadCoins()
    {
        return PlayerPrefs.GetInt("coins", 0);
    }

    public void WriteCoins(int val)
    {
        PlayerPrefs.SetInt("coins", val);
    }

    public void SaveBeds(int bedNumber, int numberOfVeg)
    {
        PlayerPrefs.SetInt("bed" + bedNumber, numberOfVeg);
    }

    public void ReadBeds()
    {
        for(int i = 0; i < 4; i++)
        {

        }
    }


}
