using UnityEngine;

public class cherry : MonoBehaviour
{
    public float add;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().AddHealth(add);
            Destroy(gameObject);
        }
    }
}