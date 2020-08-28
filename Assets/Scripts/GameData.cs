using UnityEngine;

[System.Serializable]
public class GameData { 
   
    public int Score;
    public float yposition;

    public GameData(Ball ball)
    {
        yposition = ball.playerTransform.transform.position.y;
        Score = ball.Score;
        Debug.Log(yposition);
        Debug.Log(Score);
    }

}
