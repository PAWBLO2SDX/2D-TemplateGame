using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 4f;
    [SerializeField] float pickUpDistance = 2.5f;
    [SerializeField] float despawnTime = 10f;

    private void Awake()
    {
        player = GameManager.Instance.player.transform;
    }

    private void Update()
    {
        despawnTime -= Time.deltaTime;
        if (despawnTime < 0) 
        {
            Destroy(gameObject);
        }
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < pickUpDistance)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.transform.position, player.position, speed * Time.deltaTime);
        if (distance < 0.1f) 
        {
            Destroy(gameObject);
        }
    }

}
