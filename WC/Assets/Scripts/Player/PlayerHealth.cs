using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float currentHealth;
    public float maxHealth;

    public float regenRate;
    public float timer;

    PlayerLevel playerLevel;
    public float level;
    public float constant = 0.2f;

    public GameObject player;
    public Slider healthBar;

    void Awake () {
        currentHealth = 25f;
        healthBar.value = currentHealth;

        playerLevel = player.GetComponent<PlayerLevel>();
        level = playerLevel.getLevel();

        maxHealth = 25f;
        healthBar.maxValue = maxHealth;

        regenRate = 5f;
        timer = 0f;
    }
	
	void Update () {
        healthBar.value = currentHealth;
        timer += Time.deltaTime;
        if(timer >= 10f)
        {
            timer = 0f;
            currentHealth += regenRate;
        }
        if (currentHealth <= 0)
        {
            //Debug.Log("Bish ur ded lol");
        }
	}

    public void levelUpHealth()
    {
        level = playerLevel.getLevel();
        maxHealth = Mathf.Pow(level / constant, 2f);
        healthBar.maxValue = maxHealth;
        currentHealth = maxHealth;
        healthBar.value = currentHealth;
    }

    public void AddHealth(float newHealth)
    {
        currentHealth += newHealth;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;
    }

}
