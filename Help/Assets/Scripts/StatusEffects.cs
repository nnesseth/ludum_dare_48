using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffects : MonoBehaviour
{
    [SerializeField] private float energy = 1.0f;

    void Start()
    {
        StartCoroutine("SapEnergy");
    }

    void Update()
    {
        Debug.Log("Energy: " + getEnergy());
    }

    IEnumerator SapEnergy() {
        while(true) {
            yield return new WaitForSeconds(1.0f);
            subtractEnergy(0.01f);
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
        energy -= value;
    }
}
