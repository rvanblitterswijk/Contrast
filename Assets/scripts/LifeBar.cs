using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public float lifePoints;
    public float iterationTime;
    public float hitDamage;

    private Image image;
    private float secondTimer;
    private float maxLifepoints;

    void Start()
    {
        image = GetComponent<Image>();
        secondTimer = 0f;
        maxLifepoints = lifePoints;
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
    }

    public void Heal()
    {
        lifePoints += hitDamage;
    }

    private void Tick()
    {
        lifePoints -= 1;
    }

    private void GameOver()
    {
        Debug.Log("Game over!");
    }
}
