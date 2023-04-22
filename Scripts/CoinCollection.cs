using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoinRand;
using System.Linq;
using System;

public class CoinCollection : MonoBehaviour
{
    private CoinInst randomizer;
    [SerializeField] private GameObject _gameObject;
    private AudioSource coinSound;
    private int totalSpawnPoints;
    int y;
    private void Start()
    {
        coinSound = GetComponent<AudioSource>();
        randomizer = _gameObject.GetComponent(typeof(CoinInst)) as CoinInst;
        totalSpawnPoints = randomizer.spawnPoints.Count();
    } 
        private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coinSound.Play();
            other.gameObject.SetActive(false);
            // Destroy(other.gameObject);
            StartCoroutine(Spawn(other.gameObject));
        }
    }
    IEnumerator Spawn(GameObject gameObject)
    {
        int x = (randomizer.spawnPoints.IndexOf(gameObject.transform.parent.transform));
       

        //3 saniye sonra aktif dönecek
        randomizer.randomValues.Remove(x);

        while (randomizer.randomValues.Count < Math.Ceiling(totalSpawnPoints/ 2f))
        {
            y = randomizer.r.Next(0, randomizer.spawnPoints.Count - 1);
            randomizer.randomValues.Add(y);
        }
        gameObject.transform.position = randomizer.spawnPoints[y].transform.position;
        gameObject.SetActive(true);
        yield return new WaitForSeconds(3);

    }
}
