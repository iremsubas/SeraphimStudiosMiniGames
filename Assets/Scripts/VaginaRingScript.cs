using UnityEngine;

public class VaginaRingScript : MonoBehaviour
{
    private bool isSqueezed = false;
    private bool isInserted = false;
    private bool canSqueeze = false;
    private bool canDrag = false;
    private bool isDragging = false;

    private Vector3 originalScale;
    public float squeezedScaleX = 0.1f; 
    public float squeezeDuration = 0.3f;

    public VaginaRingInstructionScript instructionScript;


    private Camera mainCamera;
    public string insertionZoneTag = "VaginaRingTag";

    void Start()
    {
        mainCamera = Camera.main;
        originalScale = transform.localScale;
    }

    public void EnableSqueeze() => canSqueeze = true;
    public void EnableDragging() => canDrag = true;
    public bool IsSqueezed() => isSqueezed;
    public bool IsInserted() => isInserted;

    void OnMouseDown()
    {
        if (canSqueeze && !isSqueezed)
        {
            Debug.Log("Squeezed ring!");
            isSqueezed = true;

            Vector3 targetScale = new Vector3(originalScale.x * squeezedScaleX, originalScale.y, originalScale.z);
            StartCoroutine(AnimateScale(transform.localScale, targetScale));
            if (instructionScript != null)
            {
                instructionScript.OnSqueezeComplete();
            }
        }
        else if (canDrag && isSqueezed)
        {
            isDragging = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(insertionZoneTag) && isSqueezed && !isInserted)
        {
            Debug.Log("Ring entered insertion zone!");
            isInserted = true;

            transform.position = other.transform.position;
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);

            if (instructionScript != null)
            {
                instructionScript.OnInsertComplete();
            }

            canDrag = false;
            canSqueeze = false;
            enabled = false;
        }
    }


    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
        }
    }

    private System.Collections.IEnumerator AnimateScale(Vector3 from, Vector3 to)
    {
        float time = 0f;

        while (time < squeezeDuration)
        {
            transform.localScale = Vector3.Lerp(from, to, time / squeezeDuration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = to;
    }
}
