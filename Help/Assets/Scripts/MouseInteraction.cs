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
    private string[,] stories;

    void Start(){
        status = GameObject.Find("Player").GetComponent<StatusEffects>();
        rend = GetComponent<Renderer>();
        text = GameObject.Find("Text Box").GetComponent<Text>();

        stories = new string[3, 2] {{"Unmade Bed", "Ugh, I should make that."}, 
                                    {"Bed Low Energy", "Looks so comfy."}, 
                                    {"Made Bed", "Kinda nice to look at now. I did that."}
                                   };
    }

    void OnMouseEnter() {
    }

    void OnMouseExit() {
    }

    void OnMouseUp() {
        if(rend.name == "Bed Blanket - Made" && status.getEnergy() < 0.9f){
            tellStory(1, 1);
        } else if(rend.name == "Bed Blanket - Made"){
            tellStory(2, 1);
        }
    }

    void tellStory(int index, int message){
        text.text = stories[index, message];
    }
}
