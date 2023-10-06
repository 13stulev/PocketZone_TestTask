using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float strength = 400f;
    [SerializeField]
    private List<ItemType> lootBag;
    [SerializeField]
    private GameObject droppedItem;

    private int health = 100;
    private Slider slider;
    private Transform transform;
    private Rigidbody2D rigidBody;
    
    private void Awake()
    {
        transform = gameObject.transform;
        rigidBody = GetComponent<Rigidbody2D>();
        slider = gameObject.GetComponentInChildren<Slider>();
        slider.value = 1;
    }
    public void takeDamage(int damage)
    {
        health -= damage;
        float val = (float)health / 100f;
        slider.value = val;
        if (!checkHealth()) {
            int index = (int)Random.Range(0, lootBag.Count);
            GameObject itemDrop = Instantiate(droppedItem, transform.position, transform.rotation);
            itemDrop.GetComponent<SpriteRenderer>().sprite = lootBag[index].itemSprite;
            itemDrop.GetComponent<Item>().itemType = lootBag[index];
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().takeDamage(10);
            Transform playerPosition = collision.gameObject.GetComponentInParent<Transform>();
            Rigidbody2D playerModel = collision.gameObject.GetComponentInParent<Rigidbody2D>();
            playerModel.AddForce((playerPosition.position - transform.position).normalized * strength, ForceMode2D.Force);
        }
    }
   private bool checkHealth()
    {
        return health >= 0 ? true : false;
    }

    public void setVelocity(Vector2 playerPosition) {
        rigidBody.velocity = (playerPosition - (Vector2)transform.position).normalized * speed;
    }
}
