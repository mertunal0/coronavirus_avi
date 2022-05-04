using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    private Vector3 virus_anlik_konum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        virus_anlik_konum = gameObject.transform.position;
        float anlik_konum_y = virus_anlik_konum.y;
        float anlik_konum_x = virus_anlik_konum.x;
        gameObject.transform.position = new Vector3(anlik_konum_x, anlik_konum_y, -3.83f);
    }

    public void Yok_Ol_ve_Yeniden_Konumlan()
    {
        float rastgele_pozisyon_x = Random.Range(-2.8f, 2.8f);

        //yolun carptıgı virus objesini yeniden konumlandıralım
        gameObject.transform.position = new Vector3(rastgele_pozisyon_x, 9.7f, -3.83f);
    }
}
