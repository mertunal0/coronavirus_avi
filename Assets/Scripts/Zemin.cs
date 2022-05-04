using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zemin : MonoBehaviour
{


    private void OnCollisionEnter(Collision carpisma_olayi) 
    {
        if(carpisma_olayi.gameObject.tag == "virus_nesnesi") {

            float rastgele_pozisyon_x = Random.Range(-2.8f, 2.8f);

            //yolun carptıgı virus objesini yeniden konumlandıralım
            carpisma_olayi.gameObject.transform.position = new Vector3(rastgele_pozisyon_x, 9.7f, -3.83f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //   
    }
}
