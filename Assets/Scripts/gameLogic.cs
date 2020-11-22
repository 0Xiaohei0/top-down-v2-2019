using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameLogic : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] TextMeshProUGUI P1scoreText;
    [SerializeField] TextMeshProUGUI P2scoreText;
    [SerializeField] GameObject sceneLoader;
    int P1score = 0;
    int P2score = 0;
    private void Start()
    {
        P1score = 0;
        P2score = 0;
        P1scoreText.text = P1score.ToString();
        P2scoreText.text = P2score.ToString();
    }
    public void spawnPlayer(GameObject playerHit)
    {
        Debug.Log(P1score);
        Debug.Log(playerHit.tag);
        if (playerHit.tag == "Player1")
        {
            P2score++;
            P2scoreText.text = P2score.ToString();
        }
        if (playerHit.tag == "Player2")
        {
            Debug.Log("P2hit");
            P1score++;
            P1scoreText.text = P1score.ToString();
        }
        if (P1score >= 5)
        {
            sceneLoader.GetComponent<SceneLoader>().LoadP1Won();
        }
        else if (P2score >= 5)
        {
            sceneLoader.GetComponent<SceneLoader>().LoadP2Won();
        }

        GameObject spawnPoint = getRandomSpawnPoint();
        playerHit.transform.parent.position = spawnPoint.transform.position;
      }
    GameObject getRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }
}
