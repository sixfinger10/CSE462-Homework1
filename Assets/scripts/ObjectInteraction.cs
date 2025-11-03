using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private Vector3 originalScale;
    private Color originalColor;
    private Renderer objRenderer;
    private int clickCount = 0;

    void Start()
    {
        originalScale = transform.localScale;
        objRenderer = GetComponent<Renderer>();
        if (objRenderer != null)
        {
            originalColor = objRenderer.material.color;
        }
    }

    // Bu fonksiyon ObjectSelector tarafýndan çaðrýlacak
    public void HandleClick()
    {
        clickCount++;

        // 1. Adým: Büyüt
        if (clickCount == 1)
        {
            transform.localScale = originalScale * 1.5f;
            Debug.Log(gameObject.name + " büyüdü!");
        }
        // 2. Adým: Renk deðiþtir
        else if (clickCount == 2)
        {
            if (objRenderer != null)
            {
                objRenderer.material.color = Color.red;
            }
            Debug.Log(gameObject.name + " renk deðiþtirdi!");
        }
        // 3. Adým: Eski haline dön
        else if (clickCount == 3)
        {
            transform.localScale = originalScale;
            if (objRenderer != null)
            {
                objRenderer.material.color = originalColor;
            }
            clickCount = 0;
            Debug.Log(gameObject.name + " eski haline döndü!");
        }
    }
}