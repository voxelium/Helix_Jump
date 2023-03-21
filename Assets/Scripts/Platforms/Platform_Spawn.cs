using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Platform_Spawn : Platform
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _spawnPoint;

    private void Start()
    {
        //Instantiate(_catBall, _spawnPoint.position, Quaternion.identity);

        if (!_ball)
        {
            GetBall();
        }

        _ball.transform.position = _spawnPoint.transform.position;

        Rigidbody rigidbodyBall = _ball.GetComponent<Rigidbody>();
        rigidbodyBall.isKinematic = false;
      

    }


    private void GetBall()
    {
        _ball = FindObjectOfType<Ball>();

        if (!_ball)
        {
            Debug.Log("Шарик не найден");
            _ball = FindObjectOfType<Ball>();
        }
    }


}
