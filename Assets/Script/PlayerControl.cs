using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    //public
    public Joystick joystick;
    public float speed = 2.0f;
    public float jumpForce = 10.0f;
    public GameObject platform;
    public float spawnMaxTimer = 4.0f;
    public int FruitScore = 0;
    //private
    private Rigidbody2D rigidbody;
    private int jumpNum = 2;
    private bool startGame = false;
    private Vector2 velocity = Vector2.zero;
    private float waitTimer = 0.5f;
    private float SpawnTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -20.0f)
        {
            SceneManager.LoadScene("Lose");
            Destroy(this.gameObject);
        }
        float horizontalMove = joystick.Horizontal;

        Move(horizontalMove);
        Turning(horizontalMove);

        SpawnPlatform();


        transform.position += new Vector3(velocity.x, velocity.y, 0.0f);
    }

    private void Turning(float horz)
    {
        if (horz < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (horz > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" && transform.position.y >= (collision.transform.position.y + collision.gameObject.GetComponent<BoxCollider2D>().size.y / 2))
        {
            jumpNum = 2;
        }
        else if (collision.gameObject.tag == "Platform" && !(transform.position.x >= (collision.transform.position.x + collision.gameObject.GetComponent<BoxCollider2D>().size.x / 2))
                                                   || !(transform.position.x <= (collision.transform.position.x + collision.gameObject.GetComponent<BoxCollider2D>().size.x / 2)))
        {
            jumpNum = 1;
        }
        if (collision.gameObject.tag == "Fruit")
        {
            Destroy(collision.gameObject);
            FruitScore++;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Platform" && transform.position.y >= (collision.transform.position.y + collision.gameObject.GetComponent<BoxCollider2D>().size.y / 2))
        {
            startGame = true;
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0.0f)
            {
                collision.gameObject.GetComponent<PlatformMover>().start = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GrassGround")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }

    private void SpawnPlatform()
    {
        if (startGame)
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
    }

    public void jump()
    {
        if (jumpNum > 0)
        {
            jumpNum--;
            rigidbody.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);

        }
    }

    private void Move(float horz)
    {
        velocity = new Vector2(horz * speed * Time.fixedDeltaTime, 0.0f);
    }
}
