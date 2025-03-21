using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform Player;
    public float followSpeed;
    public float rotationSpeed;


    private Vector3 offset;

     //Start is called before the first frame update
    void Start()
    {
        
        offset = transform.position - Player.position;
        offset.y -= 0.5f; 



    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void LateUpdate()
    {
        if (!Player)
            return;

        
        Vector3 targetPosition = Player.position + Player.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        Quaternion targetRotation = Quaternion.LookRotation(Player.forward, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    }
}
