using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffects : MonoBehaviour
{
    [SerializeField] private float energy = 1.0f;
    [SerializeField] private float colorDrain = 0f;
    [SerializeField] private CharacterController player;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Quaternion startRotation;

    void Start()
    {
        StartCoroutine("SapEnergy");
        player.transform.SetPositionAndRotation(startPosition, startRotation);
    }

    void Update()
    {
        //Energy emotes 
        
    }

    IEnumerator SapEnergy() {
        while(energy > 0.05) {
            yield return new WaitForSeconds(0.1f);
            subtractEnergy(0.001f);
            addColorDrain(0.000001f);
        }

        GameObject.Find("Player").GetComponent<CharacterController>().transform.SetPositionAndRotation(startPosition, startRotation);
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
        if(energy > 0.01f){
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
}
