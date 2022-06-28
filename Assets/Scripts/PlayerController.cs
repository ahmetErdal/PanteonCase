using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject playerParticle;
    public Vector3 startPos;
    PlatformRotateMovement platformRotateMovement;
    GetInput getInput;
    CameraFollow cameraFollow;
    [SerializeField] private Camera mineCamera;
    Animator animator;
    public List<GameObject> contestant = new List<GameObject>();
     
    void Start()
    {
        platformRotateMovement = FindObjectOfType<PlatformRotateMovement>();
        getInput = GetComponent<GetInput>();
        cameraFollow = FindObjectOfType<CameraFollow>();
        animator = GetComponent<Animator>();
        animator.SetTrigger("isRun");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Vector3 particleSpawnPos = transform.position + new Vector3(0, 2, 0);
            GameObject particle = Instantiate(playerParticle, particleSpawnPos, Quaternion.identity);
            transform.DOMove(startPos, 1f);
        }
        if (other.CompareTag("Finish"))
        {
            getInput.enabled = false;
            cameraFollow.enabled = false;
            mineCamera.transform.DOMoveZ(87, 1f);
            Vector3 rot = new Vector3(25.6f, mineCamera.transform.rotation.y, mineCamera.transform.rotation.z);
            mineCamera.transform.DORotate(rot, 1f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RotatePlatform"))
        {
            if (platformRotateMovement.isRight==true)
            {
                Vector3 pos = transform.position;
                float x = pos.x;
                //transform.DOLocalMoveX(x+2, 4f);
                transform.TransformVector(x, pos.y, pos.z);
            }
            //this.transform.parent = collision.transform;

        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        //if (collision.gameObject.CompareTag("RotatePlatform"))
        //    this.transform.parent = null;
    }
    //private void CompetitorRanking()
    //{
    //    for (int i = 0; i < contestant.Count; i++)
    //    {
    //        List<Transform> playerRanking = new List<Transform>();
    //        contestant[i].transform.position.z
    //    }
    //}
}
