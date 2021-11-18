using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float maxLife;
    [HideInInspector] public float currentLife;

    private void OnEnable()
    {
        currentLife = maxLife;
    }

    public void ReceiveDamage(float damageAmount)
    {
        currentLife -= damageAmount;

        if (currentLife <= 0)
        {
            if (this.gameObject.tag == "Ally")
            {
                GameObject[] allies = GameObject.FindGameObjectsWithTag("Ally");
                if(allies.Length - 1 <= 0)
                    GameManager.Instance.gameOver();
            }
            if (this.gameObject.tag == "Enemy")
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                if (enemies.Length - 1 <= 0)
                    GameManager.Instance.victory();
            }

            this.gameObject.SetActive(false);
        }
    }
}
