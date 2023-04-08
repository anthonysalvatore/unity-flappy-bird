using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D birdBody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    
    private float topScreenEdge; // Slightly above the screen
    private float bottomScreenEdge; // Slightly below the screen
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        float screenHeight = Camera.main.orthographicSize;
        topScreenEdge = screenHeight + 0.01f;
        bottomScreenEdge = -screenHeight + 0.01f;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float spriteHeight = spriteRenderer.bounds.size.y;

        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive) 
        {
            birdBody.velocity = Vector2.up * flapStrength;
            
        }

        if (transform.position.y > topScreenEdge + spriteHeight/2 || transform.position.y < bottomScreenEdge - spriteHeight / 2)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
