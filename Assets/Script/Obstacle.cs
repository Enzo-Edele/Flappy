using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    float speed = 1.0f;
    [SerializeField]
    float screenTime = 15.0f;
    void Update()
    {
        if (GameManager.Instance.alive)
        {
            Vector3 position = transform.position;
            position.x = position.x - speed * Time.deltaTime;
            transform.position = position;
        }
        if (screenTime < 0 && GameManager.Instance.alive)
        {
            Destroy(gameObject);
        }
        screenTime -= Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.Instance.UpdateScore();
    }
}
