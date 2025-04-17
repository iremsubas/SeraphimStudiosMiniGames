using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CuttingTool : MonoBehaviour
{
    private Vector2 startPoint;
    private Vector2 endPoint;
    private bool isDrawing = false;
    private bool hasDrawn = false;
    private float drawingTimer = 0f;
    private bool warningDisplayed = false;
    private bool hasCompletedLevel = false;
    private bool hasHitPackage = false;

    private bool hasTearedCondom = false;

    public LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;

    void Start()
    {
        // Get or add the edge collider component
        edgeCollider = GetComponent<EdgeCollider2D>();
        if (edgeCollider == null)
        {
            edgeCollider = gameObject.AddComponent<EdgeCollider2D>();
        }
        
        edgeCollider.isTrigger = true;
        
        // Disable the collider initially
        edgeCollider.enabled = false;

        if (lineRenderer != null)
        {
            lineRenderer.startColor = Color.white;
            lineRenderer.endColor = Color.white;
            lineRenderer.positionCount = 0;
            lineRenderer.sortingOrder = 10;
        }
    }

    void Update()
    {
        // Increment timer if player hasn't drawn anything
        if (!hasDrawn)
        {
            drawingTimer += Time.deltaTime;
            
            // Show warning after 5 seconds
            if (drawingTimer >= 5f && !warningDisplayed)
            {
                Debug.Log("Warning: You need to draw to open the condom!");
                warningDisplayed = true;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDrawing = true;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, startPoint);
            lineRenderer.SetPosition(1, startPoint);
            
            // Reset completion flags when starting a new drawing
            hasCompletedLevel = false;
            hasHitPackage = false;
            
            // Reset the collider points with zero length to avoid premature collisions
            Vector2[] initialPoints = new Vector2[2];
            initialPoints[0] = Vector2.zero;
            initialPoints[1] = Vector2.zero;
            edgeCollider.points = initialPoints;
        }
        else if (Input.GetMouseButton(0) && isDrawing)
        {
            Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(1, currentPos);
            
            // Calculate the length of the line
            float lineLength = Vector2.Distance(startPoint, currentPos);
            
            // Only update collider if the line has meaningful length
            if (lineLength > 0.1f)
            {
                hasDrawn = true;
                warningDisplayed = false;
                drawingTimer = 0f;
                
                // Enable the collider once we have a meaningful drawing
                edgeCollider.enabled = true;
                
                // Update the edge collider to match the line
                Vector2[] points = new Vector2[2];
                points[0] = startPoint - (Vector2)transform.position;
                points[1] = currentPos - (Vector2)transform.position;
                edgeCollider.points = points;
            }
        }
        else if (Input.GetMouseButtonUp(0) && isDrawing)
        {
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDrawing = false;
            
            // Calculate the length of the final line
            float lineLength = Vector2.Distance(startPoint, endPoint);
            
            // Only finalize the collider if the line has meaningful length
            if (lineLength > 0.1f)
            {
                hasDrawn = true;
                
                // Final update to the collider
                Vector2[] points = new Vector2[2];
                points[0] = startPoint - (Vector2)transform.position;
                points[1] = endPoint - (Vector2)transform.position;
                edgeCollider.points = points;
                
                // Check if we hit the package and can complete the level
                if (hasHitPackage && !hasTearedCondom)
                {
                    hasCompletedLevel = true;
                    Debug.Log("Good job! Advancing to the next phase.");
                    StartCoroutine(LoadSceneAfterDelay("PutCondomScene"));
                }
            }
            else
            {
                // If the line is too short, disable the collider
                edgeCollider.enabled = false;
                lineRenderer.positionCount = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CondomTag") && hasDrawn)
        {
            hasTearedCondom = true;
            Debug.Log("Game Over. You tore the condom. Try again!");
        }
        else if (other.CompareTag("PackageTag") && hasDrawn)
        {
            // Mark that we've hit the package, but wait for mouse release to complete level
            hasHitPackage = true;
        }
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
    
}