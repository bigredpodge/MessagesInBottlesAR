using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadInput : MonoBehaviour
{
[Header("Typing Organisation")]
TMP_Text textComponent;
string NewText;
bool typing;
public float textSpeed;

[Header("Word Organisation")]
string word;
public GameObject TextBox;
public Transform TextList;
TextAnimationHandler handler;

    void Start()
    {
        typing = false;
    }

    public void UpdateText(string input)
    {
        if (!typing) 
        NewText = input;
    }

    public void WriteText()
    {
        if (!typing && !(NewText == string.Empty)) 
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        typing = true;

        foreach (char c in NewText.ToCharArray())
        {
            if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c == '\''))
            {
                word += c;
            }

            else    
            {
                SpawnWord();
                yield return new WaitForSeconds(textSpeed);
                handler.StartMoving();
            }
        }
        SpawnWord();
        yield return new WaitForSeconds(textSpeed);
        handler.StartMoving();

        typing = false;
    }

    void SpawnWord()
    {
        GameObject obj = Instantiate(TextBox, TextList);
        textComponent = obj.transform.GetChild(0).GetComponent<TextMeshPro>();
        handler = obj.GetComponent<TextAnimationHandler>();
        textComponent.text = word;
        word = string.Empty;
        handler.FadeIn();
    }
}

// Other voice recognition - Unity Asset Store
// testing devices - Android Redmi Note 2/ Other devices??
// how do we imagine the original messages were recorded? 
// how to make sure that someone's message is being read into it. - retain the 'magical' input (do we want them to be able to correct it)
// go to a location and find your bottle w/ geospatial. --maps API
// how do we get the most control over where the bottle is, where the player is, and where the bottle needs to go.
// fade out then fade into the bottle? message glows - cork bottle and throw it in the water. watch it bob away into the distance w/ light.
// what is in the bottle - how do we visualise an audio file in a bottle?
// Move to bottle and then Animation clip for each word?
// for each character - add to word. if char !letter, end word. let word rotate around the bottle.
// write to a firebase server and don't complicate things by storing data locally. - firebase to track other 'players' 
// what are we trying to engineer socially - are they doing this alone or are we doing this communally? 
// is it important for the words to be replicated exactly, how accurate do words need to be?