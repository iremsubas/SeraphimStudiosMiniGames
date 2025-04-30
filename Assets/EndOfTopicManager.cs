using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndOfTopicManager : MonoBehaviour
{
    public GameObject endPanel;

    public void ShowEndPanel()
    {
        endPanel.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("IntroScene"); 
    }
}
