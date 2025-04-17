using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VaginaRingInstructionScript : MonoBehaviour
{
    [Header("Simulation Elements")]
    public VaginaRingScript vaginaRing; 
    public GameObject squeezeHint; 
    public GameObject dragHint; 

    [Header("UI Elements")]
    public GameObject instructionPanel;
    public TextMeshProUGUI instructionText;
    public Button nextButton;
    public Button backButton;


    [Header("Step Content")]
    [TextArea] public List<string> instructionSteps = new List<string>();

    private int currentStep = 0;

    void Start()
    {
        nextButton.onClick.AddListener(NextStep);
        backButton.onClick.AddListener(PreviousStep);
        if (squeezeHint != null) squeezeHint.SetActive(false);
        if (dragHint != null) dragHint.SetActive(false);
        StartInstructions();
    }

    public void StartInstructions()
    {
        currentStep = 0;
        instructionPanel.SetActive(true);
        UpdateStepUI();
    }

    void UpdateStepUI()
    {
        instructionText.text = instructionSteps[currentStep];

        // Enable/Disable buttons
        backButton.interactable = currentStep > 0;
        nextButton.interactable = currentStep < instructionSteps.Count - 1;

        // --- Step 3: Enable ring squeeze ---
        if (currentStep == 2)
        {
            Debug.Log("Enable Squeeze");
            vaginaRing.EnableSqueeze(); 
            if (squeezeHint != null) squeezeHint.SetActive(true);
        }

        // --- Step 4: Enable drag-to-insert only if squeeze is done ---
        if (currentStep == 3)
        {
            if (vaginaRing.IsSqueezed())
            {
                Debug.Log("Enable Dragging");
                vaginaRing.EnableDragging();
                if (dragHint != null) dragHint.SetActive(true);
            }
            else
            {
                instructionText.text += "\n\n(You must squeeze the ring before inserting it.)";
            }
        }

    }


    void NextStep()
    {
        // Step 3 = index 2: Wait for squeeze
        if (currentStep == 2 && !vaginaRing.IsSqueezed()) return;

        // Step 4 = index 3: Wait for insertion
        if (currentStep == 3 && !vaginaRing.IsInserted()) return;

        if (currentStep < instructionSteps.Count - 1)
        {
            currentStep++;
            UpdateStepUI();
        }
    }


    void PreviousStep()
    {
        if (currentStep > 0)
        {
            currentStep--;
            UpdateStepUI();
        }
    }

    public void CloseInstructions()
    {
        instructionPanel.SetActive(false);
    }
    public void OnSqueezeComplete()
    {
        if (squeezeHint != null)
        {
            squeezeHint.SetActive(false);
        }
    }

    public void OnInsertComplete()
    {
        if (dragHint != null)
        {
            dragHint.SetActive(false);
        }
    }
}


