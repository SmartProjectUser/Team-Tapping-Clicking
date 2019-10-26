using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class PlantingMenuController : MonoBehaviour
{
    public Button vegBttn;
    public Transform content;

    public Camera cam;
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    bool isStartPlanting = false;
    GameObject vegetablePref;
    GameObject bed;
    int profitOfVeg;
    int numberOfVegetable;

    void Start()
    {
        CreateListOfVegetables();
        m_Raycaster = GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
    }

    void Update()
    {
        CheckPlantingProccess();
    }

    public void CreateListOfVegetables()
    {
        List<Vegetable> vegs = VegetableController.I.vegetables;
        for(int i = 0; i < vegs.Count; i++)
        {
            Button bttn = Instantiate(vegBttn, content);
            bttn.GetComponent<Image>().sprite = vegs[i].img;
            bttn.GetComponent<VegetableIdentifier>().vegetablePrefab = vegs[i].prefab;
            bttn.GetComponent<VegetableIdentifier>().name = vegs[i].nameOfVeg;
            bttn.GetComponent<VegetableIdentifier>().profit = vegs[i].profit;
            bttn.GetComponent<VegetableIdentifier>().serialNumberOfVegetable = i;

        }
    }

    void CheckPlantingProccess()
    {
        if (!isStartPlanting)
            CheckStartProccess();
        else
            CheckEndProccess();
            
    }

    void CheckStartProccess()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) /*|| Input.GetTouch(0).phase == TouchPhase.Began*/)
        {
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(m_PointerEventData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject.GetComponent<VegetableIdentifier>())
                {
                 //   Debug.Log(result.gameObject.GetComponent<VegetableIdentifier>().name);
                    isStartPlanting = true;
                    profitOfVeg = result.gameObject.GetComponent<VegetableIdentifier>().profit;
                    vegetablePref = result.gameObject.GetComponent<VegetableIdentifier>().vegetablePrefab;
                    numberOfVegetable = result.gameObject.GetComponent<VegetableIdentifier>().serialNumberOfVegetable;
                }
                   
            }
        }
    }

    void CheckEndProccess()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0) /*|| Input.GetTouch(0).phase == TouchPhase.Ended*/)
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
         

            if (Physics.Raycast(ray, out hit, 1 << 8))
            {
                Transform objectHit = hit.transform;
              //  Debug.Log(objectHit.gameObject.name);
                if (objectHit.gameObject.tag == "bed")
                {
                    if (!isSomethingGrowing(objectHit.gameObject))
                    {
                        objectHit.gameObject.GetComponent<VegetablesSpawner>().SpawnVegatables(vegetablePref, objectHit.transform, profitOfVeg);
                        objectHit.gameObject.GetComponent<VegetablesSpawner>().profit = profitOfVeg;
                        objectHit.gameObject.GetComponent<VegetablesSpawner>().FindBedAndSave(numberOfVegetable);

                    }
                }
                
            }
            isStartPlanting = false;
        }
    }

    bool isSomethingGrowing(GameObject bed)
    {
        if(bed.GetComponentsInChildren<VegetableDetector>().Length > 0)
            return true;
        return false;
            
    }
}
