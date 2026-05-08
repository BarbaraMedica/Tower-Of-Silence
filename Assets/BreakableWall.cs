using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public GameObject zidSRupom; 
    public string nazivAlata = "Cekic"; // Kako se točno zove predmet u inventaru

    public void PokusajRazbiti(string predmetURuci)
    {
        if (predmetURuci == nazivAlata)
        {
            // Ugasi cijeli zid, upali onaj s rupom
            zidSRupom.SetActive(true);
            gameObject.SetActive(false); 
            Debug.Log("Zid je razbijen!");
        }
        else
        {
            Debug.Log("Treba ti cekic za ovo.");
        }
    }
}