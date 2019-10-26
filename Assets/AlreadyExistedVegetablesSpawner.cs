using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class AlreadyExistedVegetablesSpawner : MonoBehaviour
{

    void Start()
    {
       // CheckExistVegs();
        // VegetablesSpawner[] spawners = parentOfBeds.GetComponentsInChildren<VegetablesSpawner>();
       



        /*for(int i = 0; i < spawners.Length; i++)
        {
            int curVeg = PlayerPrefs.GetInt("bed" + i, -1);
            Debug.Log("player prefs - " + "bed" + i + " = " + curVeg);
            if(curVeg != -1)
            {
                Debug.Log(curVeg.ToString() + VegetableController.I.vegetables[curVeg].name);

               // GameObject pref = VegetableController.I.vegetables[curVeg].prefab;
                //int profit = VegetableController.I.vegetables[curVeg].profit;
                //spawners[i].SpawnVegatables(pref, spawners[i].transform, profit);
            }
        }*/
    }

    public void CheckExistVegs()
    {
        List<Vegetable> vegs = VegetableController.I.vegetables;

        Debug.Log("access - " + vegs.Count);
    }

   
}
