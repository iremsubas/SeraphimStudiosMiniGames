using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroMenu : MonoBehaviour
{
    public void StartConsentScene()
    {
        SceneManager.LoadScene("ConsentActScene");
    }

    public void StartSexProtectionScene()
    {
        SceneManager.LoadScene("SafeSexScene");
    }

    public void StartHygieneScene()
    {
        SceneManager.LoadScene("HygieneActScene");
    }
}
