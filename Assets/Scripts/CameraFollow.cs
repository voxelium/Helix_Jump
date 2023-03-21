using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    [SerializeField] private float followSpeed = 0.5f;
    [SerializeField] private float Yoffset = 0.5f;
    [SerializeField] private float Zoffset = 5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(targetObject.transform.position.x, targetObject.transform.position.y + Yoffset, targetObject.transform.position.z - Zoffset);

        //Определяем позицию камеры
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
        
    }


}
