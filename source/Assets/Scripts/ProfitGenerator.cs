using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfitGenerator : MonoBehaviour
{
    public GameObject vegPrefab;
    public Transform bed;
    public int profit;
    public int clickProfit;

    void Start()
    {
        StartCoroutine(EndlessProfit());
    }

    IEnumerator EndlessProfit()
    {
        VegetableDetector[] vegs = bed.GetComponentsInChildren<VegetableDetector>();
        int count = vegs.Length;
        for (; ;)
        {
            // int number = Random.Range(0, count);
            // GameObject harvest = Instantiate(vegPrefab, vegs[number].transform);
            MakeCoins((int)(profit * BoostersController.PassiveMultiplier()));
            yield return new WaitForSeconds(5f);
        }
    }

    public void Click()
    {
        MakeCoins((int)(clickProfit * BoostersController.ActiveMultiplier()));
    }

    private void MakeCoins(int coins)
    {
        ProfitController.I.Coins += coins;
        if (coins > 0)
            UIController.ShowProfit(transform.position, coins);
    }
}
