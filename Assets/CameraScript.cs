using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OnMouseRotation();
    }

    private void OnMouseRotation()
    {
        float rotY = Input.GetAxis("Mouse X") * 70 * Time.deltaTime;
        float rotX = Input.GetAxis("Mouse Y") * 70 * Time.deltaTime;
        transform.eulerAngles += new Vector3(-rotX, rotY, 0);
        float eulerx = transform.eulerAngles.x;
        if (eulerx > 180) eulerx-=360 ;
        transform.eulerAngles = new Vector3(Mathf.Clamp(eulerx, -80, 80), transform.eulerAngles.y, 0);
        //print(transform.eulerAngles.x);
    }
}