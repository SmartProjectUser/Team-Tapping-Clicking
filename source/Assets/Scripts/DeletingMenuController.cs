using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class DeletingMenuController : MonoBehaviour
{
    public Camera cam;

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    bool isProcessDeletingStart = false;
    
    void Start()
    {
        m_Raycaster = GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckProccess();
    }

    void CheckProccess()
    {
        if (!isProcessDeletingStart)
            CheckStartDeletingProccess();
        else
            CheckEndDeletingProccess();
    }

    void CheckStartDeletingProccess()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) /*|| Input.GetTouch(0).phase == TouchPhase.Began*/)
        {
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(m_PointerEventData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject.GetComponent<DeleteDetectorII>())
                {
                    Debug.Log(result.gameObject.GetComponent<DeleteDetectorII>().name);
                    isProcessDeletingStart = true;
                }
            }
        }
    }

    void CheckEndDeletingProccess()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) /*|| Input.GetTouch(0).phase == TouchPhase.Ended*/)
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1 << 8))
            {
                Transform objectHit = hit.transform;
                Debug.Log(objectHit.gameObject.name);
                if (objectHit.gameObject.tag == "bed")
                {
                    isProcessDeletingStart = false;
                    TryDeleteVegetables(objectHit.gameObject);
                }

            }
        }
    }

    void TryDeleteVegetables(GameObject bed)
    {
        int numberOfBed = bed.GetComponent<VegetablesSpawner>().WhoAMI();
        PlayerPrefs.SetInt("bed" + numberOfBed, -1);

        VegetableDetector[] vegs = bed.GetComponentsInChildren<VegetableDetector>();

        foreach(VegetableDetector veg in vegs)
        {
            Destroy(veg.gameObject);
        }
        ProfitController.I.sourc.clip = ProfitController.I.dele;
        ProfitController.I.sourc.Play();
    }
}
