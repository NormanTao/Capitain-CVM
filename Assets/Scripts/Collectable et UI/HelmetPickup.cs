using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetPickup : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _hasBeenPicked;
    void Start()
    {
        //Debug.Log(GameManager.Instance.PlayerData.ListHelmetCollected);
        if (GameManager.Instance.PlayerData.HasCollectedHelmet(this.gameObject.name)) {
            GameObject.Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameManager.Instance.PlayerData.AddHelmet(this.gameObject.name);
            GameObject.Destroy(this.gameObject);
        }
    }
}
