using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public GameObject popup;
    public void Close()
    {
        popup.SetActive(false);
        popup.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
        popup.transform.GetChild(1).GetChild(3).gameObject.SetActive(false);
        popup.transform.GetChild(1).GetChild(4).gameObject.SetActive(false);
    }
}
