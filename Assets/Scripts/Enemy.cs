using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;

    [SerializeField]
    private float _leaveScreenBoundary = -5.5f;

    [SerializeField]
    private float _enterScreenBoundary = 8f;

    [SerializeField]
    private float _sideScreenBoundary = 9.5f;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= _leaveScreenBoundary)
        {
            float xPos = Random.Range(_sideScreenBoundary * -1, _sideScreenBoundary);
            transform.position = new Vector3(xPos, _enterScreenBoundary, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            Destroy(gameObject);
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
