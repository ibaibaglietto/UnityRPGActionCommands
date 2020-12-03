using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    private Transform previousWall;
    private GameObject battleController;

    private void Start()
    {
        battleController = GameObject.Find("BattleController");
    }

    void Update()
    {
        if(GetComponent<RectTransform>().anchoredPosition.x < -6.5f)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(previousWall.GetComponent<RectTransform>().anchoredPosition.x + 3.0f, Random.Range(-1.5f, 1.5f));
        }
    }

    public void SetPreviousWall(Transform wall)
    {
        previousWall = wall;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("blueSoul"))
        {
            battleController.GetComponent<BattleController>().EndDisappearAttack();
        }
    }
}
