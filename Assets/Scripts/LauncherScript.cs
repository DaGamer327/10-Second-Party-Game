using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherScript : MonoBehaviour
{
   public GameObject Car;

    public float timer = 0f;

    public int timer2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        timer2 += 1;

        if (timer2 % 375 == 0)
        {

            Instantiate(Car, transform.position, Quaternion.identity);
            Car.GetComponent<Rigidbody2D>().AddForce(transform.forward * 10);


        }

      
    }

}
