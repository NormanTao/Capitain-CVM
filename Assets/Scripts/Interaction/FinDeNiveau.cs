using UnityEngine;
using UnityEngine.SceneManagement;

public class FinDeNiveau : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Félicitation, le niveau est terminé.");
            GameManager.Instance.SaveData();
            GameManager.Instance.PlayerData.LevelFinished();
            int nextLevel = GameManager.Instance.PlayerData.MaxLevel + 1;

            SceneManager.LoadScene("Level"+ nextLevel);

        }
    }
}
