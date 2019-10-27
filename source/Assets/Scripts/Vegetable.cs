using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Vegetable", menuName = "Vegetable", order = 51)]
public class Vegetable : ScriptableObject
{
    [SerializeField]
    public GameObject prefab;

    [SerializeField]
    public string nameOfVeg;

    [SerializeField]
    public Sprite img;

    [SerializeField]
    public int profit;

    [SerializeField]
    public int clickProfit;
}
