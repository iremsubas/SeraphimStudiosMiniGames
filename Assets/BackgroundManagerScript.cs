using UnityEngine;

public class BackgroundManagerScript : MonoBehaviour
{
    public Sprite bedroomBackground;
    public Sprite clinicBackground;

    private SpriteRenderer backgroundRenderer;

    void Start()
    {
        backgroundRenderer = GetComponent<SpriteRenderer>();
    }

    public void SwitchToClinic()
    {
        backgroundRenderer.sprite = clinicBackground;
    }

    public void SwitchToBedroom()
    {
        backgroundRenderer.sprite = bedroomBackground;
    }
}
