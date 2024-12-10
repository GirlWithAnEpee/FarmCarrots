using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float smoothSpeed = 0.125f;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y + offset, player.transform.position.z + offset);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed); // сглаживаем движение камеры
        transform.position = smoothedPosition;
    }
}
