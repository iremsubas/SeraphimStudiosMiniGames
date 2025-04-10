using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class DragMagGlass : MonoBehaviour
{
    private Vector3 offset;
    private bool dragging = false;

    public GameObject condom1;
    public GameObject condom2;
    public GameObject condom3;

    void OnMouseDown()
    {
        Debug.Log("clicked on mag glass");
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;
    }

    void Update()
    {
        if (dragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("colliding");
        GameObject collidedObject = other.gameObject;

        if (collidedObject == condom1)
        {
            StartCoroutine(LoadSceneAfterDelay("Condom1Scene"));
        }
        else if (collidedObject == condom2)
        {
            StartCoroutine(LoadSceneAfterDelay("Condom2Scene"));
        }
        else if (collidedObject == condom3)
        {
            StartCoroutine(LoadSceneAfterDelay("Condom3Scene"));
        }
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }

}