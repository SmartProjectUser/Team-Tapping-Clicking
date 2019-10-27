using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableController : MonoBehaviour
{
    public List<Vegetable> vegetables;

    private int openedPlants;
    public int OpenedPlants
    {
        get
        {
            return openedPlants;
        }
        set
        {
            openedPlants = value;
            SavingController.I.WritePlants(value);
        }
    }

    public int[] prices;

    [System.NonSerialized]
    static public VegetableController I;

    private void Start()
    {
        I = this;
        openedPlants = SavingController.I.ReadPlants();
    }
}
