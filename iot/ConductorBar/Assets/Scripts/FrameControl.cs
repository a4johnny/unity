using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;

[RequireComponent(typeof(Rigidbody2D))]//為了下面能確保一定抓到腳色的RigidBody
public class FrameControl : MonoBehaviour
{
    //初始位置
    public float x = -4.59f;//public: 公開，可以直接顯示在Inspector中修改
    public float y = 3.09f;
    public float z = 0;

    //控制腳色鋼體(Frame)
    public Rigidbody2D rigid2D;

    User user = new User();
    float tempX = 0f, tempY = 0f, tempZ = 0f;

    // Start is called before the first frame update//當遊戲載入腳本時會執行
    void Start()
    {
        rigid2D = gameObject.GetComponent<Rigidbody2D>();//確保一定抓到腳色的RigidBody
        //rigid2D.transform.position = new Vector3(x, y, z);//定位一開始框的座標
        
        InvokeRepeating("GetData", 0 , 0.25f);

    }

    // Update is called once per frame//畫面每次更新時執行，所以會執行多次
    void Update()
    {
        //rigid2D.AddForce(new Vector2(3, 0), ForceMode2D.Force);//給物件推力，自動移動(x+5,y+0)
        if (Mathf.Abs(user.x) > 0.01f || Mathf.Abs(user.y) > 0.01f || Mathf.Abs(user.z) > 0.01f)
        {
            if (user.x != tempX || user.y != tempY || user.z != tempZ)
            {
                if (Mathf.Abs(user.x -tempX) > 0.1f || Mathf.Abs(user.y - tempY) > 0.1f || Mathf.Abs(user.z - tempZ) > 0.1f)
                {
                    Debug.Log(Mathf.Abs(user.x - tempX));
                    movexxx();
                    tempX = user.x;
                    tempY = user.y;
                    tempZ = user.z;
                    //Debug.Log("x :" + user.x);
                    //Debug.Log("tempx :" + tempX);

                    //Debug.Log(Mathf.Abs(user.y - tempY));
                    //Debug.Log("y :" + user.y);
                    //Debug.Log("tempy :" + tempY);

                    //Debug.Log(Mathf.Abs(user.z - tempZ));
                    //Debug.Log("z:" + user.z);
                    //Debug.Log("tempz :" + tempZ);

                }
            }
        }
        //rigid2D.transform.position += new Vector3(0.1f, 0, 0);
    }

    private AudioSource Audio;
    private Vector3 nowPosition;
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Music")
    //    {
    //        Audio = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
    //        Audio.Play();
    //    }
    //    if (collision.gameObject.tag == "RightBorder")
    //    {
    //        print("Origin: "+rigid2D.GetComponent<Transform>().position);
    //        nowPosition = rigid2D.GetComponent<Transform>().position;
    //        rigid2D.transform.position = new Vector3(x, nowPosition.y - 1.8f, nowPosition.x);
    //        print("New: " + nowPosition);
    //    }
    //}
    public void movexxx()
    {
        //transform.eulerAngles = new Vector2(0, 180);
        //gameObject.transform.Translate(Vector3.forward * 10 * Time.deltaTime);
        rigid2D.transform.position += new Vector3(0.52f, 0, 0);
    }

    public void GetData()
    {
        RestClient.Get<User>("https://app-test-a4johnny.firebaseio.com/1.json").Then(response =>
        {
            user = response;
            //Debug.Log("xxx : " + user.x.ToString("N5"));
            //Debug.Log("RRxxx : " + user.y.ToString("N5"));
        });

    }

    public class User
    {
        public float x;
        public float y;
        public float z;
    }

    //TRIGGER
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Do")
        {
            Audio = GameObject.FindGameObjectWithTag("Do").GetComponent<AudioSource>();
            Audio.Play();//播放音樂
            print(collision.gameObject.name);
        }
        else if (collision.gameObject.tag == "Re")
        {
            Audio = GameObject.FindGameObjectWithTag("Re").GetComponent<AudioSource>();
            Audio.Play();
            print(collision.gameObject.name);
        }
        else if (collision.gameObject.tag == "Mi")
        {
            Audio = GameObject.FindGameObjectWithTag("Mi").GetComponent<AudioSource>();
            Audio.Play();
            print(collision.gameObject.name);
        }
        else if (collision.gameObject.tag == "Fa")
        {
            Audio = GameObject.FindGameObjectWithTag("Fa").GetComponent<AudioSource>();
            Audio.Play();
            print(collision.gameObject.name);
        }
        else if (collision.gameObject.tag == "So")
        {
            Audio = GameObject.FindGameObjectWithTag("So").GetComponent<AudioSource>();
            Audio.Play();
            print(collision.gameObject.name);
        }
        else if (collision.gameObject.tag == "La")
        {
            Audio = GameObject.FindGameObjectWithTag("La").GetComponent<AudioSource>();
            Audio.Play();
            print(collision.gameObject.name);
        }
        else if (collision.gameObject.tag == "Si")
        {
            Audio = GameObject.FindGameObjectWithTag("Si").GetComponent<AudioSource>();
            Audio.Play();
            print(collision.gameObject.name);
        }
        else if (collision.gameObject.tag == "Doo")
        {
            Audio = GameObject.FindGameObjectWithTag("Doo").GetComponent<AudioSource>();
            Audio.Play();
            print(collision.gameObject.name);
            
        }
        else if (collision.gameObject.tag == "Soo")
        {
            Audio = GameObject.FindGameObjectWithTag("Soo").GetComponent<AudioSource>();
            Audio.Play();
            print(collision.gameObject.name);
        }
        else if (collision.gameObject.tag == "Ree")
        {
            Audio = GameObject.FindGameObjectWithTag("Ree").GetComponent<AudioSource>();
            Audio.Play();
            print(collision.gameObject.name);
        }

        else if (collision.gameObject.tag == "RightBorder")
        {
            print("Origin: " + rigid2D.GetComponent<Transform>().position);
            nowPosition = rigid2D.GetComponent<Transform>().position;
            rigid2D.transform.position = new Vector3(x + 0.57f, nowPosition.y - 2.18f, z);//撞到邊界會往下一行
            print("New: " + nowPosition);
        }

    }
}
