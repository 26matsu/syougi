using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class koma : MonoBehaviour
{
    private Image m_Image;
    public Sprite[] m_Sprite;
    bool isClick;
    bool meFlg = true;
    int tempPosition;

    //Dictionaryクラスのオブジェクト生成
    Dictionary<int, string> komaInfoEnemy = new Dictionary<int, string>();
    Dictionary<int, string> komaInfoMe = new Dictionary<int, string>();

    void Start()
    {
        //キーと値をセットする
        komaInfoEnemy.Add(91, "kyousyaE2");
        komaInfoEnemy.Add(81, "keimaE2");
        komaInfoEnemy.Add(71, "ginsyouE2");
        komaInfoEnemy.Add(61, "kinsyouE2");
        komaInfoEnemy.Add(51, "gyokusyou");
        komaInfoEnemy.Add(41, "kinsyouE1");
        komaInfoEnemy.Add(31, "ginsyouE1");
        komaInfoEnemy.Add(21, "keimaE1");
        komaInfoEnemy.Add(11, "kyousyaE1");

        komaInfoEnemy.Add(82, "hisyaE");
        komaInfoEnemy.Add(22, "kakugyouE");

        komaInfoEnemy.Add(93, "fuhyouE9");
        komaInfoEnemy.Add(83, "fuhyouE8");
        komaInfoEnemy.Add(73, "fuhyouE7");
        komaInfoEnemy.Add(63, "fuhyouE6");
        komaInfoEnemy.Add(53, "fuhyouE5");
        komaInfoEnemy.Add(43, "fuhyouE4");
        komaInfoEnemy.Add(33, "fuhyouE3");
        komaInfoEnemy.Add(23, "fuhyouE2");
        komaInfoEnemy.Add(13, "fuhyouE1");

        komaInfoMe.Add(97, "fuhyouM1");
        komaInfoMe.Add(87, "fuhyouM2");
        komaInfoMe.Add(77, "fuhyouM3");
        komaInfoMe.Add(67, "fuhyouM4");
        komaInfoMe.Add(57, "fuhyouM5");
        komaInfoMe.Add(47, "fuhyouM6");
        komaInfoMe.Add(37, "fuhyouM7");
        komaInfoMe.Add(27, "fuhyouM8");
        komaInfoMe.Add(17, "fuhyouM9");

        komaInfoMe.Add(88, "kakugyouM");
        komaInfoMe.Add(28, "hisyaM");
        
        komaInfoMe.Add(99, "kyousyaM1");
        komaInfoMe.Add(89, "keimaM1");
        komaInfoMe.Add(79, "ginsyouM1");
        komaInfoMe.Add(69, "kinsyouM1");
        komaInfoMe.Add(59, "ousyou");
        komaInfoMe.Add(49, "kinsyouM2");
        komaInfoMe.Add(39, "ginsyouM2");
        komaInfoMe.Add(29, "keimaM2");
        komaInfoMe.Add(19, "kyousyaM2");

    }

    void moveCheck(int position)
    {
        Dictionary<int, string> komaInfo;
        if(meFlg){
            komaInfo = komaInfoMe;
        }
        else{
            komaInfo = komaInfoEnemy;
        }
        if(komaInfo.ContainsKey(position) && komaInfo[position] != ""){
            isClick = true;
            tempPosition = position;
            Debug.Log(komaInfo[tempPosition]);
        }
        else{
            Debug.Log("コマが存在しない");
        }
    }

    void moveKoma(int position)
    {
        Dictionary<int, string> komaInfo;
        string tempKomaInfo;
        Sprite tempImage;
        Image m_Image2;

        if(meFlg){
            komaInfo = komaInfoMe;
        }
        else{
            komaInfo = komaInfoEnemy;
        }
        if(!komaInfo.ContainsKey(position) || komaInfo[position] == ""){
            // TODO 自分のコマを弾くのなくす
            if(komaInfoMe.ContainsKey(position) && komaInfoMe[position] != ""){ 
                GameObject.Find(komaInfoMe[position]).transform.Translate(-5f, 0f, 0f);
                komaInfoMe[position] = "";
                Debug.Log("駒がとられた！");
            }
            if(komaInfoEnemy.ContainsKey(position) && komaInfoEnemy[position] != ""){
                GameObject.Find(komaInfoEnemy[position]).transform.Translate(-5f, 0f, 0f);
                komaInfoEnemy[position] = "";
                Debug.Log("駒がとられた！");
            }
            // Debug.Log();
            isClick = false;

            // string Position = position.ToString();
            
            // Vector3 tmp = GameObject.Find(Position).transform.position;

            // GameObject.Find(komaInfo[tempPosition]).transform.position = new Vector3(tmp.x, tmp.y, tmp.z-1);

            // Vector3 tmp = GameObject.Find(komaInfo[tempPosition]).transform.position;
            // GameObject.Find(komaInfo[tempPosition]).transform.position = new Vector3(tmp.x, tmp.y +1, tmp.z);

            GameObject.Find(komaInfo[tempPosition]).transform.Translate(0f, 1f, 0f);

            tempKomaInfo = komaInfo[tempPosition];
            komaInfo[tempPosition] = "";

            komaInfo[position] = tempKomaInfo;

            Debug.Log(komaInfo[position] +":"+ position);

            meFlg = !meFlg;
        }
        else{
            Debug.Log("置けない");
        }
    }

	public void OnClick(int position)
    {
        if (!isClick){

            moveCheck(position);
            
        }
        else{
            
            moveKoma(position);
            
        }
        
    }

    void Update()
    {
        
    }
}
