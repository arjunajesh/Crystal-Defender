using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopScript : MonoBehaviour
{

    public Slider healthSlider, powerUpSlider;

    public int maxHealth, maxPowerUp;

    int currentHealth, currentPowerUp;

    int crystals;

    public TextMeshProUGUI crystalsText;
    public GameObject gem;


    // Start is called before the first frame update
    void Start()
    {
        SetDefs();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefs.DeleteAll();
        }

    }

    void SetDefs()
    {
        crystals = 1000000;
        crystalsText.text = crystals + "";

        currentHealth = PlayerPrefs.GetInt("health", 0);
        currentPowerUp = PlayerPrefs.GetInt("powerUp", 0);

        healthSlider.maxValue = maxHealth;
        powerUpSlider.maxValue = maxPowerUp;

        healthSlider.value = currentHealth;
        powerUpSlider.value = currentPowerUp;

    }

    public void buyHealth(int price)
    {
        if(currentHealth < maxHealth)
        {
            if(crystals >= price)
            {
                crystals -= price;
                crystalsText.text = crystals + " ";
                currentHealth += 1;
                PlayerPrefs.SetInt("health", currentHealth);
                healthSlider.value = currentHealth;
                gem.gameObject.transform.localScale *= 1.2f;
                Debug.Log("Health Upgraded");
            }
            else
            {
                Debug.Log("Not Enough Crystals");
            }
        }
        else
        {
            Debug.Log("Health FULL");
        }
    }

    public void buyPowerUp()
    {
        if (currentPowerUp < maxPowerUp)
        {
            currentPowerUp += 1;
            PlayerPrefs.SetInt("powerUp", currentPowerUp);
            powerUpSlider.value = currentPowerUp;
            Debug.Log("PowerUps Upgraded");
        }
        else
        {
            Debug.Log("PowerUps FULL");
        }
    }

}
