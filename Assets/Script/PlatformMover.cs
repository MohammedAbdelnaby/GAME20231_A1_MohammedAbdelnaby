using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{

    public float speed = 1.0f;
    public bool start = true;
    public GameObject fruit;
    public bool spawnFruit = true;
    // Start is called before the first frame update
    void Start()
    {
        if (spawnFruit)
        {
            int LspawnFruit = Random.Range(0, 2);
            if (LspawnFruit == 0)
            {
                GameObject Fruit = Instantiate(fruit);
                Fruit.transform.position = new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (start)
        {
            transform.position += new Vector3(0.0f, -(speed * Time.fixedDeltaTime), 0.0f);
        }
        if (transform.position.y <= -5.45f)
        {
            Destroy(this.gameObject);
        }
    }
}
