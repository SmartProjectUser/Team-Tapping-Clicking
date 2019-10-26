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
            ProfitController.I.Coins += profit;
            yield return new WaitForSeconds(2f);
        }
    }

    public void Click()
    {
        ProfitController.I.Coins += clickProfit;
    }
}
