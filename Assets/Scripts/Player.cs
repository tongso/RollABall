using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public Text textScoreText;
    public Text winText;
    private static int score = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("游戏开始了");   
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rb.AddForce(new Vector3(h,0,v));
        Debug.Log(1 / Time.deltaTime);

    }
    private void OnCollisionEnter(Collision collision)
    {
        string collideObjTag = collision.gameObject.tag;
        if (collideObjTag.Equals("TagFood")) {
            Destroy(collision.gameObject);
            score++;
            textScoreText.text = "总得分：" + score;
            if (score == 3) {
                winText.gameObject.SetActive(true);
            }
        }
    }
}
