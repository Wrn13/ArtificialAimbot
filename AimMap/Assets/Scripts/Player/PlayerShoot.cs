using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 20f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, distance, mask)){
            if(hitInfo.collider.GetComponent<Shootable>() != null){
                Shootable shootable = hitInfo.collider.GetComponent<Shootable>();
                if(inputManager.onFoot.Shoot.triggered){
                    shootable.BaseInteract();
                }
            }
        }

    }
}
