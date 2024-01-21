using UnityEngine;
using System.Collections;

public class CameraCtrl : MonoBehaviour
{
    Vector3 cameraPosition = new Vector3(0, 0, -10);
    public GameObject A;
    Transform AT;
    void Start()
    {
        AT = A.transform;
    }
    void Update()
    {
        Vector3 cameraPox = AT.position + cameraPosition;
        transform.position = Vector3.Lerp(transform.position, cameraPox, 2f * Time.deltaTime);
    }
}