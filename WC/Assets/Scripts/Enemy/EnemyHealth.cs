using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public float currentHealth;

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            float decision = Random.value;
            if(decision <= 0.2)
            {
                //drop snake meat
            } else if (decision <= 0.4)
            {
                //drop snake skin
            }
            else if(decision <= 0.5)
            {
                //drop fangs
            }
        }
    }
}
