using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCollision : MonoBehaviour
{
    public bool interaction = false;
    private MenuController menuController;

    private void Awake()
    {
        menuController = GameObject.Find("MenuController").GetComponent<MenuController>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        interaction = true;
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Win");
        }
        Debug.Log("Game Over");

    }
}

