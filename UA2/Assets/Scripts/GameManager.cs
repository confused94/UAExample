using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;//DotWeen kütüphanesinin özelliklerini kullanabilmek için kütüphane.Panel animasyonu için kullanıldı.
using TMPro;
using System;
using UnityEngine.UI;

[Serializable]
class PanelTransformu//panelleri bir arada tutan sınıf.
{
    public RectTransform panel1, panel2;//Panellerin transformuna ulaşmak için kullanılan fieldlar.
}
public class GameManager : MonoBehaviour
{
    /*Bu script paneller arasında dotween kütüphanesinden yaralanarak animasyonlu geçiş sağlar.
    Hesapla butonu ile Panelmove metdu çalışır.Çalıştığı gibi
    kullanıcının girdiği ilksayi ve sonsayi arasındaki değerleri listede toplar ve bolenbul fonksiyonunda
    2,3,4 ve 5 e bölünenleri hesaplar,paneleyazdir fonksiyonunu tetikeleyerek panel2 içerisindeki textlere yazdırır*/

    [Header("Panel Transformu")]//Inspectorda fieldlara başlık açıklama ekler.
    [SerializeField]//unity editöründen ulaşılmasını sağlar
    PanelTransformu paneltransformu;
    //***********Bölen textler*****************
    [SerializeField]
    TextMeshProUGUI tumListetxt,ikiyeBolentxt, uceBolentxt, dordeBolentxt, beseBolentxt;
    //***********ilk sayi ve son sayi ınputfieldları*****************
    [SerializeField]
    TMP_InputField ilkSayitxt, sonSayitxt;
    [SerializeField]
    Button btn;
    
    List<int> sayilistesi = new List<int>();
    //***********String değişkenler****************
    string tumListe,ikiBol, ucBol, dortBol, besBol;//Text'e yazdıracağımız sayıları bir arada tutacak string değişkenler.
    private void Update()
    {
        if (ilkSayitxt.text != String.Empty && sonSayitxt.text != String.Empty)
            btn.interactable = true;
        else
            btn.interactable = false;
        
        
    }
    public void Panelmove()//Buton ile çalışır. Paneller arasında animasyon ile geçiş yapmayı sağlar.
    {
        paneltransformu.panel1.DOAnchorPos(new Vector2(1932f, 0), 1f).SetEase(Ease.InElastic);
        paneltransformu.panel2.DOAnchorPos(Vector2.zero, 1f).SetDelay(0.5f).SetEase(Ease.InOutElastic);
        Bolenbul(int.Parse(ilkSayitxt.text), int.Parse(sonSayitxt.text));
    }
    public void geriIslevi()
    {
        paneltransformu.panel1.DOAnchorPos(Vector2.zero, 1f).SetEase(Ease.InElastic);
        paneltransformu.panel2.DOAnchorPos(new Vector2(-1941f,0), 1f).SetDelay(0.5f).SetEase(Ease.InOutElastic);
    }
    void Bolenbul(int a,int b)
    {
        for(int i = a; i < b; i++)
        {
            sayilistesi.Add(i);//İlk sayidan son sayiya kadar olan sayilar listeye eklenir.
        }
        foreach (int item in sayilistesi)
        {
            //Sayilistesi içerisindneki değerler string türlü değişkenlerde ekrana yazdırılmak için saklanır.
            tumListe += item + ",";
            if (item % 2 == 0)
            {
                ikiBol += item + "-";
            }
            if (item % 3 == 0)
            {
                ucBol += item + "-";
            }
            if (item % 4 == 0)
            {
                dortBol += item + "-";
            }
            if (item % 5 == 0)
            {
                besBol += item + "-";
            }
            
        }
        Paneleyazdir();
    }
        
    void Paneleyazdir()
    {
        tumListetxt.text = tumListe;
        ikiyeBolentxt.text = ikiBol;
        uceBolentxt.text = ucBol;
        dordeBolentxt.text = dortBol;
        beseBolentxt.text = besBol;
    }
    public void cikis()
    {
        Application.Quit();
    }
}
