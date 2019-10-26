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
            newVegetable.text = "Buy vegetable\n$" + newprice.ToString();
        } else
        {
            newVegetable.transform.parent.gameObject.SetActive(false);
        }

        if (BoostersController.I.ActiveBoost + 1 < BoostersController.I.clickBoosters.Length)
        {
            Boost newboost = BoostersController.I.clickBoosters[BoostersController.I.ActiveBoost + 1];
            int newprice = newboost.price;
            activeBooster.text = string.Format(
                "Buy equipment\nx{0} --> x{1}\n${2}", 
                BoostersController.ActiveMultiplier(),
                newboost.multiplier,
                newprice
            );
        }
        else
        {
            activeBooster.text = string.Format(
                "Equipment\nx{0}",
                BoostersController.ActiveMultiplier()
            );
            activeBooster.transform.parent.GetComponent<Button>().interactable = false;
        }

        if (BoostersController.I.PassiveBoost + 1 < BoostersController.I.passiveBoosters.Length)
        {
            Boost newboost = BoostersController.I.passiveBoosters[BoostersController.I.PassiveBoost + 1];
            int newprice = newboost.price;
            passiveBooster.text = string.Format(
                "Buy worker\nx{0} --> x{1}\n${2}",
                BoostersController.PassiveMultiplier(),
                newboost.multiplier,
                newprice
            );
        }
        else
        {
            passiveBooster.text = string.Format(
                "Workers\nx{0}",
                BoostersController.PassiveMultiplier()
            );
            passiveBooster.transform.parent.GetComponent<Button>().interactable = false;
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
                newVegetable.text = "Buy vegetable\n$" + newprice.ToString();
            } else
            {
                newVegetable.transform.parent.gameObject.SetActive(false);
            }
        }
    }

    public void BuyActiveBoost()
    {
        int price = BoostersController.I.clickBoosters[BoostersController.I.ActiveBoost + 1].price;
        if (ProfitController.I.Coins >= price)
        {
            BoostersController.I.ActiveBoost += 1;
            ProfitController.I.Coins -= price;
            if (BoostersController.I.ActiveBoost + 1 < BoostersController.I.clickBoosters.Length)
            {
                Boost newboost = BoostersController.I.clickBoosters[BoostersController.I.ActiveBoost + 1];
                int newprice = newboost.price;
                activeBooster.text = string.Format(
                    "Buy equipment\nx{0} --> x{1}\n${2}",
                    BoostersController.ActiveMultiplier(),
                    newboost.multiplier,
                    newprice
                );
            }
            else
            {
                activeBooster.text = string.Format(
                    "Equipment\nx{0}",
                    BoostersController.ActiveMultiplier()
                );
                activeBooster.transform.parent.GetComponent<Button>().interactable = false;
            }
        }
    }

    public void BuyPassiveBoost()
    {
        int price = BoostersController.I.passiveBoosters[BoostersController.I.PassiveBoost + 1].price;
        if (ProfitController.I.Coins >= price)
        {
            BoostersController.I.PassiveBoost += 1;
            ProfitController.I.Coins -= price;
            if (BoostersController.I.PassiveBoost + 1 < BoostersController.I.passiveBoosters.Length)
            {
                Boost newboost = BoostersController.I.passiveBoosters[BoostersController.I.PassiveBoost + 1];
                int newprice = newboost.price;
                passiveBooster.text = string.Format(
                    "Buy worker\nx{0} --> x{1}\n${2}",
                    BoostersController.PassiveMultiplier(),
                    newboost.multiplier,
                    newprice
                );
            }
            else
            {
                passiveBooster.text = string.Format(
                    "Workers\nx{0}",
                    BoostersController.PassiveMultiplier()
                );
                passiveBooster.transform.parent.GetComponent<Button>().interactable = false;
            }
        }
    }
}
