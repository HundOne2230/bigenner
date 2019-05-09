using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
    public GameObject WhitePlayer;
    public GameObject BlackPlayer;
    private Vector3 position_offset = Vector3.zero;
    private Vector3 position_offset1 = Vector3.zero;
    private bool Flag;
    private GameObject[] Wall;
    private GameObject[] Rakka;
    public AudioClip Sound;

    //プレイヤーが動いたらカメラも動く
    // Use this for initialization
    void Start () {
        Wall = GameObject.FindGameObjectsWithTag("Wall");
        Rakka = GameObject.FindGameObjectsWithTag("Respawn");
        this.position_offset=
        this.transform.position - WhitePlayer.transform.position;
        this.position_offset1 =
        this.transform.position - BlackPlayer.transform.position;
        Flag = true;
gameObject.GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 new_position = this.transform.position;
        if (Flag==true)
        {
            Wall[0].SetActive(true); Wall[1].SetActive(true);
            Rakka[0].SetActive(true); Rakka[1].SetActive(true);
            new_position.x =
                this.WhitePlayer.transform.position.x + this.position_offset.x;
            this.transform.position = new_position;
        }
        else if(Flag == false)
        {
            Wall[0].SetActive(false); Wall[1].SetActive(false);
            Rakka[0].SetActive(false); Rakka[1].SetActive(false);
            new_position.x =
               this.BlackPlayer.transform.position.x + this.position_offset1.x;
            this.transform.position = new_position;
        }
        if (Input.GetKeyDown(KeyCode.Space) && Flag == true)
        {
            Flag = false;
            new_position.y = BlackPlayer.transform.position.y;
            this.transform.position = new_position;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Flag == false|| idou.Warp_flag==true)
        {
            Flag = true;
            new_position.y = WhitePlayer.transform.position.y;
            this.transform.position = new_position;
        }

    }
}
