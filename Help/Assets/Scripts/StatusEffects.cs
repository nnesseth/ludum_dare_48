using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StatusEffects : MonoBehaviour
{
    [SerializeField] private float energy = 0.75f;
    [SerializeField] private float colorDrain = 0.25f;
    [SerializeField] private CharacterController player;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Quaternion startRotation;
    private bool belowNinety = false;
    private bool belowEighty = false;
    private bool belowSeventy = false;
    private bool belowSixty = false;
    private bool belowFifty = false;
    private bool belowForty = false;
    private bool belowThirty = false;
    private bool belowTwenty = false;
    private bool belowTen = false;
    public bool isBedMade = false;
    public bool areTeethBrushed = false;
    public bool doIhaveKeys = false;
    public bool doIhaveWallet = false;
    public bool amIFed = false;
    public bool amIClean = false;

    Text text;
    string[] sadThoughts;

    void Start()
    {
        
        StartCoroutine("SapEnergy");
        player.transform.SetPositionAndRotation(startPosition, startRotation);
        text = GameObject.Find("Text Box").GetComponent<Text>();
        sadThoughts = new string[9] {"*yawn* ... I'm tired.",
                                     "I really don't feel like doing much today.",
                                     "Just a little nap.",
                                     "I wonder if everyone is like this.",
                                     "Eh...",
                                     "I wish they'd stop asking me if I'm okay.",
                                     "YOLO.",
                                     "I bet the toilet would curl up next to me.",
                                     "The linoleum floor never looked so soft."};
}

    void Update()
    {
        //Energy emotes 
        if(getEnergy() < 0.9f && belowNinety == false) {
            text.text = sadThoughts[Random.Range(0,9)];
            belowNinety = true;
        }

        if(getEnergy() < 0.8f && belowEighty == false) {
            text.text = sadThoughts[Random.Range(0,9)];
            belowEighty = true;
        }
        
        if(getEnergy() < 0.7f && belowSeventy == false) {
            text.text = sadThoughts[Random.Range(0,9)];
            belowSeventy = true;
        }
        
        if(getEnergy() < 0.6f && belowSixty == false) {
            text.text = sadThoughts[Random.Range(0,9)];
            belowSixty = true;
        }
        
        if(getEnergy() < 0.5f && belowFifty == false) {
            text.text = sadThoughts[Random.Range(0,9)];
            belowFifty = true;
        }
        
        if(getEnergy() < 0.4f && belowForty == false) {
            text.text = sadThoughts[Random.Range(0,9)];
            belowForty = true;
        }
        
        if(getEnergy() < 0.3f && belowThirty == false) {
            text.text = sadThoughts[Random.Range(0,9)];
            belowThirty = true;
        }

        if(getEnergy() < 0.2f && belowTwenty == false) {
            text.text = sadThoughts[Random.Range(0,9)];
            belowTwenty = true;
        }
        
        if(getEnergy() < 0.1f && belowTen == false) {
            text.text = sadThoughts[Random.Range(0,9)];
            belowTen = true;
        }
    }

    IEnumerator SapEnergy() {
        while(true) {
            yield return new WaitForSeconds(0.1f);
            subtractEnergy(0.001f);
            addColorDrain(0.000001f);
            if(getEnergy() < 0f) {
                text.text = "I handle this shit tomorrow.";
                yield return new WaitForSeconds(2);
                GameObject.Find("Player").GetComponent<CharacterController>().transform.SetPositionAndRotation(startPosition, startRotation);
                setColorDrain(0f);
            }
        }
        
    }

    public float getEnergy() {
        return energy;
    }

    public void setEnergy(float value) {
        energy = value;
    }

    public void addEnergy(float value) {
        energy += value;
    }

    public void subtractEnergy(float value) {
        if(energy > 0f){
            energy -= value;
        }
    }

    public void addColorDrain(float value) {
        if(colorDrain < 0.99f){
            colorDrain += value;
        }
    }

    public float getColorDrain() {
        return colorDrain;
    }

    public void setColorDrain(float value) {
        colorDrain = value;
    }
}
