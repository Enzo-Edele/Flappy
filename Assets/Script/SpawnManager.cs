using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    [SerializeField]
    float intervalle = 3.0f;
    public float timer;
    public float rngHeight;
    void Start()
    {
        timer = intervalle;
    }

    void Update()
    {
        if(timer < 0 && GameManager.Instance.alive)
        {
            timer = intervalle;
            Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
            position.x = Screen.width * 1.1f;
            rngHeight = Random.Range(0.2f, 0.8f);
            position.y = Screen.height * rngHeight;
            GameObject obs = Instantiate(obstacle, Camera.main.ScreenToWorldPoint(position), Quaternion.identity);
        }
        timer -= Time.deltaTime;
    }
}
