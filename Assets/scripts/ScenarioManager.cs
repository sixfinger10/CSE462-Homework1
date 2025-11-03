using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    // Inspector'dan buraya tüm objelerimizi sürükleyeceðiz
    public Transform[] allInteractableObjects; 
    private Vector3[] originalScales; // Orijinal ölçekleri kaydetmek için

    void Start()
    {
        // Objelerin orijinal ölçeklerini hafýzaya al
        originalScales = new Vector3[allInteractableObjects.Length];
        for (int i = 0; i < allInteractableObjects.Length; i++)
        {
            if (allInteractableObjects[i] != null)
            {
                originalScales[i] = allInteractableObjects[i].localScale;
            }
        }
    }

    // BU FONKSÝYON "BÜYÜT" BUTONUNA BAÐLANACAK
    public void MakeAllObjectsBigger()
    {
        Debug.Log("SENARYO 1: Tüm objeler büyüyor!");
        foreach (Transform objTransform in allInteractableObjects)
        {
            if (objTransform != null)
            {
                // Hepsini 2 katý büyük yap
                objTransform.localScale = objTransform.localScale * 2f;
            }
        }
    }

    // BU FONKSÝYON "SIFIRLA" BUTONUNA BAÐLANACAK
    public void ResetAllObjectsScale()
    {
        Debug.Log("SENARYO 2: Tüm objeler sýfýrlanýyor!");
        for (int i = 0; i < allInteractableObjects.Length; i++)
        {
            if (allInteractableObjects[i] != null)
            {
                allInteractableObjects[i].localScale = originalScales[i]; // Kayýtlý orijinal ölçeðe geri dön
            }
        }
    }
}