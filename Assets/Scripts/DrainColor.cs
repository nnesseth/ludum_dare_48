using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainColor : MonoBehaviour
{
    public Renderer rend;
    [SerializeField] private StatusEffects status;
    private List<Material> materials = new List<Material>();

    void Start(){
        status = GameObject.Find("Player").GetComponent<StatusEffects>();
        StartCoroutine("SapColor");

        
    }

    IEnumerator SapColor() {
        List<Color> originalColor = new List<Color>();
        rend = GetComponent<Renderer>();
        rend.GetMaterials(materials);
        
        for(int i = 0; i < materials.Count; i++) {
            originalColor.Add(materials[i].color);
        }
        
        while(true){
            yield return new WaitForSeconds(0.01f);
            for(int i = 0; i < originalColor.Count; i++){
                materials[i].color = Color.Lerp(originalColor[i], Color.black, status.getColorDrain());
            }
        }
    }
}
