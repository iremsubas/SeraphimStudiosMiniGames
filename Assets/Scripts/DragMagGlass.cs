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
    public GameObject VaginaRing;
    public GameObject Diaphragm;
    public GameObject CervicalCap;

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
  
        string tag = other.gameObject.name;

        switch (tag)
        {
            case "VaginaRing":
                StartCoroutine(LoadSceneAfterDelay("VaginaRingScene"));
                break;
            case "Condom1":
                StartCoroutine(LoadSceneAfterDelay("Condom1Scene"));
                break;
            case "Condom2":
                StartCoroutine(LoadSceneAfterDelay("Condom2Scene"));
                break;
            case "Condom3":
                StartCoroutine(LoadSceneAfterDelay("Condom3Scene"));
                break;
           case "CevicalCap":
                StartCoroutine(LoadSceneAfterDelay("CevicalCapScene"));
                break;
            case "Diaphragm":
                StartCoroutine(LoadSceneAfterDelay("DiaphragmScene"));
                break;
        }
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }

} 