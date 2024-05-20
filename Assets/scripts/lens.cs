using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class lens : MonoBehaviour
{
    public Volume volume;

    bool distort = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (distort)
        {
            if (volume.profile.TryGet(out LensDistortion lens))
            {
                float tempVal = lens.intensity.value;
                tempVal *= Time.deltaTime;
               // lens.intensity.value = tempVal;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            if ((collision.gameObject.tag == "player") && (Input.GetKeyDown(KeyCode.E)))
            {

                if (volume.profile.TryGet(out LensDistortion lens))
                {
                    for (float i = 0; i < 10; i++)
                    {
                        distort = true;
                        lens.intensity.value = Random.Range(-0.99f, 0.99f);
                    }
                }
               //Destroy(gameObject);

            }
        }
    }
}

