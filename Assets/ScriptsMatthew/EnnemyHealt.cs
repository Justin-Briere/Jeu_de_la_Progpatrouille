using UnityEngine;

public class EnnemyHealt : MonoBehaviour
{
    public int ennemyMaxHealth;
    public int ennemyCurrentHealth;

    public EnemyHealthBar healthBar;

    private void Start()
    {
        ennemyCurrentHealth = ennemyMaxHealth;
        healthBar.SetMaxHealth(ennemyMaxHealth);
    }
    private void Update()
    {
        if (ennemyCurrentHealth <= 0)
            Destroy(gameObject);

    }
    public void HurtEnnemy(int damageGiven)
    {
        ennemyCurrentHealth -= damageGiven;

        healthBar.SetHealth(ennemyCurrentHealth);
    }
    public void MaxHealt()
    {
        ennemyCurrentHealth = ennemyMaxHealth;
    }
}
