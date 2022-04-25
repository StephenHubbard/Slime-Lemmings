using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudGen : MonoBehaviour
{
    [SerializeField] private GameObject leftSide;
    [SerializeField] private GameObject cloudPrefab;
    [SerializeField] private bool spawnClouds = true;
    [SerializeField] private float spawnTime = 16f;

    private void Start() {
        StartCoroutine(SpawnCloud());
    }

    private IEnumerator SpawnCloud() {
        while (spawnClouds) {
            int randomNum = Random.Range(-5, 6);
            Vector2 cloudSpawnPos = new Vector2(leftSide.transform.position.x, leftSide.transform.position.y + randomNum);
            GameObject newCloud = Instantiate(cloudPrefab, cloudSpawnPos, transform.rotation);
            newCloud.transform.SetParent(gameObject.transform);
            newCloud.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            yield return new WaitForSeconds(spawnTime);
        }
    }

}