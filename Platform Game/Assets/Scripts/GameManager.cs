using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int TotalPoints { get { return totalPoints; } }
    private int totalPoints;

    public void ScorePoints(int pointsToAdds)
    {
        totalPoints += pointsToAdds;

    }


    public void PlayGame()
    {
        SceneManager.LoadScene("Lobby");
    }

   public void Dead()
    {
        SceneManager.LoadScene("Dead");
    }

    public void Game()
    {
        SceneManager.LoadScene("Platform");
    }
}
