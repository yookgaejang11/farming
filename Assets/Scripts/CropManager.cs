using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class CropManager : MonoBehaviour
{
    public GameObject wheatObj;
    public GameObject cornObj;
    public GameObject carrotObj;
    public GameObject bluecornObj;
    public GameObject redWheatObj;

    public Text errortxt;
    public GameObject SeedSelectObj;
    public bool canSeeding = false;
    public GameObject seedingUI;

    public Text wheattxt;
    public Text corntxt;
    public Text carrottxt;
    public Text bluecorntxt;
    public Text redwheattext;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(!canSeeding )
            {
                canSeeding = true;
                seedingUI.SetActive(true);
                SeedSelectObj.SetActive(true);
            }
            else if(canSeeding )
            {
                seedingUI.SetActive(false);
                SeedSelectObj.SetActive(false);
                canSeeding = false;
                GameManager.Instance.seeds = seedType.None;
            }
        }

        Vector2 mouseposition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        RaycastHit2D hit = Physics2D.Raycast(mouseposition, Vector2.zero, 0, LayerMask.GetMask("soil"));
        
        if(hit.collider != null )
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && canSeeding)
            {
                
                GameObject spawnObj;
                if (hit.collider.gameObject.GetComponent<Soil>().canSet)
                {
                    

                    switch (GameManager.Instance.seeds)
                    {
                        case GameManager.seedType.wheat:
                            if(GameManager.Instance.wheat_seed <1)
                            {
                                GameManager.Instance.Error("개수가 부족합니다!");
                                return;
                            }
                            else
                            {
                                GameManager.Instance.wheat_seed -= 1;
                                spawnObj = GameObject.Instantiate(wheatObj, Vector3.zero, Quaternion.identity);
                                List<Transform> points = new List<Transform>();
                                foreach(Transform p in hit.collider.gameObject.transform.GetChild(0).transform)
                                {
                                    Debug.Log(p.name);
                                    points.Add(p);
                                }
                                foreach (Transform p in points)
                                {
                                    if(p.transform.childCount == 0)
                                    {
                                        spawnObj.transform.parent = p;
                                        Debug.Log(points.IndexOf(p));
                                        hit.collider.gameObject.GetComponent<Soil>().crops[points.IndexOf(p)] = spawnObj.gameObject.GetComponent<Crop>();
                                        Debug.Log(hit.collider.gameObject.GetComponent<Soil>().crops[points.IndexOf(p)].gameObject.name);
                                        hit.collider.gameObject.GetComponent<Soil>().cropCount += 1;
                                        break;
                                        
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }



                                spawnObj.transform.localPosition = Vector3.zero;
                            }
                            
                            break;
                        case GameManager.seedType.corn:
                            if (GameManager.Instance.corn_seed < 1)
                            {
                                GameManager.Instance.Error("개수가 부족합니다!");
                                return;
                            }else
                            {
                                GameManager.Instance.corn_seed -= 1;
                                spawnObj = GameObject.Instantiate(cornObj, Vector2.zero, Quaternion.identity);
                                List<Transform> points = new List<Transform>();
                                foreach (Transform p in hit.collider.gameObject.transform.GetChild(0).transform)
                                {
                                    points.Add(p);
                                }
                                hit.collider.gameObject.GetComponent<Soil>().cropCount = 0;
                                foreach (Transform p in points)
                                {
                                    if (p.transform.GetChild(0) != null)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        spawnObj.transform.parent = p;

                                        hit.collider.gameObject.GetComponent<Soil>().cropCount += 1;
                                        break;
                                    }
                                }

                                if (hit.collider.gameObject.GetComponent<Soil>().cropCount == 9)
                                {
                                    hit.collider.gameObject.GetComponent<Soil>().canSet = false;
                                }

                                spawnObj.transform.localPosition = Vector3.zero;
                                break;
                            }
                           
                        case GameManager.seedType.carrot:
                            if (GameManager.Instance.carrot_seed < 1)
                            {
                                GameManager.Instance.Error("개수가 부족합니다!");
                                return;
                            }
                            else
                            {
                                GameManager.Instance.carrot_seed -= 1;
                                spawnObj = GameObject.Instantiate(carrotObj, Vector2.zero, Quaternion.identity);
                                List<Transform> points = new List<Transform>();
                                foreach (Transform p in hit.collider.gameObject.transform.GetChild(0).transform)
                                {
                                    points.Add(p);
                                }
                                hit.collider.gameObject.GetComponent<Soil>().cropCount = 0;
                                foreach (Transform p in points)
                                {
                                    if (p.transform.GetChild(0) != null)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        spawnObj.transform.parent = p;

                                        hit.collider.gameObject.GetComponent<Soil>().cropCount += 1;
                                        break;
                                    }
                                }

                                if (hit.collider.gameObject.GetComponent<Soil>().cropCount == 9)
                                {
                                    hit.collider.gameObject.GetComponent<Soil>().canSet = false;
                                }

                                spawnObj.transform.localPosition = Vector3.zero;
                                break;
                            }
                            
                        case GameManager.seedType.blue_corn:
                            if (GameManager.Instance.blue_corn_seed < 1)
                            {
                                GameManager.Instance.Error("개수가 부족합니다!");
                                return;
                            }
                            else
                            {
                                GameManager.Instance.blue_corn_seed -= 1;
                                spawnObj = GameObject.Instantiate(bluecornObj, Vector2.zero, Quaternion.identity);
                                List<Transform> points = new List<Transform>();
                                foreach (Transform p in hit.collider.gameObject.transform.GetChild(0).transform)
                                {
                                    points.Add(p);
                                }
                                hit.collider.gameObject.GetComponent<Soil>().cropCount = 0;
                                foreach (Transform p in points)
                                {
                                    if (p.transform.GetChild(0) != null)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        spawnObj.transform.parent = p;

                                        hit.collider.gameObject.GetComponent<Soil>().cropCount += 1;
                                        break;
                                    }
                                }

                                if (hit.collider.gameObject.GetComponent<Soil>().cropCount == 9)
                                {
                                    hit.collider.gameObject.GetComponent<Soil>().canSet = false;
                                }

                                spawnObj.transform.localPosition = Vector3.zero;
                                break;
                            }
                            
                        case GameManager.seedType.red_wheat:
                            if (GameManager.Instance.red_wheat_seed < 1)
                            {
                                GameManager.Instance.Error("개수가 부족합니다!");
                                return;
                            }
                            else
                            {
                                GameManager.Instance.red_wheat_seed -= 1;
                                spawnObj = GameObject.Instantiate(redWheatObj, Vector2.zero, Quaternion.identity);
                                List<Transform> points = new List<Transform>();
                                foreach (Transform p in hit.collider.gameObject.transform.GetChild(0).transform)
                                {
                                    points.Add(p);
                                }
                                hit.collider.gameObject.GetComponent<Soil>().cropCount = 0;
                                foreach (Transform p in points)
                                {
                                    if (p.transform.GetChild(0) != null)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        spawnObj.transform.parent = p;

                                        hit.collider.gameObject.GetComponent<Soil>().cropCount += 1;
                                        break;
                                    }
                                }

                                if (hit.collider.gameObject.GetComponent<Soil>().cropCount == 9)
                                {
                                    hit.collider.gameObject.GetComponent<Soil>().canSet = false;
                                }

                                spawnObj.transform.localPosition = Vector3.zero;
                                break;
                            }
                                
                    }
                }
                else
                {
                    GameManager.Instance.Error("더이상 설치할 수 없습니다!");
                }
               
            }
        }

        

    }

    public void BtnSelectSeed(int seed)
    {
        SelectSeed(seed);
    }

    void SelectSeed(int seed)
    {
        
        switch ((seedType)seed)
        {
            case seedType.wheat:
                
                if (GameManager.Instance.wheat_seed > 0)
                {
                    GameManager.Instance.seeds = (seedType)seed;
                    SeedSelectObj.SetActive(false);
                }
                else
                {
                    
                    StartCoroutine(Error());
                }
                break;
            case seedType.corn:
                if (GameManager.Instance.corn_seed > 0)
                {
                    GameManager.Instance.seeds = (seedType)seed;
                    SeedSelectObj.SetActive(false);
                }
                else
                {
                    StartCoroutine(Error());
                }
                break;
            case seedType.carrot:
                if (GameManager.Instance.carrot_seed > 0)
                {
                    GameManager.Instance.seeds = (seedType)seed;
                    SeedSelectObj.SetActive(false);
                }
                else
                {
                     StartCoroutine(Error());
                }
                break;
            case seedType.blue_corn:
                if (GameManager.Instance.blue_corn_seed > 0)
                {
                    GameManager.Instance.seeds = (seedType)seed;
                    SeedSelectObj.SetActive(false);
                }
                else
                {
                     StartCoroutine(Error());
                }
                break;
            case seedType.red_wheat:
                if (GameManager.Instance.red_wheat_seed > 0)
                {
                    GameManager.Instance.seeds = (seedType)seed;
                }
                else
                {
                    StartCoroutine(Error());
                }
                break;
        }

    }


    IEnumerator Error()
    {
        errortxt.text = "씨앗이 모자랍니다!";
        yield return new WaitForSeconds(0.5f);
        errortxt.text = string.Empty;
    }

}
