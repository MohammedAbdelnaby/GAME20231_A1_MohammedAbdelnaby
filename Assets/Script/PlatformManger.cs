using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManger : MonoBehaviour
{
    public float spawnMaxTimer = 4.0f;

    [SerializeField]
    private GameObject platform;
    private float SpawnTimer = 0.0f;
    private GameObject[] platformList = null;
    public static PlatformManger Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        platformList = GameObject.FindGameObjectsWithTag("Platform");
    }

    public void spawn()
    {
        SpawnTimer -= Time.deltaTime;
        if (SpawnTimer <= 0.0f)
        {
            int spawnPoint = Random.Range(1, 4);
            if (spawnPoint == 1)
            {
                GameObject Platform = Instantiate(platform);
                platform.transform.position = new Vector3(-2.0f, 5.0f, 0.0f);
            }
            else if (spawnPoint == 2)
            {
                GameObject Platform = Instantiate(platform);
                platform.transform.position = new Vector3(0.0f, 5.0f, 0.0f);
            }
            else if (spawnPoint == 3)
            {
                GameObject Platform = Instantiate(platform);
                platform.transform.position = new Vector3(2.0f, 5.0f, 0.0f);
            }
            else
            {
                return;
            }
            SpawnTimer = spawnMaxTimer;

        }
    }
    public void DestoryObj()
    {
        if (!(platformList == null))
        {
            for (int i = 0; i < platformList.Length; i++)
            {
                if (platformList[i].transform.position.y <= -5.45f)
                {
                    Destroy(platformList[i]);
                }
            }
        }
    }
}
