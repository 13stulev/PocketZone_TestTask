using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField]
    private float speed;
    private int health = 100;
    private int maxHealth = 100;
    private Slider slider;
    private PlayerControls playerControls;
    private Rigidbody2D rb;
    private Weapon weapon;
    private float delay;
    // Start is called before the first frame update
    void Start()
    {
        delay = 0.1f;
        playerControls = new PlayerControls();
        playerControls.Enable();
        rb = gameObject.GetComponent<Rigidbody2D>();
        weapon = gameObject.GetComponentInChildren<Weapon>();
        slider = GetComponentInChildren<Slider>();
        instance = this;
    }

    
    // Update is called once per frame
    void Update()
    {
        Vector2 direction = playerControls.PlayerActions.Move.ReadValue<Vector2>().normalized;
        rb.velocity = direction * speed;
        if (playerControls.PlayerActions.Shoot.IsPressed() && delay >= 0.1f)
        {
            delay = 0;
            weapon.fire();
        }
        delay += Time.deltaTime;
    }


    public void aimWeapon(float angle)
    {
        weapon.transform.eulerAngles = new Vector3(0, 0, angle);
    }
    public void takeDamage(int damage)
    {
        
        health -= damage;
        slider.value = (float)health / maxHealth;
        if (!checkHealth())
        {
            Destroy(gameObject);
        }
    }
    private bool checkHealth()
    {
        if (health <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
