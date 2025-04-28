using System;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InkStoryManager : MonoBehaviour
{
    public static event Action<Story> OnCreateStory;

    [Header("Ink Story")]
    [SerializeField] private TextAsset inkJSONAsset = null;
    private Story story;

    [Header("UI Parents")]
    [SerializeField] private Transform storyTextParent = null;  // For spawning story text
    [SerializeField] private Transform choicesParent = null;    // For spawning choices

    [Header("UI Prefabs")]
    [SerializeField] private Text textPrefab = null;
    [SerializeField] private Button buttonPrefab = null;

    void Awake()
    {
        RemoveChildren();
        StartStory();
    }

    void StartStory()
    {
        story = new Story(inkJSONAsset.text);

        if (PuttingCondom.nextKnot != "") 
        {
            Debug.Log("Choosing path: " + PuttingCondom.nextKnot);
            story.ChoosePathString(PuttingCondom.nextKnot);
            PuttingCondom.nextKnot = "";
        }

        OnCreateStory?.Invoke(story);

        RefreshView();
    }

    void RefreshView()
    {
        RemoveChildren();

        while (story.canContinue)
        {
            string text = story.Continue().Trim();

            // Handle special tags
            HandleTags();

            CreateContentView(text);
        }

        // Handle choices
        if (story.currentChoices.Count > 0)
        {
            foreach (Choice choice in story.currentChoices)
            {
                Button choiceButton = CreateChoiceView(choice.text.Trim());
                choiceButton.onClick.AddListener(delegate {
                    OnClickChoiceButton(choice);
                });
            }
        }
        else
        {
            Button restartButton = CreateChoiceView("End of story.\nRestart?");
            restartButton.onClick.AddListener(delegate {
                StartStory();
            });
        }
    }

    void HandleTags()
    {
        if (story.currentTags.Contains("MINIGAME_CONDOM_SIZING"))
        {
            StartCondomSizingMiniGame();
        }

        if (story.currentTags.Contains("SWITCH_BACKGROUND_CLINIC"))
        {
            FindObjectOfType<BackgroundManagerScript>().SwitchToClinic();
        }
    }

    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshView();
    }

    void CreateContentView(string text)
    {
        Text storyText = Instantiate(textPrefab, storyTextParent);
        storyText.text = text;
    }

    Button CreateChoiceView(string text)
    {
        Button choiceButton = Instantiate(buttonPrefab, choicesParent);
        Text choiceText = choiceButton.GetComponentInChildren<Text>();
        choiceText.text = text;

        // Make choice button not force expand vertically
        HorizontalLayoutGroup layoutGroup = choiceButton.GetComponent<HorizontalLayoutGroup>();
        if (layoutGroup != null)
        {
            layoutGroup.childForceExpandHeight = false;
        }

        return choiceButton;
    }

    void RemoveChildren()
    {
        // Clear story text
        for (int i = storyTextParent.childCount - 1; i >= 0; i--)
        {
            Destroy(storyTextParent.GetChild(i).gameObject);
        }

        // Clear choices
        for (int i = choicesParent.childCount - 1; i >= 0; i--)
        {
            Destroy(choicesParent.GetChild(i).gameObject);
        }
    }

    void StartCondomSizingMiniGame()
    {
        Debug.Log("Launching Condom Sizing Mini-Game...");
        SceneManager.LoadScene("IremsuScene");  // Example scene name
    }
}
