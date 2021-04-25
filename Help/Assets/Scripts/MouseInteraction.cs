using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class MouseInteraction : MonoBehaviour
{
    private Renderer rend;
    [SerializeField] private StatusEffects status;
    [SerializeField] private Text text;
    private string[] stories;

    void Start(){
        status = GameObject.Find("Player").GetComponent<StatusEffects>();
        rend = GetComponent<Renderer>();
        text = GameObject.Find("Text Box").GetComponent<Text>();

        stories = new string[4] {"I'd sleep, but it took so much effort to make that bed.", 
                                 "Kinda nice to look at now. I did that.", 
                                 "Sleeping sounds so much better than being aware right now.",
                                 "Thanks for helping."};
    }

    void OnMouseEnter() {
    }

    void OnMouseExit() {
    }

    void OnMouseUp() {
        if(rend.name == "Bed Blanket - Made" && status.getEnergy() < 0.9f){
            tellStory(0);
        } else if(rend.name == "Bed Blanket - Made"){
            tellStory(1);
        }

        if(rend.name == "Bed Blanket - Unmade" && status.getEnergy() < 0.5f) {
            tellStory(2);
        }

        if(rend.name == "Front Door" && status.isBedMade && status.areTeethBrushed && status.doIhaveKeys && status.doIhaveWallet) {
           finishGame(); 
        }
    }

    void finishGame() {
        //Open door
        //Fade to white, LoadScene 0
        tellStory(3);
    }

    void tellStory(int index){
        text.text = stories[index];
    }
}
