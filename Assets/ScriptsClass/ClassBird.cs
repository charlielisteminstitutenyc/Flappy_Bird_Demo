using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClassBird : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private float speedMag = 100;
    private TextMeshProUGUI scoreText;
    private int scoreCounter = 0;
    private BoxCollider2D boxcollider2D;
    private SpriteRenderer spriteRenderer;
    public Sprite deathSprite;
    private ClassGameScript gamescript;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        scoreText = GameObject.Find("Canvas").transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        scoreText.text = "" + scoreCounter;
        boxcollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        rigidbody2D.gravityScale = 0;
        GameObject.Find("GameController").GetComponent<ClassGameScript>();
        gamescript = GameObject.Find("GameController").GetComponent<ClassGameScript>();
    }

    public void SetUpBird()
    {
        rigidbody2D.gravityScale = 0.4f;
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rigidbody2D.velocity = speedMag * Vector2.up * Time.deltaTime; 
        }
    }

    public void UpdateBird()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rigidbody2D.velocity = speedMag * Vector2.up * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death"))
        {
            rigidbody2D.gravityScale = 1;
            boxcollider2D.enabled = false;
            spriteRenderer.sprite = deathSprite;
            gamescript.FromPlayToLose(scoreCounter);
            gamescript.FromPlayToLose(scoreCounter);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal"))
        {
            scoreCounter++;
            scoreText.text = "" + scoreCounter;
        }
    }
}
