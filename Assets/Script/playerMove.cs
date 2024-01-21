using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{
    private Animator animator;
    public Vector2 inputVec;

    public Text nickname;
    Rigidbody2D rigid;
    public float speed;

    bool isWalk = false;
    GameObject scanObject;

    bool isHorizonMove;
    Vector3 dir;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        inputVec.x = GameManager.instance.isAction || GameManager.instance.isPanel ? 0 : Input.GetAxisRaw("Horizontal");
        inputVec.y = GameManager.instance.isAction || GameManager.instance.isPanel ? 0 : Input.GetAxisRaw("Vertical");

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        if (vDown && inputVec.y == 1) dir = Vector3.up;
        else if (vDown && inputVec.y == -1) dir = Vector3.down;
        else if (hDown && inputVec.x == -1) dir = Vector3.left;
        else if (hDown && inputVec.x == 1) dir = Vector3.right;

        if(Input.GetButtonDown("Jump") && scanObject != null)
        {
            GameManager.instance.Action(scanObject);
        }
    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);

        if(nextVec != new Vector2(0, 0))
        {
            isWalk = true;
        }
        else
        {
            isWalk = false;
        }
        if(nextVec.x < 0f)
        {
            transform.localScale = new Vector3(-1,1,1);
            transform.Find("Canvas").localScale = new Vector3(-1, 1, 1); ;
        }
        else if(nextVec.x > 0f)
        {
            transform.localScale = new Vector3(1, 1,1);
            transform.Find("Canvas").localScale = new Vector3(1, 1, 1); ;
        }
        animator.SetBool("isWalk", isWalk);
        animator.SetBool("Change", GameManager.instance.isChange);

        Debug.DrawRay(rigid.position, dir *0.7f, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dir, 0.7f, LayerMask.GetMask("Object"));

        if(rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }
}
