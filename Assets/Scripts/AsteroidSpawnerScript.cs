using UnityEngine;
using System.Collections;

public class AsteroidSpawnerScript : MonoBehaviour
{
    public GameObject asteroid;
    public float spawnTime;
    private float xSpawnPoint, ySpawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnAsteroid());
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTime > 1.5)
        {
            spawnTime -= 0.005f * Time.deltaTime;
        }
    }

    private IEnumerator SpawnAsteroid()
    {
        while (true)
        {
            int spawnPoint = Random.Range(0, 4);
            switch (spawnPoint)
            {
                case 0:
                    // spawn on top
                    xSpawnPoint = Random.Range(-10f, 10f);
                    ySpawnPoint = 7;
                    break;
                case 1:
                    // spawn on left
                    xSpawnPoint = -11;
                    ySpawnPoint = Random.Range(-6, 6);
                    break;
                case 2:
                    // spawn on bottom
                    xSpawnPoint = Random.Range(-10f, 10f);
                    ySpawnPoint = -7;
                    break;
                case 3:
                    // spawn on right
                    xSpawnPoint = 11;
                    ySpawnPoint = Random.Range(-6, 6);
                    break;
            }
            Instantiate(asteroid, new Vector3(xSpawnPoint, ySpawnPoint, 0), new Quaternion(0, 0, 0, 0));
            //Debug.Log("Waiting for: " + spawnTime + " seconds");
            yield return new WaitForSeconds(spawnTime); 
        }
    }
}
