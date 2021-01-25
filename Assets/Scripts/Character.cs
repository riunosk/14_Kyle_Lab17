using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public static int health = 100;
    public static int coin = 0;
    public GameObject hp;
    public GameObject coins;

    private Rigidbody2D rb;
    private Animator animator;
    private AudioSource jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jumpSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float hVelocity = 0;
        float vVelocity = 0;

        animator.SetFloat("xVelocity", Mathf.Abs(hVelocity));


        if (Input.GetKey(KeyCode.LeftArrow))
		{
            hVelocity = -moveSpeed;
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetFloat("xVelocity", 5);
            WalkSoundScript.walkSound.Play();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
		{
            hVelocity = moveSpeed;
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetFloat("xVelocity", 5);
            WalkSoundScript.walkSound.Play();
        }
        if (Input.GetKeyDown(KeyCode.Space))
		{
            animator.SetTrigger("JumpTrigger");
            vVelocity = jumpForce;
            jumpSound.Play();
		}
        hVelocity = Mathf.Clamp(rb.velocity.x + hVelocity, -5, 5);
        rb.velocity = new Vector2(hVelocity, rb.velocity.y + vVelocity);
        hp.GetComponent<Text>().text = "Health : " + health;
        coins.GetComponent<Text>().text = "Coins : " + coin;
    }
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Mace")
		{
            health -= 10;
            MaceScript.maceCollide.Play();
		}
        if (collision.gameObject.tag == "Coin")
		{
            coin += 1;
            CoinScript.coinCollide.Play();
            Destroy(collision.gameObject);
		}
	}
}
