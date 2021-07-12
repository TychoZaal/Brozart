using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollowPlayer : MonoBehaviour
{
    Vector3 offset, startPos;

    [SerializeField] private Transform player;

    private void Start()
    {
        offset = player.position - transform.position;
        startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, startPos.y + offset.y, startPos.z) - offset;
    }
}
