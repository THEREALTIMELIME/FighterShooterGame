using UnityEngine;

public class Shield : MonoBehaviour
{
    public float fallSpeed = 3f;

    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        if (transform.position.y < -6.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                player.ActivateShield();
            }

            Destroy(gameObject);
        }
    }
}