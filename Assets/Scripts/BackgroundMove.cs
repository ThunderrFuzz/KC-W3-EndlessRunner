using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [Header("Background settings")]
    public float scrollSpeed = 1f;
    public Vector3 initialSpawnPosition;
    public GameObject transitionImagePrefab;
    public GameObject[] backgroundPrefabs;
    

    //private vars
    GameObject currentBackground;
    Movement mov;
    SpriteRenderer currentBackgroundRenderer;
    SpriteRenderer newBackgroundRenderer;
    Vector3 startPosition;
    int lastIndex;
    bool lastWasTransition = false;
    float initialScrollSpeed;
    void Start()
    {
        mov = FindObjectOfType<Movement>();
        startPosition = transform.position;
        // Select a random background at the start
        SpawnBackground();
        initialScrollSpeed = 5;
    }

    void Update()
    {   
        if (!mov.gameOver)
        {
            float speedMultiplier = Input.GetKey(KeyCode.LeftShift) ? 1.2f : 1.0f;
            float adjustedSpeed = initialScrollSpeed * speedMultiplier;
            // Move the background
            currentBackground.transform.Translate(Vector3.left * adjustedSpeed * Time.deltaTime);
            // Check if the background is out of view
            if (currentBackground.transform.position.x <= startPosition.x - currentBackgroundRenderer.bounds.size.x /2f )
            {
                Destroy(currentBackground);
                SpawnBackground(); 
            }
        }
    }

    void SpawnBackground()
    {
        // random background 
        int randIndex = Random.Range(0, backgroundPrefabs.Length);
        
        //checks if the random index is the same as the last background 
        if (randIndex != lastIndex && lastWasTransition == false)
        {
            // instantiates and sets currentBG to newBG for transitional image 
            GameObject newBackground = Instantiate(transitionImagePrefab, startPosition, Quaternion.identity);
            
            currentBackground = newBackground;
            
            lastWasTransition = true;
        } else
        {
            // instantiates and sets currentBG to newBG for main background 
            GameObject newBackground = Instantiate(backgroundPrefabs[randIndex], startPosition, Quaternion.identity, transform);
            currentBackground = newBackground;

            //enum trasnition fade in disabled for now as well.
            //StartCoroutine(fadeInOverTime(new Color(1, 1, 1, 0), new Color(1, 1, 1, 1), 1f));

            lastWasTransition = false;
        }
        //sets last index to use for checking if a transiton is needed.
        lastIndex = randIndex;
        // gets the renderer from the spawned background
        currentBackgroundRenderer = currentBackground.GetComponent<SpriteRenderer>();
        
    }

    IEnumerator fadeInOverTime(Color start, Color end, float duration)
    {
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            float normalizedTime = t / duration;
            //use normalizedTime as the third parameter in any Lerp from start to end
            
            currentBackgroundRenderer.color = Color.Lerp(start, end, normalizedTime);
            yield return null;
        }
        currentBackgroundRenderer.color = end; //without this, the value will end at something like 0.9992367
    }

}