using UnityEngine;
using UnityEngine.InputSystem; // Bu satýr en üstte olmalý

public class ObjectSelector : MonoBehaviour
{
    public Camera arCamera; // AR Kameramýz

    void Update()
    {
        // Ekrana dokunulup dokunulmadýðýný algýlamak için bir pozisyon deðiþkeni
        Vector2 touchPosition = Vector2.zero;
        bool isTouching = false;

        // --- Telefonun Dokunmatik Ekraný için Kontrol ---
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            isTouching = true;
            Debug.Log("Telefondan Dokunma Algýlandý!");
        }
        // --- Editördeki Fare Týklamasý için Kontrol ---
        else if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            touchPosition = Mouse.current.position.ReadValue();
            isTouching = true;
            Debug.Log("Editörden Týklama Algýlandý!");
        }

        // Eðer bir dokunma veya týklama varsa...
        if (isTouching)
        {
            // Dokunulan 2D noktadan 3D dünyaya bir ýþýn gönder
            Ray ray = arCamera.ScreenPointToRay(touchPosition);
            RaycastHit hit;

            // Bu ýþýn bir objeye çarptý mý?
            if (Physics.Raycast(ray, out hit))
            {
                // Çarptýðý objeden 'ObjectInteraction' scriptini almaya çalýþ
                ObjectInteraction interaction = hit.transform.GetComponent<ObjectInteraction>();

                // Eðer obje bu script'e sahipse...
                if (interaction != null)
                {
                    // ...o objenin HandleClick() fonksiyonunu tetikle!
                    interaction.HandleClick();
                }
            }
        }
    }
}