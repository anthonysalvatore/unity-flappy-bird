using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreenPipe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float screenHeight = Camera.main.orthographicSize;
        float topScreenEdge = screenHeight + 0.01f; // Slightly above the screen
        float bottomScreenEdge = -screenHeight - 0.01f; // Slightly below the screen

        Vector3 pipeWorldPosition = transform.parent.position + transform.localPosition;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float spriteHeight = spriteRenderer.bounds.size.y;

        // Check if the entire sprite is off-screen
        if (gameObject.name == "Top Pipe" && pipeWorldPosition.y - spriteHeight / 2 > topScreenEdge)
        {
            Destroy(gameObject);
        }
        if (gameObject.name == "Bottom Pipe" && pipeWorldPosition.y + spriteHeight / 2 < bottomScreenEdge)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
