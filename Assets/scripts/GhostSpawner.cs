using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public float maxSpawnDistance;
    public float minSpawnDistance;
    public float spawnTime;
    public Ghost blackGhost;
    public Ghost whiteGhost;

    private float timer;

    void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            timer = 0f;
            SpawnGhost();
        }
    }

    private void SpawnGhost()
    {
        var spawnLeftRight = Random.Range(0.0f, 1.0f);
        var spawnUpDown = Random.Range(0.0f, 1.0f);
        var ghostColor = Random.Range(0.0f, 1.0f);
        float spawnPositionX; 
        float spawnPositionY;
        Vector2 spawnPosition;

        if (spawnLeftRight > 0.5f)
        {
            spawnPositionX = Random.Range(transform.position.x + minSpawnDistance, transform.position.x + maxSpawnDistance);
        } 
        else
        {
            spawnPositionX = Random.Range(transform.position.x - minSpawnDistance, transform.position.x - maxSpawnDistance);

        }

        if (spawnUpDown > 0.5f)
        {
            spawnPositionY = Random.Range(transform.position.y + minSpawnDistance, transform.position.y + maxSpawnDistance);
        }
        else
        {
            spawnPositionY = Random.Range(transform.position.y - minSpawnDistance, transform.position.y - maxSpawnDistance);

        }

        spawnPosition = new Vector2(spawnPositionX, spawnPositionY);

        if (ghostColor > 0.5f)
        {
            Instantiate(blackGhost, spawnPosition, blackGhost.transform.rotation);
        } 
        else
        {
            Instantiate(whiteGhost, spawnPosition, whiteGhost.transform.rotation);
        }
    }
}
