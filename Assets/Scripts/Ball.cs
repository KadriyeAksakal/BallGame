using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    MenuManeger menuManager;
    private Rigidbody2D rb2;
    public Transform playerTransform;
    public float moveSpeed = 15;

    public Text scoreTxt;
    public int Score { get; private set; }
    public int HScore { get; private set; }
    private int controlScore = 0;

    void Start()
    {
        int flag = PlayerPrefs.GetInt("index");
        if (flag == 0)
        {
            Score = 0;
            HScore = 0;
            SaveScore();
            Debug.Log("Yeni Oyun Başlatıldı.");
        }
        else
        {
            LoadScore();
            Debug.Log("Son Oyun Başlatıldı");
        }


        rb2 = GetComponent<Rigidbody2D>(); 
        rb2.velocity = new Vector2(1, 0) * moveSpeed; 
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.name.Equals("Bomb(Clone)"))
        {
            //Debug.Log("Topa -" + hitInfo.gameObject.name + "- çarptı");
            MakeScore();
            Destroy(hitInfo.gameObject);
        }
    }

    private void LoadScore()
    {
       GameData data = SaveLoadManager.Load();
       HScore = data.Score;
        Score = HScore;
        scoreTxt.text = HScore.ToString();
    }
    private void SaveScore()
    {
        GameData data = new GameData(this);
        SaveLoadManager.Save(data);
    }

    private void MakeScore()
    {
        Score++;
        controlScore++;
        scoreTxt.text = Score.ToString();
        Debug.Log("Sc: "+Score+" Hs: "+HScore);
        if (Score > HScore)
        {
            HScore = Score;
            SaveScore();
        }
        if (controlScore == 5)
        {
            playerTransform.transform.position = new Vector2(playerTransform.transform.position.x, playerTransform.transform.position.y + 1);
            controlScore = 0;
        }

        float distance = Mathf.Abs(rb2.position.y - playerTransform.position.y);
        Debug.Log("Distance: " + distance);
        if (distance < 3)
        {
            playerTransform.transform.position = new Vector2(playerTransform.transform.position.x, -3.5f);
        }
    }
}
