using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public float maxLifepoints;
    public float iterationTime;
    public float hitDamage;

    private Image image;
    private float secondTimer;
    private float lifePoints;

    void Start()
    {
        image = GetComponent<Image>();
        secondTimer = 0f;
    }

    void Update()
    {
        if (lifePoints <= 0)
        {
            GameOver();
        }

        secondTimer += Time.deltaTime;
        if (secondTimer > iterationTime)
        {
            secondTimer = 0f;
            Tick();
        }
        image.fillAmount = (1.0f / maxLifepoints) * lifePoints;
        
    }

    public void Hit()
    {
        lifePoints -= hitDamage;
        image.color = Color.red;
    }

    public void Heal()
    {
        lifePoints += hitDamage;
        image.color = Color.green;
    }

    public void FullHeal()
    {
        lifePoints = maxLifepoints;
    }

    private void Tick()
    {
        image.color = Color.white;
        lifePoints -= 1;
    }

    public void GameOver()
    {
        FindObjectOfType<GameManager>().OpenMenu();
    }
}
