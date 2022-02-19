using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiwiMover : MonoBehaviour
{
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(0.0f, -(speed * Time.fixedDeltaTime), 0.0f);
        if (transform.position.y <= -5.45f)
        {
            Destroy(this.gameObject);
        }
    }
}
