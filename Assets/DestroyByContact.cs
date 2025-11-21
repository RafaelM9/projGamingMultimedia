using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosionAsteroid;

    public GameObject explosionPlayer;
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
        }

        else //other=Player
        {
            Destroy(other.gameObject); //player
            Instantiate(explosionPlayer,other.transform.position,transform.rotation);//instanciar explosão do Player
           //gameOver
        }

       
        Destroy(gameObject); //asteroide

        Debug.Log("other:" + other.name);  
    }
}
