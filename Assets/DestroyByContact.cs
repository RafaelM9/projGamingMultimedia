using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosionAsteroid;

    public GameObject explosionPlayer;

    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundary")
        {
            return;
        }

        else if (other.tag == "Shot")
        {
            Destroy(other.gameObject); //shot
            Instantiate(explosionAsteroid,transform.position,transform.rotation);//instanciar explosão do asteroide
           //adicionar score
           gameController.AddScore();
        }

        else //other=Player
        {
            Destroy(other.gameObject); //player
            Instantiate(explosionPlayer,other.transform.position,transform.rotation);//instanciar explosão do Player
           //gameOver
           gameController.GameOver();
        }

       
        Destroy(gameObject); //asteroide

        Debug.Log("other:" + other.name);  
    }
}
