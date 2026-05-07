using UnityEngine;

public class JednostavnoHodanje : MonoBehaviour
{
    public float brzina = 5.0f;
    public float osjetljivostMisa = 2.0f;
    
    private CharacterController controller;
    private float rotacijaX = 0f;
    private Camera kameraIgraca;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        
        // Pronalazi kameru koja je unutar igrača
        kameraIgraca = GetComponentInChildren<Camera>();

        // Sakriva miš i zaključava ga u sredinu ekrana da možeš normalno igrati
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // 1. ROTACIJA (Gledanje mišem)
        float misX = Input.GetAxis("Mouse X") * osjetljivostMisa;
        float misY = Input.GetAxis("Mouse Y") * osjetljivostMisa;

        // Rotacija gore-dolje (limitiramo na 90 stupnjeva da ne "slomimo vrat")
        rotacijaX -= misY;
        rotacijaX = Mathf.Clamp(rotacijaX, -90f, 90f);
        kameraIgraca.transform.localRotation = Quaternion.Euler(rotacijaX, 0, 0);

        // Rotacija lijevo-desno (cijeli igrač se okreće)
        transform.Rotate(Vector3.up * misX);

        // 2. KRETANJE (W, A, S, D)
        float horizontalno = Input.GetAxis("Horizontal"); // A i D
        float vertikalno = Input.GetAxis("Vertical");     // W i S

        Vector3 smjerKretanja = transform.forward * vertikalno + transform.right * horizontalno;
        
        // Jednostavno kretanje koje uključuje i gravitaciju
        controller.SimpleMove(smjerKretanja * brzina);
    }
}