using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetablesSpawner : MonoBehaviour
{
    ProfitGenerator pg;
    public int WhoAMI()
    {
        AlreadyExistedVegetablesSpawner parent = this.GetComponentInParent<AlreadyExistedVegetablesSpawner>();
        VegetablesSpawner[] spawners = parent.GetComponentsInChildren<VegetablesSpawner>();
        for (int i = 0; i < spawners.Length; i++)
        {
            if (spawners[i] == this)
            {
                return i;
            }
        }
        return 0;
    }
    
    public void SpawnVegatables(GameObject prefab, Transform parent, int profit, int clickProfit)
    {
        GameObject veg = new GameObject();
        float xP = -2.5f;
        float zP = 1.5f;
        for(int i = 0; i < 2; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                veg = Instantiate(prefab, this.transform);
                veg.transform.localPosition = new Vector3(xP, 0, zP);
                xP += 2.5f;
            }
            zP -= 3f;
            xP = -2.5f;
        }
        pg = veg.AddComponent<ProfitGenerator>();
        pg.vegPrefab = prefab;
        pg.bed = parent;
        pg.profit = profit;
        pg.clickProfit = clickProfit;
    }

    public void FindBedAndSave(int numberOfVegetable)
    {
        SavingController.I.SaveBeds(WhoAMI(), numberOfVegetable);
        Debug.Log("bed - " + WhoAMI() + "; veg - " + numberOfVegetable);
    }

    public void OnMouseDown()
    {
        pg.Click();
    }
}
