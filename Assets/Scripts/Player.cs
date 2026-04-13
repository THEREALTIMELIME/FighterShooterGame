using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 9.5f;
    private float bottomLimit = -6.5f;
    private float middleLimit = 0f;

    public GameObject bulletPrefab;

    void Start()
    {
        playerSpeed = 6f;
    }

    void Update()
    {
        Movement();
        Shooting();
    }

    void Shooting()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);

        if(transform.position.x > horizontalScreenLimit)
        {
            transform.position = new Vector3(-horizontalScreenLimit, transform.position.y, 0);
        }
        else if(transform.position.x < -horizontalScreenLimit)
        {
            transform.position = new Vector3(horizontalScreenLimit, transform.position.y, 0);
        }

        float clampedY = Mathf.Clamp(transform.position.y, bottomLimit, middleLimit);
        transform.position = new Vector3(transform.position.x, clampedY, 0);
    }
}