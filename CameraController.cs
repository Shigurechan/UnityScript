using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject targetObj;
    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = targetObj.transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        //’Ç”ö
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        if(Input.GetMouseButton(1))
        {
            //ƒ}ƒEƒXˆÚ“®—Ê
            float mouseInputX = Input.GetAxis("Mouse X");
            float mouseInputY = Input.GetAxis("Mouse Y");

            //‰ñ“]
            transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);
            transform.RotateAround(targetPos, transform.right, mouseInputY * Time.deltaTime * -200);
        }
    }
}
