using TMPro;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public static GameManager Instance;
    [Header("Game Setting")]
    public GameObject bebekPrefab;
    public int targetAngka;
    private int sisaBebek;
    public TextMeshProUGUI teksAngkaTarget;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    void Start()
    {
        PlayNewGame();
    }

    public void PlayNewGame()
    {
        GameObject[] bebekLama = GameObject.FindGameObjectsWithTag("Bebek");
        foreach (GameObject b in bebekLama)
        {
            Destroy(b);
        }
        targetAngka = Random.Range(1,11);
        sisaBebek = targetAngka;

        if(teksAngkaTarget != null)
        {
            teksAngkaTarget.text = targetAngka.ToString();
        }
        Debug.Log("Angka yang muncul: " + targetAngka);
        SpawnBebek(targetAngka);
    }

    void SpawnBebek(int jumlah)
    {
        for(int i = 0; i < jumlah; i++)
        {
           float randomX = Random.Range(-4f, 4f);
           float randomY = Random.Range(-3f, 3f);
           Vector3 posisiSpawn = new Vector3(randomX, randomY, 0f);
           GameObject bebekBaru = Instantiate(bebekPrefab, posisiSpawn, Quaternion.identity);
           bebekBaru.tag = "Bebek";
        }
    }

    public void BebekTertangkap()
    {
        sisaBebek--;
        Debug.Log("Memey tertangkap! Sisa memey: " +sisaBebek);
        if (sisaBebek <= 0)
        {
            Debug.Log("Yeeeea, Memey ketangkep semua, next ??");
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1.5f);
        PlayNewGame();
    }
}
