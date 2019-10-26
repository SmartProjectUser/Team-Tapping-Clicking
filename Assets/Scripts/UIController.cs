using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject plantingMenu;
    public GameObject lowerMenu;
    public GameObject deletingMenu;
    public GameObject boostersMenu;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
            OpenLowerMenu();
    }

    public void OpenPlantingMenu()
    {
        CloseAll();
        plantingMenu.SetActive(true);
    }

    public void OpenDeletingMenu()
    {
        CloseAll();
        deletingMenu.SetActive(true);
    }

    void OpenLowerMenu()
    {
        CloseAll();
        lowerMenu.SetActive(true);
    }

    public void OpenBoosterMenu()
    {
        CloseAll();
        boostersMenu.SetActive(true);
    }

    void CloseAll()
    {
        plantingMenu.SetActive(false);
        lowerMenu.SetActive(false);
        deletingMenu.SetActive(false);
        boostersMenu.SetActive(false);
    }
}
