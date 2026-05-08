using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public TextMeshProUGUI uiTekst; 
    public GameObject panelZaPricu; 

    void Update()
    {
        // 1. Detekcija klika
        if (Input.GetMouseButtonDown(0)) 
        {
            Debug.Log("Lijevi klik detektiran!");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Crtamo liniju u Scene viewu da vidimo kamo Ray puca
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Zraka je pogodila: " + hit.collider.name);
                
                InteractableObject obj = hit.collider.GetComponent<InteractableObject>();
                if (obj != null)
                {
                    PrikaziPricu(obj.prica);
                }
            }
        }

        // 2. Zatvaranje panela na tipku Escape
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (panelZaPricu != null)
            {
                panelZaPricu.SetActive(false);
                // Ponovo zaključaj miš za igru
                Cursor.lockState = CursorLockMode.Locked; 
                Cursor.visible = false;
            }
        }
    }

    void PrikaziPricu(string tekst)
    {
        if (uiTekst != null && panelZaPricu != null)
        {
            uiTekst.text = tekst;
            panelZaPricu.SetActive(true);

            // Oslobodi miš da možeš kliknuti na UI ako treba
            Cursor.lockState = CursorLockMode.None; 
            Cursor.visible = true;
        }
    }
}