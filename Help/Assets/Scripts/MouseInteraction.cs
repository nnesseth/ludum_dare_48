using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEditor.UI;
public class MouseInteraction : MonoBehaviour
{
    private Renderer rend;
    [SerializeField] private StatusEffects status;
    [SerializeField] private Text text;
    private string[] stories;

    GameObject madeBlanket;
    GameObject unmadeBlanket;

    void Start(){
        status = GameObject.Find("Player").GetComponent<StatusEffects>();
        rend = GetComponent<Renderer>();
        text = GameObject.Find("Text Box").GetComponent<Text>();
        stories = new string[5] {"I'd sleep, but it took so much effort to make that bed.", 
                                 "Kinda nice to look at now. I did that.", 
                                 "Eh, too much effort to make the bed.",
                                 "Make the bed.",
                                 "Thanks for helping."};
        madeBlanket = GameObject.Find("Bed Blanket - Made");
        unmadeBlanket = GameObject.Find("Bed Blanket - Unmade");
    }

    void OnMouseEnter() {
    }

    void OnMouseExit() {
    }

    void OnMouseUp() {
        Debug.Log("Clicked: " + rend.name);
        if(rend.name == "Bed Blanket - Made" && status.getEnergy() < 0.9f){
            tellStory(0);
        } else if(rend.name == "Bed Blanket - Made"){
            tellStory(1);
        }

        if(rend.name == "Bed Blanket - Unmade" && status.getEnergy() < 0.5f) {
            tellStory(2);
        } else if(rend.name == "Bed Blanket - Unmade") {
            unmadeBlanket.SetActive(false);
            madeBlanket.SetActive(true);
            tellStory(3);
        }

        if(rend.name == "Exterior Door" && status.isBedMade && status.areTeethBrushed && status.doIhaveKeys && status.doIhaveWallet) {
           finishGame(); 
        }
    }

    void finishGame() {
        //Open door
        //Fade to white, LoadScene 0
        tellStory(4);
    }

    void tellStory(int index){
        text.text = stories[index];
    }
}
