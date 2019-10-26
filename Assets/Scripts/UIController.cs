using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject plantingMenu;
    public GameObject lowerMenu;
    public GameObject deletingMenu;
    public GameObject boostersMenu;

    public GameObject profitText;

    public static UIController Singleton;

    public void Awake()
    {
        Singleton = this;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
            OpenLowerMenu();
    }

    public void OpenPlantingMenu()
    {
        CloseTabs();
        plantingMenu.SetActive(true);
        plantingMenu.GetComponent<PlantingMenuController>().CreateListOfVegetables();
    }

    public void OpenDeletingMenu()
    {
        CloseTabs();
        deletingMenu.SetActive(true);
    }

    void OpenLowerMenu()
    {
        CloseAll();
        lowerMenu.SetActive(true);
    }

    public void OpenBoosterMenu()
    {
        CloseTabs();
        boostersMenu.SetActive(true);
    }

    void CloseAll()
    {
        plantingMenu.SetActive(false);
        lowerMenu.SetActive(false);
        deletingMenu.SetActive(false);
        boostersMenu.SetActive(false);
    }

    void CloseTabs()
    {
        plantingMenu.SetActive(false);
        deletingMenu.SetActive(false);
        boostersMenu.SetActive(false);
    }

    public static void ShowProfit(Vector3 pos, int profit)
    {
        Vector3 p = Camera.main.WorldToScreenPoint(pos);
        GameObject g = Instantiate(Singleton.profitText, Singleton.transform);
        g.GetComponent<RectTransform>().position = p;
        g.GetComponent<Text>().text = profit.ToString();
    }
}
