using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject[] canvasList;

    delegate void ChangeCnavas(GameObject canvasList);

    void Start()
    {
       
    }

    public void OpenCanvas(int num)
    {
        canvasList[num].SetActive(true);
    }

    public void CloseCanvas(int num)
    {
        canvasList[num].SetActive(false);
    }

}
