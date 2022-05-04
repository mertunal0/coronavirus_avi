using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Oyuncu : MonoBehaviour
{
    public      float oyuncunun_cani;
    public      float oyuncu_max_can;
    public      int skor;
    public      TextMeshProUGUI skor_texti;
    public      GameObject skor_objesi;
    public      TextMeshProUGUI skor_text_oyun_sonu;
    public      Image can_bari_tupu;
    public      GameObject oyun_bitti_ekrani;
    public      GameObject duraklama_ekrani;
    public      Button duraklama_butonu;
    public      Button devam_butonu;
    public      Animator oyuncu_animasyon;
    public      Button sol_hareket_butonu;
    public      Button sag_hareket_butonu;
    private     Vector3 karakter_anlik_konum;

    private void OnCollisionEnter(Collision carpisma_olayi)
    {
        if (carpisma_olayi.gameObject.tag == "virus_nesnesi")
        {
            oyuncunun_cani--;
            can_bari_tupu.fillAmount = oyuncunun_cani / oyuncu_max_can;

            //oyuncunun canı bittiyse oyunu durdurak
            if (oyuncunun_cani < 1)
            {
                Oyunu_Durdur();
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        oyuncunun_cani      = 5;
        oyuncu_max_can      = 5;
        skor = 0;
        skor_texti          = GameObject.Find("Oyun_Layout/Canvas/skor_objesi/skor_text").GetComponent<TextMeshProUGUI>();
        skor_text_oyun_sonu = GameObject.Find("Oyun_Layout/Canvas/oyun_bitti_ekrani/duraklama_ekrani_img/skor_text_oyun_sonu").GetComponent<TextMeshProUGUI>();
        skor_texti.text     = "0";
        can_bari_tupu       = GameObject.Find("Oyun_Layout/Canvas/can_bari_tupu").GetComponent<Image>();
        oyuncu_animasyon    = GetComponent<Animator>();
        sol_hareket_butonu  = GameObject.Find("Oyun_Layout/Canvas/sol_hareket_btn").GetComponent<Button>();
        sag_hareket_butonu  = GameObject.Find("Oyun_Layout/Canvas/sag_hareket_btn").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        skor_texti.text = Skor_Texti_Hesapla(skor);

        //adamın saçma sapan hareket etmemesi açısından önlem alalım
        karakter_anlik_konum = gameObject.transform.position;
        float anlik_konum_x = karakter_anlik_konum.x;
        gameObject.transform.position = new Vector3(anlik_konum_x, 0.12f, -3.83f);
    }

    public void Saga_Yurume_Islemini_Gerceklestir()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        oyuncu_animasyon.SetBool("yuru_b", true);
    }
    public void Sola_Yurume_Islemini_Gerceklestir()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 270, 0);
        oyuncu_animasyon.SetBool("yuru_b", true);
    }
    public void Ates_Etme_Islemini_Gerceklestir()
    {
        oyuncu_animasyon.SetBool("ates_et_b", true);
    }
    public void Idle_Moda_Geri_Don()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        oyuncu_animasyon.SetBool("ates_et_b", false);
        oyuncu_animasyon.SetBool("yuru_b", false);
    }

    private string Skor_Texti_Hesapla(int skor)
    {
        if(skor/1000 < 1)
        {
            return skor.ToString();
        }
        else
        {
            return string.Format("{0:0,0}", skor);
        }

    }

    private void Oyunu_Durdur()
    {
        //zamani durduralim.
        Time.timeScale = 0.0f;

        //duraklama ekranını açalım
        oyun_bitti_ekrani.SetActive(true);

        //skoru yazdıralım
        skor_text_oyun_sonu.text = Skor_Texti_Hesapla(skor);

        //arkadaki skoru göstermeyelim
        skor_objesi.SetActive(false);
    }

    public void Oyunu_Duraklat()
    {
        //zamani durduralim.
        Time.timeScale = 0.0f;

        //duraklama ekranını açalım
        duraklama_ekrani.SetActive(true);

        //butonlari switch edelim
        duraklama_butonu.gameObject.SetActive(false);
        devam_butonu.gameObject.SetActive(true);
    }
    public void Oyunu_Devam_Ettir()
    {
        //zamani devam ettirelim.
        Time.timeScale = 1.0f;

        //duraklama ekranını açalım
        duraklama_ekrani.SetActive(false);

        //butonlari switch edelim
        duraklama_butonu.gameObject.SetActive(true);
        devam_butonu.gameObject.SetActive(false);
    }

}
