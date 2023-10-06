using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemy currentEnemy = collision.gameObject.GetComponent<Enemy>();
            currentEnemy.takeDamage(15);
            Destroy(gameObject);
        }
    }
}
