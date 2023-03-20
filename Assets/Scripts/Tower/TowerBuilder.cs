using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] GameObject _beam;

    [SerializeField] private float _additionalScale;
    public float _startAndFinishAdditionalScale = 0.5f;

    [SerializeField] private float BeamScaleY => _levelCount / 2f + _startAndFinishAdditionalScale + _additionalScale / 2f;

    [SerializeField] Platform_Spawn _spawnPlatform;
    [SerializeField] Platform_Finish _finishPlatform;
    [SerializeField] Platform[] _platform;

    // Start is called before the first frame update
    private void Start()
    {
        Build();
    }



    private void Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, BeamScaleY, 1);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y = spawnPosition.y + beam.transform.localScale.y - _additionalScale;


        //Спаун стартовой платформы
        SpawnPlatform(_spawnPlatform, ref spawnPosition, beam.transform);

        //Спаун рандомных платформ
        for (int i=0; i < _levelCount; i++)
        {
            SpawnPlatform(_platform[Random.Range(0, _platform.Length)], ref spawnPosition, beam.transform);
        }

        //Спаун финальной платформы
        SpawnPlatform(_finishPlatform, ref spawnPosition, beam.transform);

    }


    // Метод для спауна платформы
    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPosition.y -= 1;

    }


}
