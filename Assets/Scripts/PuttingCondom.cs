using UnityEngine;
using UnityEngine.SceneManagement;

public class PuttingCondom : MonoBehaviour
{
    public float growSpeed = 0.01f; // Speed multiplier for growth

    public GameObject pinchHand;
    public float targetScaleY = 2.0f; // The Y scale that counts as "fully put on"
    private bool condomOn = false; 
    public string storySceneName = "SafeSexScene";
    public static string nextKnot = ""; 

    void Update(){
        if (Input.GetKeyDown(KeyCode.B))
        {
            pinchHand.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            pinchHand.SetActive(false);
        }
        if (!condomOn && transform.localScale.y >= targetScaleY)
        {
            condomOn = true;
            Debug.Log("Condom put on correctly!");
            GoBackToStory(); 
        }

    }

    void OnMouseDrag()
    {
        if (Input.GetKey(KeyCode.B))
        {
            float deltaY = Input.GetAxis("Mouse Y");

            if (deltaY < 0) // Dragging downward
            {
                float growth = -deltaY * growSpeed;

                // Increase the Y scale
                Vector3 newScale = transform.localScale;
                newScale.y += growth;

                // Shift position downward so top stays anchored
                Vector3 newPos = transform.position;
                newPos.y -= growth * 0.5f;

                transform.localScale = newScale;
                transform.position = newPos;
            }
        }
    }

    void GoBackToStory()
    {
        nextKnot = "waiting_after_mini_game";

        SceneManager.LoadScene(storySceneName);

        Debug.Log("Returning to the story...");
    }
}