using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private ItemType ammo;
    private bool _canFire;
    public bool canFire { get { return _canFire; } }

    public void fire()
    {
        if (Inventory.instance.contains(ammo.itemSprite)) {
            Inventory.instance.useItem(ammo.itemSprite);
            GameObject createdObj = Instantiate(projectile, firePoint.position, firePoint.rotation);
            createdObj.GetComponent<Rigidbody2D>().AddForce(firePoint.up * 1000f);
        }
    }
}
