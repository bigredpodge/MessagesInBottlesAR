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

/*
Other voice recognition - Unity Asset Store
testing devices - Android Redmi Note 2/ Other devices??
how do we imagine the original messages were recorded? 
how to make sure that someone's message is being read into it. - retain the 'magical' input (do we want them to be able to correct it)

onboarding - here's the app
speak into the phone - preface within the app.
find a space along the harbourside, wherever you feel most comfortable.
 
go to a location and find your bottle w/ geospatial. --maps API
how do we get the most control over where the bottle is, where the player is, and where the bottle needs to go.
fade out then fade into the bottle? message glows - cork bottle and throw it in the water. watch it bob away into the distance w/ light.
what is in the bottle - how do we visualise an audio file in a bottle? - how are the original messages recorded? light.
echoes of stories/podcasts that can swirl alongside it too.
Move to bottle and then Animation clip for each word?
for each character - add to word. if char !letter, end word. let word rotate around the bottle.
write to a firebase server and don't complicate things by storing data locally. - firebase to track other 'players' 
what are we trying to engineer socially - are they doing this alone or are we doing this communally? - UP TO THEIR COMFORT
is it important for the words to be replicated exactly, how accurate do words need to be?
letterfall around the worldspace.

keyword impacts. water.

wifi - will be needed - 
firebase as a bonus? - needs wifi.
60/80% corked before throw
will need a firebase real time database - ask about getting started.

0 - no location set 1 - location of a bottle 2 - start speaking into it, 3 - cork it, 4 - throw it.
1 - take location data and send to all other devices 2 - send bool, start animation in that location. 3 - send bool. 4 - send bool.
what data is needed when?
what offset, where do people stand, test with aero.

can they move??? - inperson guided. {unpin bottle} 
a water ring where it goes into? - certain proximity for the bottle to show.
who are we sending this message, what kind of message are we encouraging participants to make.
are there already bottles in the water? energy?

light on the edge of the screen to encourage rotation.

dummy users. - setup for presentation
prototype UX in Adobe Aero

watch the database to follow states before building into unity.
skipping authentication for private prototype.

*/