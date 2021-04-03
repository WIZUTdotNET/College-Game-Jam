using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGenerator : MonoBehaviour
{
    public GameObject[] doorsPrefabs;
    private float _spawnTime;
    private Vector2 _screenBounds;
    
    private void Start()
    {
        _spawnTime = TickSystem.maxTick * 5;
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(
            Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(DoorWave());
    }

    private void SpawnDoors()
    {
        GameObject doors = Instantiate(doorsPrefabs[Random.Range(0, doorsPrefabs.Length)]) as GameObject;
        doors.transform.position = new Vector3((int)(_screenBounds.x * 1.2f), doors.transform.position.y, -.1f);
    }

    IEnumerator DoorWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnTime);
            SpawnDoors();
            _spawnTime = TickSystem.maxTick * 5;
        }
        
    }
}
