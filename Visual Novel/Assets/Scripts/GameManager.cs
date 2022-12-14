using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //these lists have all the dialogue for each phase of questions
    public List<string> phaseOneDialogue;
    public List<string> phaseTwoDialogue;
    public List<string> phaseThreeDialogue;
    public List<string> phaseFourDialogue;
    public List<string> phaseFiveDialogue;
    public List<string> phaseSixDialogue;
    public List<string> phaseSevenDialogue;

    //holds the phase we're currently going through
    List<string> currentDialogue;

    //tracks the current phase and the line we're on in that phase
    int phaseIndex = 0;
    int dialogueIndex = 0;

    //game object for all buttons
    public GameObject choiceOne;
    public GameObject choiceTwo;
    public GameObject nextButton;

    //text component that is showing the dialogue
    public TMP_Text dialogueBox;
    public TMP_Text text1;
    public TMP_Text text2;


    //animator components for each face

    // Start is called before the first frame update
    void Start()
    {
        //turn off the choice buttons
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        //start the dialogue
        currentDialogue = phaseOneDialogue;
        dialogueBox.text = currentDialogue[dialogueIndex];
    }

    void SetDialogueText()
    {
        //if we haven't gotten our results yet
        if (phaseIndex < 7)
        {
            //set the dialogue component to show the line we're on
            dialogueBox.text = currentDialogue[dialogueIndex];
        }
    }

    public void AdvanceDialog()
    {
        //if we haven't gotten our results yet
        if (phaseIndex < 7)
        {
            //go to the next line
            dialogueIndex++;
            SetDialogueText();
            //if we're on the last line of dialogue
            if (dialogueIndex == currentDialogue.Count - 1)
            {
                //show the choices
                SetupChoices();
            }
        }
        //if we've seen our results
        else
        {
            //go to the last scene
            SceneManager.LoadScene("Main");
        }
    }

    void SetupChoices()
    {
        //turn off the next button and turn on the choice buttons
        nextButton.SetActive(false);
        choiceOne.SetActive(true);
        choiceTwo.SetActive(true);
    }

    public void ChoiceOne()
    {
        //if we press "no", just go to the next phase of questions
            GoToNextPhase();
    }

    public void ChoiceTwo()
    {
        //if we press "yes", increase clowny's score and then go to the next phase
        GoToNextPhase();
    }

    void GoToNextPhase()
    {
        //turn on the next button and turn off the choice buttons
        nextButton.SetActive(true);
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        //reset the dialogue line counter
        dialogueIndex = 0;
        //depending on the phase
        //run an animation and determine what the next phase is
        switch (phaseIndex)
        {
            case 0:
                currentDialogue = phaseTwoDialogue;
                text1.text="You aren't my mom.";
                text2.text="I'm getting out of here!";
                phaseIndex = 1;
                break;
            case 1:
                currentDialogue = phaseThreeDialogue;
                text1.text="Why aren't you listening to me?";
                text2.text="Tired? I just woke up!";
                phaseIndex = 2;
                break;
            case 2:
                currentDialogue = phaseFourDialogue;
                text1.text="I will not!";
                text2.text="Where's a light around here!?";
                phaseIndex = 3;
                break;
            case 3:
                currentDialogue = phaseFiveDialogue;
                text1.text="Now's no time for civil!";
                text2.text="Let me out of here!";
                phaseIndex = 4;
                break;
            case 4:
                currentDialogue = phaseSixDialogue;
                text1.text="No.";
                text2.text="No.";
                phaseIndex = 5;
                break;
            case 5:
                currentDialogue = phaseSevenDialogue;
                text1.text="What happens next?";
                text2.text="What happens next?";
                phaseIndex = 6;
                break;
            case 6:
                phaseIndex = 7;
                break;

        }
        SetDialogueText();
    }

    void GiveResults()
    {
        //if the clown score is higher than 2, then u r a clown
        dialogueBox.text="???";
    }

}
