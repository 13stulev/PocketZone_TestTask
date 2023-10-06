using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAim : MonoBehaviour
{
    private Transform weaponTransform;

    private void Awake()
    {
        weaponTransform = gameObject.GetComponentInParent<Weapon>().transform;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            Transform enemyPosition = collision.GetComponent<Transform>();
            Vector2 direction = enemyPosition.position - weaponTransform.position;
            PlayerController.instance.aimWeapon(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
