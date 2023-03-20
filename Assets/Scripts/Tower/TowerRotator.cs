using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class TowerRotator : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float _rotateSpeed;



    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
            
    }

    // Update is called once per frame
    private void Update()
    {


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float torque = touch.deltaPosition.x * Time.deltaTime * _rotateSpeed;
                _rigidbody.AddTorque(Vector3.up * torque);

            }

        }
    }
}
