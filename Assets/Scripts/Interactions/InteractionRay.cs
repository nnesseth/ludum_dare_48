using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class InteractionRay : MonoBehaviour
{
    // Reference to the camera
    Camera cam;
    Interactable interactableObject;
    StatusEffects status;

    private const string interactableTag = "Interactable Object";
    
    
    public GameObject lastHit; // important
    [SerializeField] private int rayLength = 10;


    public Vector3 collision = Vector3.zero;


    private DoorExterior hitExtDoor;
    private DoorInterior hitIntDoor;

    private Renderer sheetsUnmade;
    private Renderer pillowUnmade;
    private Renderer sheetsMade;
    private Renderer pillowMade;
    private Renderer keys;
    private Renderer wallet;
    private Renderer phone;
    GameObject keysIcon;
    GameObject walletIcon;
    GameObject soapIcon;
    GameObject hamburgerIcon;
    GameObject toothbrushIcon;
    GameObject bedIcon;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        status = GameObject.Find("Player").GetComponent<StatusEffects>();
        
        //Save the renderer's for various objects.
        sheetsMade = GameObject.Find("Bed Blanket - Made").GetComponent<Renderer>();
        sheetsMade.enabled = false;
        sheetsUnmade = GameObject.Find("Bed Blanket - Unmade").GetComponent<Renderer>();
        sheetsUnmade.enabled = true;
        pillowMade = GameObject.Find("Bed Pillow - Made").GetComponent<Renderer>();
        pillowMade.enabled = false;
        pillowUnmade = GameObject.Find("Bed Pillow - Unmade").GetComponent<Renderer>();
        pillowUnmade.enabled = true;
        keys = GameObject.Find("Keys").GetComponentInChildren<Renderer>();
        wallet = GameObject.Find("Wallet").GetComponentInChildren<Renderer>();
        phone = GameObject.Find("Phone").GetComponentInChildren<Renderer>();
        keysIcon = GameObject.Find("Keys Icon");
        keysIcon.SetActive(false);
        walletIcon = GameObject.Find("Wallet Icon");
        walletIcon.SetActive(false);
        bedIcon = GameObject.Find("Bed Icon");
        bedIcon.SetActive(false);
        soapIcon = GameObject.Find("Soap Icon");
        soapIcon.SetActive(false);
        toothbrushIcon = GameObject.Find("Toothbrush Icon");
        toothbrushIcon.SetActive(false);
        hamburgerIcon = GameObject.Find("Hamburger Icon");
        hamburgerIcon.SetActive(false);
        text = GameObject.Find("Text Box").GetComponent<Text>();

        text.text = "Another day ... maybe this time I'll make it outside the house.";
    }

    // Update is called once per frame
    void Update()
    {
        //interactableObject = GameObject.Find("");

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);           // Shoot a ray from the mouse position
            RaycastHit hit;                                                // Store info on what was hit

            if (Physics.Raycast(ray, out hit, rayLength))                  // Check if the ray physically hits
            {

                // Ray hitting debugger
                //Debug.Log("Ray cast hit the object: " + hit.collider.name + "\nHit point location: " + hit.point);


                // If hit collider name is an object with an interactable script on it, then call that script to do things
                if (hit.collider.CompareTag(interactableTag))
                {
                    lastHit = hit.transform.gameObject; // can be useful somehow if you learn to use Interactable.cs
                    //collision = hit.point;            // this and next line may also be useful
                    //interactableObject.Interacted(lastHit, collision);

                    // Debugger
                    Debug.Log("Hit an INTERACTABLE tagged object: " + hit.collider.name);

                    if (hit.collider.name == "Door (Ext) Swinger" && status.isBedMade && status.amIFed && status.amIClean && status.areTeethBrushed && status.doIhaveWallet && status.doIhaveKeys)
                    {
                        hitExtDoor = hit.collider.gameObject.GetComponent<DoorExterior>();
                        hitExtDoor.DoorAnimation();
                        text.text = "Alright... this is it. I'm ready to face the world. Thank you.";
                        StartCoroutine(FinishGame());
                    } else if (hit.collider.name == "Door (Int) Swinger")
                    {
                        hitIntDoor = hit.collider.gameObject.GetComponent<DoorInterior>();
                        hitIntDoor.DoorAnimation();
                    } else if(hit.collider.name == "Bed Blanket - Unmade")
                    {
                        sheetsMade.enabled = true;
                        pillowMade.enabled = true;
                        sheetsUnmade.enabled = false;
                        pillowUnmade.enabled = false;
                        status.isBedMade = true;
                        bedIcon.SetActive(true);
                        text.text = "That helps a little ... but I feel so tired."; // "Well, that's something.. time to brush my teeth.";
                        Debug.Log("I'm Bed Made.");
                    } else if(hit.collider.name == "Keys")
                    {
                        keys.enabled = false;
                        status.doIhaveKeys = true;
                        keysIcon.SetActive(true);
                        text.text = "Keys ... I guess I might make it outside today."; // "Yes, found them. Time to face the music.";
                        Debug.Log("I'm Keys.");
                    } else if(hit.collider.name == "Wallet")
                    {
                        wallet.enabled = false;
                        status.doIhaveWallet = true;
                        walletIcon.SetActive(true);
                        text.text = "There's my wallet. Can't remember where I put my keys though...";
                        Debug.Log("I'm Wallet.");
                    } else if(hit.collider.name == "Sink")
                    {
                        status.areTeethBrushed = true;
                        toothbrushIcon.SetActive(true);
                        text.text = "One step at a time... I'm starting to feel a bit better... maybe."; // "I do feel a bit better. Maybe a shower isn't so hard.";
                        Debug.Log("I'm Tooth Brushed");
                    } else if(hit.collider.name == "Fridge")
                    {
                        status.amIFed = true;
                        hamburgerIcon.SetActive(true);
                        text.text = "Right... I need to eat before I go."; // "Shit, I might actually make it outside today. Wallet and keys.";
                        Debug.Log("I'm Fed.");
                    } else if(hit.collider.name == "Shower")
                    {
                        status.amIClean = true;
                        soapIcon.SetActive(true);
                        text.text = "A warm shower will help."; // "Hard to feel crappy when you're clean. Easy when you're hungry though.";
                        Debug.Log("I'm Clean.");
                    } else
                    {
                        Debug.Log("*** Missing interaction script for an interactable tagged object! ***");
                    }
                }

            }
        }
    }

    IEnumerator FinishGame(){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayer>().StopMusic();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(collision, 0.25f);
    }
}
