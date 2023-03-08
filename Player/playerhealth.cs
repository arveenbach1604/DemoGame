using Systems.Collections;
using Systems.Collections.Generic;
using UnityEngine;


public class = PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int playerHealth;

    void Start()
    {
        playerHealth = maxHealth;
    }

    public void PlayerTakeDamage(int damage)
    {
        playerHealth = playerHealth - damage;
    }
}
