using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceTile : MonoBehaviour
{
    public Text warningText;
    public Text buildTxt;
    public GameObject buildUi;
    bool firstPlace = false;
    public bool placeTime = false;
    public Dictionary<Vector2, GameObject> isPlaced = new Dictionary<Vector2, GameObject>();
    public GameObject previewTile;
    GameObject previewObj;
    public GameObject tile;
    public float price = 0;
    public Player player;
    
    List<Vector2> CheckTile = new List<Vector2>
    {
        new Vector2(0,3), new Vector2(3,0), new Vector2(-3,0), new Vector2(0,-3)
    };

    // Start is called before the first frame update
    void Start()
    {
        firstPlace = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update 실행 중"); // 매 프레임 찍힘?
        if (Input.GetKeyDown("e"))
        {
            Debug.Log("키 입력");
            if (!placeTime)
            {
                PlaceSoil();
            }
            else
            {
                EndPlace();
            }      
        }
        if(firstPlace)
        {
            buildTxt.text = "가격 : 무료";
        }
        else
        {
            buildTxt.text = "가격 : " + price.ToString();
        }

        if (placeTime)
        {
            bool isPlace = false;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0, LayerMask.GetMask("ground"));

            if(hit.collider != null)
            {
                Vector2Int gridPos = new Vector2Int(Mathf.FloorToInt(mousePos.x), Mathf.FloorToInt(mousePos.y));

                Vector2 diswPlayPos = new Vector2(gridPos.x + previewObj.transform.localScale.x/2, gridPos.y + previewObj.transform.localScale.y / 2);
                previewObj.transform.position = diswPlayPos;

                if(firstPlace)
                {
                    previewObj.GetComponent<SpriteRenderer>().color= Color.green;
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        GameObject spawnObj = GameObject.Instantiate(tile, diswPlayPos, Quaternion.identity);
                        isPlaced.Add(diswPlayPos, spawnObj);
                        price = 20000;
                        firstPlace = false;
                    }
                }
                else
                {
                    isPlace = CanPlace(diswPlayPos);
                    previewObj.GetComponent<SpriteRenderer>().color = isPlace ? Color.green : Color.red;
                    if (Input.GetKeyDown(KeyCode.Mouse0) && isPlace && player.haveMoney >= price)
                    {
                        GameObject spawnObj = GameObject.Instantiate(tile, diswPlayPos, Quaternion.identity);
                        player.haveMoney -= price;
                        price *= 1.5f;
                        isPlaced.Add(diswPlayPos, spawnObj);
                    }
                    else if (Input.GetKeyDown(KeyCode.Mouse0) && !isPlace)
                    {
                        GameManager.Instance.Error("설치할 수 없는 구역입니다!");
                    }
                    else if(Input.GetKeyDown(KeyCode.Mouse0) && player.haveMoney <= price)
                    {
                        GameManager.Instance.Error("돈이 부족합니다!");
                    }
                   

                }


            }
            
        }

    }

    IEnumerator WaringMassage( string Massage)
    {
        warningText.text = Massage;
        yield return new WaitForSeconds(1);
        warningText.text = string.Empty;
    }

    bool CanPlace(Vector2 pos)
    {
        if (isPlaced.ContainsKey(pos))
        {
            return false;
        }
        foreach(Vector2 pos2 in CheckTile)
        {
            if(isPlaced.ContainsKey(pos2 + pos))
            {
                return true;
            }
        }

        return false;
    }

    public void PlaceSoil()
    {
       
        StartBuild();
    }

    public void EndPlace()
    {
        placeTime = false;
        buildUi.SetActive(false);
        Destroy(previewObj);
    }

    void StartBuild()
    {
        placeTime=true;
        previewObj = GameObject.Instantiate(previewTile);
        buildUi.SetActive(true);
    }


    public void SoilButton()
    {
        if (!placeTime)
        {
            PlaceSoil();
        }
        else
        {
            placeTime = false;
            EndPlace();
        }
    }
}
