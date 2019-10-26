using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableController : MonoBehaviour
{
    public List<Vegetable> vegetables;

    [System.NonSerialized]
    static public VegetableController I;

    private void Start()
    {
        I = this;
    }
}
