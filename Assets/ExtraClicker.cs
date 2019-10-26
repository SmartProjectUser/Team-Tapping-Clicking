using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraClicker : MonoBehaviour
{
    public Camera cam;

    void Update()
    {
        CheckTap();
    }

    void CheckTap()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) /*|| Input.GetTouch(0).phase == TouchPhase.Ended*/)
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, 1 << 8))
            {
                Transform objectHit = hit.transform;
                //Debug.Log(objectHit.gameObject.name);
                if (objectHit.gameObject.tag == "bed")
                {
                    if (isSomethingGrowing(objectHit.gameObject))
                    {
                        //ProfitController.I.Coins += objectHit.gameObject.GetComponent<VegetablesSpawner>().profit;
                        Debug.Log("extra profit");
                    }
                }

            }
       
        }
    }

    bool isSomethingGrowing(GameObject bed)
    {
        if (bed.GetComponentsInChildren<VegetableDetector>().Length > 0)
            return true;
        return false;

    }
}
