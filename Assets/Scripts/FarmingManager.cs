using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingManager : MonoBehaviour
{
    private static FarmingManager instance;
    public GameObject soilInfo;
    public RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(mousePos, Vector2.zero, 0, LayerMask.GetMask("soil"));
        if(hit.collider !=null && Input.GetKeyDown(KeyCode.Mouse0))
        {
            soilInfo.SetActive(true);
        }

    }

    public static FarmingManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

}
