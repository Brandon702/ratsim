using UnityEngine;

public class GameOverCollision : MonoBehaviour
{
    public bool interaction = false;
    private MenuController menuController;
    private SceneController sceneController;
    private AudioController audioController;

    private void Awake()
    {
        menuController = GameObject.Find("MenuController").GetComponent<MenuController>();
        sceneController = GameObject.Find("SceneController").GetComponent<SceneController>();
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioController.Stop("Amb1");
        audioController.Stop("Amb2");
        audioController.Stop("Amb3");
        interaction = true;
        menuController.Disable();
        sceneController.Next();
        menuController.gameOverTrackPlayer();
        menuController.ScenePanel.SetActive(true);
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
        Debug.Log("Game Over");

    }
}

