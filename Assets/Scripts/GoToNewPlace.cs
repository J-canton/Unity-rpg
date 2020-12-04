using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewPlace : MonoBehaviour
{

    public string newPlaceName;
    public string uuid;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Teleport();
        }
    }

    private void Teleport()
    {
        FindObjectOfType<PlayerController>().nextUuid = uuid;
        SceneManager.LoadScene(newPlaceName);
    }
}
