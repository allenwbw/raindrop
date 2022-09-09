using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployRaindrops : MonoBehaviour
{
    public GameObject raindropPrefab;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start () {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(raindropWave());
    }
    private void spawnEnemy(){
        GameObject a = Instantiate(raindropPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 2);
        //a.transform.position = new Vector2(0,0);
    }
    IEnumerator raindropWave(){
        while(true){
            float respawnTime = Random.Range(0.2f, 1.0f);
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}
