using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    public float speed = 3f;
    public float waveFrequency = 2f;
    public float waveMagnitude = 2f;

    float startX;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        float x = startX + Mathf.Sin(Time.time * waveFrequency) * waveMagnitude;
        float y = transform.position.y - speed * Time.deltaTime;

        transform.position = new Vector3(x, y, 0);

        if(transform.position.y < -6.5f)
        {
            Destroy(gameObject);
        }
    }
}