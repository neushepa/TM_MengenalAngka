using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System.Diagnostics.SymbolStore;

public class MemeyTarget : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool isClicked = false;
    private Vector3 memeyRun;

    void OnMouseDown()
    {
        if(isClicked) return;
        isClicked = true;
        if (GameManager.Instance != null)
        {
            GameManager.Instance.BebekTertangkap();
        }
        StartCoroutine(RunAndHide());
    }

    IEnumerator RunAndHide()
    {
        float durasiZoom = 0.15f;
        float waktuZoom = 0f;
        Vector3 skalaAwal = transform.localScale;
        Vector3 skalaTarget = skalaAwal*1.3f;

        while (waktuZoom < durasiZoom)
        {
            waktuZoom += Time.deltaTime;
            transform.localScale = Vector3.Lerp(skalaAwal, skalaTarget,waktuZoom/durasiZoom);
            yield return null;
        }


        float randomX = Random.Range(-4f,4f);
        float randomY = Random.Range(-3f,3f);
        memeyRun = new Vector3(randomX, randomY, 0f);

        float durasiLari = 0.3f;
        float waktuJalan = 0f;
        Vector3 posisiAwal = transform.position;

        while(waktuJalan < durasiLari)
        {
            waktuJalan += Time.deltaTime;
            transform.position = Vector3.Lerp(posisiAwal,memeyRun, waktuJalan/durasiLari);
            yield return null;
        }
        Destroy(gameObject);
    }
}
