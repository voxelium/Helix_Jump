using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Spawn : Platform
{
    [SerializeField] private cat_Ball _catBall;
    [SerializeField] private Transform _spawnPoint;

    private void Awake()
    {
        Instantiate(_catBall, _spawnPoint.position, Quaternion.identity);
    }


}
