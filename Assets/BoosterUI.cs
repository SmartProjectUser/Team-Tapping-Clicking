using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosterUI : MonoBehaviour
{
    public Text activeBooster;
    public Text passiveBooster;
    public Text newVegetable;


    private void Start()
    {
        if (VegetableController.I.OpenedPlants < VegetableController.I.vegetables.Count)
        {
            int newprice = VegetableController.I.prices[VegetableController.I.OpenedPlants];
            newVegetable.text = "Buy vegetable: " + newprice.ToString();
        } else
        {
            newVegetable.transform.parent.gameObject.SetActive(false);
        }
    }

    public void SetValues()
    {
      //  activeBooster.text = "active multiplier: x1 \n " + BoostersController.I.costOfActiveProfit.ToString();
    }

    public void BuyVegetable()
    {
        int price = VegetableController.I.prices[VegetableController.I.OpenedPlants];
        if (ProfitController.I.Coins >= price)
        {
            VegetableController.I.OpenedPlants += 1;
            ProfitController.I.Coins -= price;
            if (VegetableController.I.OpenedPlants < VegetableController.I.vegetables.Count)
            {
                int newprice = VegetableController.I.prices[VegetableController.I.OpenedPlants];
                newVegetable.text = "Buy vegetable: " + newprice.ToString();
            } else
            {
                newVegetable.transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
