using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject bubble;
    [SerializeField] float effectValue = 5f;

    bool hasBubble = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
        {
            hasBubble = true;
            bubble.SetActive(true);
        }
        if (hasBubble && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<ProtectiveLayers>().AddToLayers(effectValue);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<ProtectiveLayers>().ReduceLayers(effectValue);
            Destroy(gameObject);
        }
    }
}
