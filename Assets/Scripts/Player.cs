using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private float _laserSpawnOffset = 0.8f;

    [SerializeField]
    private float _fireRate = 0.15f;

    [SerializeField]
    private float _nextFire = -1f;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            FireLaser();
        }
    }

    private void CalculateMovement()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(hInput, vInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        float xBound = 11.3f;
        float yBound = 3.8f;

        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y, -yBound, yBound),
            0
        );

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, 0);
        }
        else if (transform.position.x > xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, 0);
        }
    }

    private void FireLaser()
    {
        _nextFire = Time.time + _fireRate;
        Vector3 laserSpawnPos = transform.position + new Vector3(0, _laserSpawnOffset, 0);
        Instantiate(_laserPrefab, laserSpawnPos, Quaternion.identity);
    }
}
