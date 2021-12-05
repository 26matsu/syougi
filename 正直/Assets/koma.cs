using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class koma : MonoBehaviour
{
    private Image m_Image;
    public Sprite[] m_Sprite;
    bool isClick;
    int tempPosition;

    //Dictionaryクラスのオブジェクト生成
    Dictionary<int, string> komainfo = new Dictionary<int, string>();

    void Start()
    {
        
    
        //キーと値をセットする
        komainfo.Add(91, "香車b");
        komainfo.Add(81, "桂馬b");
        komainfo.Add(71, "銀将b");
        komainfo.Add(61, "金将b");
        komainfo.Add(51, "玉将");
        komainfo.Add(41, "金将b");
        komainfo.Add(31, "銀将b");
        komainfo.Add(21, "桂馬b");
        komainfo.Add(11, "香車b");

        komainfo.Add(82, "飛車b");
        komainfo.Add(22, "角行b");

        komainfo.Add(93, "歩兵b");
        komainfo.Add(83, "歩兵b");
        komainfo.Add(73, "歩兵b");
        komainfo.Add(63, "歩兵b");
        komainfo.Add(53, "歩兵b");
        komainfo.Add(43, "歩兵b");
        komainfo.Add(33, "歩兵b");
        komainfo.Add(23, "歩兵b");
        komainfo.Add(13, "歩兵b");

        komainfo.Add(97, "歩兵a");
        komainfo.Add(87, "歩兵a");
        komainfo.Add(77, "歩兵a");
        komainfo.Add(67, "歩兵a");
        komainfo.Add(57, "歩兵a");
        komainfo.Add(47, "歩兵a");
        komainfo.Add(37, "歩兵a");
        komainfo.Add(27, "歩兵a");
        komainfo.Add(17, "歩兵a");

        komainfo.Add(88, "角行a");
        komainfo.Add(28, "飛車a");
        
        komainfo.Add(99, "香車a");
        komainfo.Add(89, "桂馬a");
        komainfo.Add(79, "銀将a");
        komainfo.Add(69, "金将a");
        komainfo.Add(59, "王将");
        komainfo.Add(49, "金将a");
        komainfo.Add(39, "銀将a");
        komainfo.Add(29, "桂馬a");
        komainfo.Add(19, "香車a");

        // for (int i = 0; i < 15; i++){
        //     Debug.Log(m_Sprite[i]);
        // }
        

        GameObject kyousya1 = GameObject.Find ("91");
        m_Image = kyousya1.GetComponent<Image>();
        m_Image.sprite = m_Sprite[11];
        GameObject keima1 = GameObject.Find ("81");
        m_Image = keima1.GetComponent<Image>();
        m_Image.sprite = m_Sprite[9];
        GameObject ginsyou1 = GameObject.Find ("71");
        m_Image = ginsyou1.GetComponent<Image>();
        m_Image.sprite = m_Sprite[7];

    }

	public void OnClick(int position)
    {
        
        if (!isClick){
            isClick = true;
            //if(komainfo[position] == "香車b"){
                tempPosition = position;
            //}
        }
        else{
            isClick = false;

            komainfo[tempPosition] = "";
            GameObject kyousyaB = GameObject.Find (tempPosition.ToString());
            m_Image = kyousyaB.GetComponent<Image>();
            m_Image.sprite = null;
            komainfo[position] = "香車b";
            GameObject kyousyaA = GameObject.Find (position.ToString());
            m_Image = kyousyaA.GetComponent<Image>();
            m_Image.sprite = m_Sprite[11];
            Debug.Log(komainfo[position] +":"+ position);
        }
        
    }

    void Update()
    {
        
    }
}
