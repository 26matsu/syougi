using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class koma : MonoBehaviour
{
    // private Image m_Image;
    // public Sprite[] m_Sprite;
    bool isClick;
    bool meFlg = true; //自分のターンかどうか判定する変数
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

    int komaMoveRoot(int position, Dictionary<int, string> komaInfo){
        int zachA = tempPosition / 10;
        int zachB = tempPosition % 10;
        int zahiA = position / 10;
        int zahiB = position % 10;
        if(komaInfo[tempPosition].Contains("fuhyou")){
            if(meFlg){
                return tempPosition - 1;
            }
            else{
                return tempPosition + 1;
            }
        }
        // TODO 他のコマの動き制御を作る＆障害物より先に行く動く位の制御
        else{
            return position;
        }
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
            Debug.Log("このコマは"+komaMoveRoot(position,komaInfo)+"に置けます");
            // TODO ハイライトをする
        }
        else{
            Debug.Log("コマが存在しない");
        }
    }

    void moveKoma(int position)
    {
        Dictionary<int, string> komaInfo;
        Dictionary<int, string> komaInfoMeTemp;
        Dictionary<int, string> komaInfoEnemyTemp;
        string tempKomaInfo;
        // Sprite tempImage;
        // Image m_Image2;

        if(meFlg){
            komaInfo = komaInfoMe;
        }
        else{
            komaInfo = komaInfoEnemy;
        }
        
        if(position == komaMoveRoot(position,komaInfo) && (!komaInfo.ContainsKey(position) || komaInfo[position] == "")){
            
            // Debug.Log();
            isClick = false;

            // string Position = position.ToString();
            
            // Vector3 tmp = GameObject.Find(Position).transform.position;

            // GameObject.Find(komaInfo[tempPosition]).transform.position = new Vector3(tmp.x, tmp.y, tmp.z-1);

            // Vector3 tmp = GameObject.Find(komaInfo[tempPosition]).transform.position;
            // GameObject.Find(komaInfo[tempPosition]).transform.position = new Vector3(tmp.x, tmp.y +1, tmp.z);

            int zachA = tempPosition / 10;
            int zachB = tempPosition % 10;
            int zahiA = position / 10;
            int zahiB = position % 10;

            double moveX = (zachA - zahiA) * 0.76;
            double moveY = (zachB - zahiB) * 0.838;

            Debug.Log(moveX);
            
            GameObject.Find(komaInfo[tempPosition]).transform.Translate((float)moveX,(float)moveY, 0f);

            if(meFlg){
                // 敵の駒を奪えるとき
                if(komaInfoEnemy.ContainsKey(position) && komaInfoEnemy[position] != ""){ 
                    GameObject.Find(komaInfoEnemy[position]).transform.Translate((float)zahiA, 0f, 0f);
                    GameObject.Find(komaInfoEnemy[position]).transform.Rotate(new Vector3(0, 0, 1), 180);
                    // komaInfoMeTemp[i++] = komaInfoEnemy[position];
                    komaInfoEnemy[position] = "";
                    Debug.Log("駒を取った！");
                }
            }
            else{
                //　自分の駒が奪われるとき
                if(komaInfoMe.ContainsKey(position) && komaInfoMe[position] != ""){ 
                    GameObject.Find(komaInfoMe[position]).transform.Translate(-10f + (float)zahiA, 0f, 0f);
                    GameObject.Find(komaInfoMe[position]).transform.Rotate(new Vector3(0, 0, 1), 180);
                    // komaInfoEnemyTemp[i++] = komaInfoMe[position];
                    komaInfoMe[position] = "";
                    Debug.Log("駒がとられた！");
                }
            }
            
            tempKomaInfo = komaInfo[tempPosition];
            komaInfo[tempPosition] = "";

            komaInfo[position] = tempKomaInfo;

            Debug.Log(komaInfo[position] +":"+ position);

            meFlg = !meFlg;
        }
        else{
            isClick = false;
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
