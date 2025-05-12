using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float speed = 10f;
    public float duration = 10f;
    public float extraHealth = 20f;
    private float timer;
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }
    public void OnHitByProjectile(GameObject player)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.AddHealth(extraHealth);
        }
        Destroy(gameObject);
    }
}