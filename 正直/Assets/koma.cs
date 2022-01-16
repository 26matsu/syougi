using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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

    void meFlgAram(){
        if(meFlg){
            Debug.Log("あなたの番です");
        }
        else{
            Debug.Log("相手の番です");
        }
    }

    void Start()
    {
        meFlgAram();
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

    int[] komaMoveRoot(int position, Dictionary<int, string> komaInfo){
        Dictionary<int, string> komaInfoAite;

        if(meFlg){
            komaInfoAite = komaInfoEnemy;
        }
        else{
            komaInfoAite = komaInfoMe;
        }

        bool ifFlg1 = true;
        bool ifFlg2 = true;
        int[] arr = new int[0];

        if(komaInfo[tempPosition].Contains("fuhyou")){
            if(meFlg){
                if(komaInfo.ContainsKey(tempPosition - 1) && komaInfo[tempPosition - 1] != ""){
                    return arr;
                }
                Array.Resize(ref arr, arr.Length + 1);
                arr[arr.Length -1] = tempPosition - 1;
            }
            else{
                if(komaInfo.ContainsKey(tempPosition + 1) && komaInfo[tempPosition + 1] != ""){
                    return arr;
                }
                Array.Resize(ref arr, arr.Length + 1);
                arr[arr.Length -1] = tempPosition + 1;
            }
            return arr;
        }

        if(komaInfo[tempPosition].Contains("hisya")){
            int tempNum = tempPosition / 10;
            // 縦移動制御
            for(int i = 1; i < 9; i++){
                // 駒を超えないようにするフラグ
                if(komaInfo.ContainsKey(tempPosition + i) && komaInfo[tempPosition + i] != "" || (tempPosition + i) / 10 != tempNum){
                    ifFlg1 = false;
                }
                if(komaInfo.ContainsKey(tempPosition - i) && komaInfo[tempPosition - i] != "" || (tempPosition - i) / 10 != tempNum){
                    ifFlg2 = false;
                }

                if(ifFlg1 && (tempPosition + i) % 10 != 0){
                    if(komaInfoAite.ContainsKey(tempPosition + i) && komaInfoAite[tempPosition + i] != ""){
                        ifFlg1 = false;
                    }
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length -1] = tempPosition + i;
                }
                if(ifFlg2 && (tempPosition - i) % 10 != 0){
                    if(komaInfoAite.ContainsKey(tempPosition - i) && komaInfoAite[tempPosition - i] != ""){
                        ifFlg2 = false;
                    }
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length -1] = tempPosition - i;
                }
                if(!ifFlg1 && !ifFlg2){
                    ifFlg1 = !ifFlg1;
                    ifFlg2 = !ifFlg2;
                    break;
                }
            }
            // 横移動制御
            for(int j = 10; j < 90; j = j + 10){
                if(komaInfo.ContainsKey(tempPosition + j) && komaInfo[tempPosition + j] != ""){
                    ifFlg1 = false;
                }
                if(komaInfo.ContainsKey(tempPosition - j) && komaInfo[tempPosition - j] != ""){
                    ifFlg2 = false;
                }

                if(ifFlg1 && (tempPosition + j) / 10 < 10){
                    if(komaInfoAite.ContainsKey(tempPosition + j) && komaInfoAite[tempPosition + j] != ""){
                        ifFlg1 = false;
                    }
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length -1] = tempPosition + j;
                }
                if(ifFlg2 && (tempPosition - j) / 10 > 0){
                    if(komaInfoAite.ContainsKey(tempPosition - j) && komaInfoAite[tempPosition - j] != ""){
                        ifFlg2 = false;
                    }
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length -1] = tempPosition - j;
                }
                if(!ifFlg1 && !ifFlg2){
                    break;
                }
            }
            return arr;  
        }

        if(komaInfo[tempPosition].Contains("kakugyou")){
            // 移動1制御
            for(int i = 1; i < 9; i++){
                int iP = i * 11;
                // 駒を超えないようにするフラグ
                if(komaInfo.ContainsKey(tempPosition + iP) && komaInfo[tempPosition + iP] != "" || (tempPosition + iP) % 10 == 0){
                    ifFlg1 = false;
                }
                if(komaInfo.ContainsKey(tempPosition - iP) && komaInfo[tempPosition - iP] != "" || (tempPosition - iP) % 10 == 0){
                    ifFlg2 = false;
                }

                if(ifFlg1 && (tempPosition + iP) / 10 < 10){
                    if(komaInfoAite.ContainsKey(tempPosition + iP) && komaInfoAite[tempPosition + iP] != ""){
                        ifFlg1 = false;
                    }
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length -1] = tempPosition + iP;
                }
                if(ifFlg2 && (tempPosition - iP) / 10 > 0){
                    if(komaInfoAite.ContainsKey(tempPosition - iP) && komaInfoAite[tempPosition - iP] != ""){
                        ifFlg2 = false;
                    }
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length -1] = tempPosition - iP;
                }
                if(!ifFlg1 && !ifFlg2){
                    ifFlg1 = !ifFlg1;
                    ifFlg2 = !ifFlg2;
                    break;
                }
            }
            // 移動2制御
            for(int j = 1; j < 9; j++){
                int jP = j * 9;
                // 駒を超えないようにするフラグ
                if(komaInfo.ContainsKey(tempPosition + jP) && komaInfo[tempPosition + jP] != "" || (tempPosition + jP) % 10 == 0){
                    ifFlg1 = false;
                }
                if(komaInfo.ContainsKey(tempPosition - jP) && komaInfo[tempPosition - jP] != "" || (tempPosition - jP) % 10 == 0){
                    ifFlg2 = false;
                }

                if(ifFlg1 && (tempPosition + jP) / 10 < 10){
                    if(komaInfoAite.ContainsKey(tempPosition + jP) && komaInfoAite[tempPosition + jP] != ""){
                        ifFlg1 = false;
                    }
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length -1] = tempPosition + jP;
                }
                if(ifFlg2 && (tempPosition - jP) / 10 > 0){
                    if(komaInfoAite.ContainsKey(tempPosition - jP) && komaInfoAite[tempPosition - jP] != ""){
                        ifFlg2 = false;
                    }
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length -1] = tempPosition - jP;
                }
                if(!ifFlg1 && !ifFlg2){
                    break;
                }
            }
            
            return arr;  
        }

        // TODO 他のコマの動き制御を作る
        else{
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length -1] = position;
            return arr;
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
            int[] returnValue = komaMoveRoot(position,komaInfo);
            Debug.Log(komaInfo[tempPosition]);
            if(returnValue.Length == 0){
                Debug.Log("このコマは動かせない");
                isClick = !isClick;
            }
            else{
                Debug.Log("このコマは" + string.Join(",",returnValue) + "に置けます");
            }
            
            // TODO ハイライトをする
        }
        else{
            Debug.Log("コマが存在しない");
        }
    }

    void moveKoma(int position)
    {
        Dictionary<int, string> komaInfo;
        Dictionary<int, string> komaInfoAite;
        Dictionary<int, string> komaInfoMeTemp;
        Dictionary<int, string> komaInfoEnemyTemp;
        string tempKomaInfo;
        // Sprite tempImage;
        // Image m_Image2;

        if(meFlg){
            komaInfo = komaInfoMe;
            komaInfoAite = komaInfoEnemy;
        }
        else{
            komaInfo = komaInfoEnemy;
            komaInfoAite = komaInfoMe;
        }

        int[] returnValue = komaMoveRoot(position,komaInfo);
        
        if(Array.Exists(returnValue, x => x == position) && (!komaInfo.ContainsKey(position) || komaInfo[position] == "")){
            
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

            GameObject.Find(komaInfo[tempPosition]).transform.Translate((float)moveX,(float)moveY, 0f);

            if(meFlg){
                // 敵の駒を奪えるとき
                if(komaInfoAite.ContainsKey(position) && komaInfoAite[position] != ""){ 
                    GameObject.Find(komaInfoAite[position]).transform.Translate((float)zahiA, 0f, 0f);
                    GameObject.Find(komaInfoAite[position]).transform.Rotate(new Vector3(0, 0, 1), 180);
                    // komaInfoMeTemp[i++] = komaInfoEnemy[position];
                    komaInfoAite[position] = "";
                    Debug.Log("駒を取った！");
                }
            }
            else{
                //　自分の駒が奪われるとき
                if(komaInfoAite.ContainsKey(position) && komaInfoAite[position] != ""){ 
                    GameObject.Find(komaInfoAite[position]).transform.Translate(-10f + (float)zahiA, 0f, 0f);
                    GameObject.Find(komaInfoAite[position]).transform.Rotate(new Vector3(0, 0, 1), 180);
                    // komaInfoEnemyTemp[i++] = komaInfoMe[position];
                    komaInfoAite[position] = "";
                    Debug.Log("駒がとられた！");
                }
            }
            
            tempKomaInfo = komaInfo[tempPosition];
            komaInfo[tempPosition] = "";

            komaInfo[position] = tempKomaInfo;

            Debug.Log(komaInfo[position] +":"+ position);

            meFlg = !meFlg;
            meFlgAram();
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
