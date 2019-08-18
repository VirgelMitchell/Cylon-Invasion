using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] int armorRating = 1;

    bool isAlive = true;

    public int GetHealth() { return health; }
    public bool GetIsAlive() { return isAlive; }

    void Start()
    {
        isAlive = true;
    }

    public void TakeDamage(int damage)
    {
        if (armorRating < 1)
        {
            health = health - damage;
        }
        else
        {
            armorRating = armorRating - damage;
            if (armorRating < 0)
            {
                health = health + armorRating;
            }
        }
        if (health < 0) { DeclareDeath(); }
    }

    void DeclareDeath()
    {
        SendMessage("OnDeath");
        isAlive = false;
    }

    void OnDeath()    //Called by String Ref
    {
        isAlive = false;
    }
}
