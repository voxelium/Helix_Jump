using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuilder : MonoBehaviour
{

    [SerializeField] private int _levelCount;
    [SerializeField] private float _beetWeen = 0.6f;
    [SerializeField] GameObject _beam;
    [SerializeField] GameObject _core;
    [SerializeField] Platform_Spawn _spawnPlatform;
    [SerializeField] Platform_Finish _finishPlatform;
    [SerializeField] Platform[] _platform;

    // Start is called before the first frame update
    void Start()
    {
        Build();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Метод спауна Башни
    private void Build()
    {
        GameObject core = Instantiate(_core, transform);
        GameObject beam = Instantiate(_beam, transform);
        Vector3 spawnPosition = beam.transform.position;

        // Спаун секций основы башни
        for (int i = 0; i < _levelCount; i++)
        {
            Instantiate(beam, new Vector3 (0f, i * _beetWeen, 0f), Quaternion.identity, core.transform);

            //Спаун рандомных платформ
            Instantiate(_platform[Random.Range(0, _platform.Length)], new Vector3(0f, i * _beetWeen, 0f), Quaternion.Euler(0, Random.Range(0, 360), 0), core.transform);

        }

        //Спаун стартовой платформы
        Instantiate(beam, new Vector3(0f, _levelCount * _beetWeen, 0f), Quaternion.identity, core.transform);
        Instantiate(_spawnPlatform, spawnPosition + new Vector3(spawnPosition.x, spawnPosition.y + _levelCount * _beetWeen, spawnPosition.z), Quaternion.identity, core.transform);
        Instantiate(beam, new Vector3(0f, _levelCount * _beetWeen + _beetWeen, 0f), Quaternion.identity, core.transform);

        //Спаун финальной платформы
        Instantiate(_finishPlatform, spawnPosition - new Vector3 (spawnPosition.x, spawnPosition.y + _beetWeen, spawnPosition.z), Quaternion.identity, core.transform);


    }


}
