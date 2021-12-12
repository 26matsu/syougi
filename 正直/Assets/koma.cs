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
        komaInfoEnemy.Add(91, "香車b");
        komaInfoEnemy.Add(81, "桂馬b");
        komaInfoEnemy.Add(71, "銀将b");
        komaInfoEnemy.Add(61, "金将b");
        komaInfoEnemy.Add(51, "玉将");
        komaInfoEnemy.Add(41, "金将b");
        komaInfoEnemy.Add(31, "銀将b");
        komaInfoEnemy.Add(21, "桂馬b");
        komaInfoEnemy.Add(11, "香車b");

        komaInfoEnemy.Add(82, "飛車b");
        komaInfoEnemy.Add(22, "角行b");

        komaInfoEnemy.Add(93, "歩兵b");
        komaInfoEnemy.Add(83, "歩兵b");
        komaInfoEnemy.Add(73, "歩兵b");
        komaInfoEnemy.Add(63, "歩兵b");
        komaInfoEnemy.Add(53, "歩兵b");
        komaInfoEnemy.Add(43, "歩兵b");
        komaInfoEnemy.Add(33, "歩兵b");
        komaInfoEnemy.Add(23, "歩兵b");
        komaInfoEnemy.Add(13, "歩兵b");

        komaInfoMe.Add(97, "歩兵a");
        komaInfoMe.Add(87, "歩兵a");
        komaInfoMe.Add(77, "歩兵a");
        komaInfoMe.Add(67, "歩兵a");
        komaInfoMe.Add(57, "歩兵a");
        komaInfoMe.Add(47, "歩兵a");
        komaInfoMe.Add(37, "歩兵a");
        komaInfoMe.Add(27, "歩兵a");
        komaInfoMe.Add(17, "歩兵a");

        komaInfoMe.Add(88, "角行a");
        komaInfoMe.Add(28, "飛車a");
        
        komaInfoMe.Add(99, "香車a");
        komaInfoMe.Add(89, "桂馬a");
        komaInfoMe.Add(79, "銀将a");
        komaInfoMe.Add(69, "金将a");
        komaInfoMe.Add(59, "王将");
        komaInfoMe.Add(49, "金将a");
        komaInfoMe.Add(39, "銀将a");
        komaInfoMe.Add(29, "桂馬a");
        komaInfoMe.Add(19, "香車a");


        GameObject kyousya1 = GameObject.Find("91").transform.Find("Image");
        m_Image = kyousya1.GetComponent<Image>();
        m_Image.sprite = m_Sprite[24];
        // GameObject keima1 = GameObject.Find ("81");
        // m_Image = keima1.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[22];
        // GameObject ginsyou1 = GameObject.Find ("71");
        // m_Image = ginsyou1.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[20];
        // GameObject kinsyou1 = GameObject.Find ("61");
        // m_Image = kinsyou1.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[19];
        // GameObject gyokusyou = GameObject.Find ("51");
        // m_Image = gyokusyou.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[1];
        // GameObject kinsyou2 = GameObject.Find ("41");
        // m_Image = kinsyou2.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[19];
        // GameObject ginsyou2 = GameObject.Find ("31");
        // m_Image = ginsyou2.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[20];
        // GameObject keima2 = GameObject.Find ("21");
        // m_Image = keima2.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[22];
        // GameObject kyousya2 = GameObject.Find ("11");
        // m_Image = kyousya2.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[24];

        // GameObject hisya1 = GameObject.Find ("82");
        // m_Image = hisya1.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[15];
        // GameObject gakugyou1 = GameObject.Find ("22");
        // m_Image = gakugyou1.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[17];

        // GameObject hohei1 = GameObject.Find ("93");
        // m_Image = hohei1.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[26];
        // GameObject hohei2 = GameObject.Find ("83");
        // m_Image = hohei2.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[26];
        // GameObject hohei3 = GameObject.Find ("73");
        // m_Image = hohei3.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[26];
        // GameObject hohei4 = GameObject.Find ("63");
        // m_Image = hohei4.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[26];
        // GameObject hohei5 = GameObject.Find ("53");
        // m_Image = hohei5.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[26];
        // GameObject hohei6 = GameObject.Find ("43");
        // m_Image = hohei6.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[26];
        // GameObject hohei7 = GameObject.Find ("33");
        // m_Image = hohei7.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[26];
        // GameObject hohei8 = GameObject.Find ("23");
        // m_Image = hohei8.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[26];
        // GameObject hohei9 = GameObject.Find ("13");
        // m_Image = hohei9.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[26];


        // GameObject hohei11 = GameObject.Find ("97");
        // m_Image = hohei11.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[13];
        // GameObject hohei12 = GameObject.Find ("87");
        // m_Image = hohei12.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[13];
        // GameObject hohei13 = GameObject.Find ("77");
        // m_Image = hohei13.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[13];
        // GameObject hohei14 = GameObject.Find ("67");
        // m_Image = hohei14.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[13];
        // GameObject hohei15 = GameObject.Find ("57");
        // m_Image = hohei15.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[13];
        // GameObject hohei16 = GameObject.Find ("47");
        // m_Image = hohei16.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[13];
        // GameObject hohei17 = GameObject.Find ("37");
        // m_Image = hohei17.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[13];
        // GameObject hohei18 = GameObject.Find ("27");
        // m_Image = hohei18.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[13];
        // GameObject hohei19 = GameObject.Find ("17");
        // m_Image = hohei19.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[13];

        // GameObject gakugyou2 = GameObject.Find ("88");
        // m_Image = gakugyou2.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[4];
        // GameObject hisya2 = GameObject.Find ("28");
        // m_Image = hisya2.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[2];
        
        // GameObject kyousya3 = GameObject.Find ("99");
        // m_Image = kyousya3.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[11];
        // GameObject keima3 = GameObject.Find ("89");
        // m_Image = keima3.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[9];
        // GameObject ginsyou3 = GameObject.Find ("79");
        // m_Image = ginsyou3.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[7];
        // GameObject kinsyou3 = GameObject.Find ("69");
        // m_Image = kinsyou3.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[6];
        // GameObject ousyou = GameObject.Find ("59");
        // m_Image = ousyou.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[0];
        // GameObject kinsyou4 = GameObject.Find ("49");
        // m_Image = kinsyou4.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[6];
        // GameObject ginsyou4 = GameObject.Find ("39");
        // m_Image = ginsyou4.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[7];
        // GameObject keima4 = GameObject.Find ("29");
        // m_Image = keima4.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[9];
        // GameObject kyousya4 = GameObject.Find ("19");
        // m_Image = kyousya4.GetComponent<Image>();
        // m_Image.sprite = m_Sprite[11];

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
            isClick = false;
            tempKomaInfo = komaInfo[tempPosition];
            komaInfo[tempPosition] = "";
            GameObject kyousyaB = GameObject.Find (tempPosition.ToString());
            m_Image = kyousyaB.GetComponent<Image>();
            GameObject kyousyaA = GameObject.Find (position.ToString());
            m_Image2 = kyousyaA.GetComponent<Image>();
            tempImage = m_Image.sprite;
            m_Image.sprite = m_Image2.sprite;
            m_Image2.sprite = tempImage;

            komaInfo[position] = tempKomaInfo;
            
            //Debug.Log(m_Image2.sprite);

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
