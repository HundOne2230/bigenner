using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//プレイヤーの動作
public class idou : MonoBehaviour
{
    private GameObject GameOver;
    //int jump=1;
    int jump_count = 1;
    public static bool Warp_flag;

    public AudioClip sound01;
    private AudioSource SE;
    // Use this for initialization
    void Start()
    {
        GameOver = GameObject.Find("GameOver");
        Warp_flag = false;
       SE= gameObject.GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        GameOver.SetActive(false);
        //等速アニメーション
        if (Input.GetKeyDown(KeyCode.UpArrow)&&jump_count>0)
        {
            //this.transform.position += new Vector3(0, 1, 0);
            transform.GetComponent<Rigidbody>().AddForce(0, 5, 0, ForceMode.Impulse);
            jump_count -= 1;
            SE.PlayOneShot(sound01);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += new Vector3(0.1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += new Vector3(-0.1f, 0, 0);
        }
        if (this.transform.position.y<=-20)
        {
            GameOver.SetActive(true);
        }
        if (TimerController.LimitFlag == false)
        {
            
            GameOver.SetActive(true);
            
            
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="yuka")
        {
            jump_count = 2;

        }
        if (collision.gameObject.tag == "Respawn")
        {
            jump_count = 2;

        }
        if (collision.gameObject.tag == "goal")
        {
            SceneManager.LoadScene("goal");
        }
                if (collision.gameObject.tag == "enemy")
        {
            Warp_flag = true;
        }
    
                }

}
