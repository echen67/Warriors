using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour {

    public float level;
    public float exp;
    public float maxExp;
    public float constant = 0.2f;

    public GameObject player;
    PlayerHealth playerHealth;
    PlayerHunger playerHunger;

    public GameObject textBox;
    public GameObject rankBox;

    public Slider expBar;

    void Awake()
    {
        level = 1f;
        exp = 0f;
        maxExp = 26f;
        playerHealth = player.GetComponent<PlayerHealth>();
        playerHunger = player.GetComponent<PlayerHunger>();
    }

    void Update()
    {
        expBar.value = exp;
    }

    public void levelUp(float extraExp)
    {
        level++;
        maxExp = Mathf.Pow(level / constant, 2f);
        exp = extraExp;
        expBar.maxValue = maxExp;

        Text levelText = textBox.GetComponent<Text>();
        levelText.text = "Level " + level;

        Text rankText = rankBox.GetComponent<Text>();
        if (level >= 6f && level < 24f)
        {
            rankText.text = "Apprentice";
        } else if (level >= 24f && level < 48f)
        {
            rankText.text = "Warrior";
        } else if (level >= 48f && level < 60f)
        {
            rankText.text = "Deputy";
        } else if (level >= 60f && level < 120)
        {
            rankText.text = "Leader";
        }

        playerHealth.levelUpHealth();
        playerHunger.levelUpHunger();
    }

    public void AddExp(float newExp)
    {
        exp += newExp;
        while(exp >= maxExp)
        {
            float extraExp = newExp - maxExp;
            levelUp(extraExp);
        }

    }

    public float getLevel()
    {
        return level;
    }
}
