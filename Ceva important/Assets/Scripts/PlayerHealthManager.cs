using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;

    [Header("Unity Stuff")]
    public Image healthbar;

    // Use this for initialization
    void Start () {
        currentHealth = startingHealth;
	}
	// Update is called once per frame
	void Update ()
    {


    }
    public void HurtPlayer(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthbar.fillAmount = (float)currentHealth / (float)startingHealth;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //restarts the scene if killed

        }

    }
}
