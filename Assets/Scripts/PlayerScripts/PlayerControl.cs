using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private PlayerControls playerInput;
    float rotationSpeed = 2f;
    
    public Transform nearestEnemy;
    float OverlapRadius = 12f;
    int enemyLayer;
    int redLayer;
    int blueLayer;
    int greenLayer;
    int yellowLayer;

    private void Awake()
    {
        playerInput = new PlayerControls();

    }
    private void Start()
    {
        redLayer = LayerMask.NameToLayer("EnemyRed");
        blueLayer = LayerMask.NameToLayer("EnemyBlue");
        greenLayer = LayerMask.NameToLayer("EnemyGreen");
        yellowLayer = LayerMask.NameToLayer("EnemyYellow");
        int redMask = 1 << redLayer;
        int blueMask = 1 << blueLayer;
        int greenMask = 1 << greenLayer;
        int yellowMask = 1 << yellowLayer;
        enemyLayer = redMask | blueMask | greenMask | yellowMask;
    }
    void Update()
    {
        if(nearestEnemy != null)
        {
            var rotation = Quaternion.LookRotation(nearestEnemy.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime*rotationSpeed);
        }
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, OverlapRadius, enemyLayer);
        float minimumDistance = Mathf.Infinity;
        foreach(Collider collider in hitColliders)
        {
            float distance = Vector3.Distance(transform.position, collider.transform.position);
            if (distance < minimumDistance)
            {
                minimumDistance = distance;
                nearestEnemy = collider.transform;
            }
        }
        if (nearestEnemy != null)
        {
            var rotation = Quaternion.LookRotation(nearestEnemy.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime*rotationSpeed);
        }
        Vector2 movementInput = playerInput.Player.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x,0f,movementInput.y);
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move *rotationSpeed;
        }
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }
}
