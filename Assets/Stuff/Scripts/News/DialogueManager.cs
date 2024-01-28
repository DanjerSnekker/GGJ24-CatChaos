using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text anchorText;
    public TMP_Text anchorDialogueText;
    public RectTransform dialogueBox;

    public static bool isActive = false;

    public string currentName;
    public string[] currentDialogues;
    
    int activeMessage = 0;

    // Start is called before the first frame update
    void Start()
    {
        OpenDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isActive == true)
        {
            NextDialogue();
        }
    }

    public void OpenDialogue()
    {
        activeMessage = 0;
        isActive = true;

        Debug.Log("Chat begun. Loaded messages: " + currentDialogues.Length);
        DisplayMessage();
    }

    public void DisplayMessage()
    {
        string messageToDisplay = currentDialogues[activeMessage];
        anchorDialogueText.text = messageToDisplay;

        anchorText.text = currentName;
    }

    public void NextDialogue()
    {
        activeMessage++;

        if(activeMessage < currentDialogues.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Chat Ended.");
            isActive = false;

            ReturnToMenu("Main Menu");
        }
    }

    public void ReturnToMenu(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
