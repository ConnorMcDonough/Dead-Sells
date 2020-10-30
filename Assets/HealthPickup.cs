using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;

    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private Transform HPCheck;

    [SerializeField] private DamageScriptPlayer flutter;

    void FixedUpdate()
    {
        Collider2D[] collidersHP = Physics2D.OverlapCircleAll(HPCheck.position, .1f, whatIsPlayer);
        for (int i = 0; i < collidersHP.Length; i++)
        {
            if (collidersHP[i].gameObject != gameObject)
            {
                flutter.currentHealth = 100;
                healthBar.SetHealth(flutter.currentHealth);
                Destroy(gameObject);
            }
        }
    }
}
