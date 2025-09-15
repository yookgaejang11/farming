using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   

    public float garrageDis = 5;
    public Transform garrage;
    public float speed;
    public float haveMoney = 3000;
    public GetWater water;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(this.transform.position, garrage.position) < garrageDis)
        {
            GameManager.Instance.garrageTxt.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Z))
            {
                if(GameManager.Instance.garrageActive)
                {
                    GameManager.Instance.GarrageUI.gameObject.SetActive(false);
                }
                else
                {
                    GameManager.Instance.GarrageUI.gameObject.SetActive(true);
                }
                
            }
        }
        else
        {
            GameManager.Instance.garrageTxt.gameObject.SetActive(false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Well"))
        {
            water.CanGetWater = true;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Well"))
        {
            water.CanGetWater = false;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(moveX, moveY);

        transform.Translate(dir * speed * Time.deltaTime);
    }
}
