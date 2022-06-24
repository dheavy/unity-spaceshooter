using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private float _sideScreenBoundary = 9.5f;

    [SerializeField]
    private float _enterScreenBoundary = 8f;

    [SerializeField]
    private GameObject _enemyContainer;

    private IEnumerator spawnCoroutine;

    private bool _canSpawn = true;

    void Start()
    {
        spawnCoroutine = SpawnRoutine();
        StartCoroutine(spawnCoroutine);
    }

    IEnumerator SpawnRoutine()
    {
        while (_canSpawn)
        {
            float xPos = Random.Range(_sideScreenBoundary * -1, _sideScreenBoundary);

            GameObject newEmeny = Instantiate(_enemyPrefab, new Vector3(xPos, _enterScreenBoundary, 0), Quaternion.identity);
            newEmeny.transform.parent = _enemyContainer.transform;

            yield return new WaitForSeconds(5f);
        }
    }

    public void StopSpawning()
    {
        _canSpawn = false;
    }
}
