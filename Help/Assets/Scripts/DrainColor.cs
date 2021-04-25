using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainColor : MonoBehaviour
{
    private Renderer rend;
    [SerializeField] private StatusEffects status;
    private List<Material> materials = new List<Material>();

    void Start(){
        status = GameObject.Find("Player").GetComponent<StatusEffects>();
        StartCoroutine("SapColor");
        rend = GetComponent<Renderer>();
        rend.GetMaterials(materials);
    }

    IEnumerator SapColor() {
        while(true){
            yield return new WaitForSeconds(0.01f);
            for(int i = 0; i < materials.Count; i++){
                materials[i].color = Color.Lerp(rend.material.color, Color.black, status.getColorDrain());
            }
        }
    }
}
