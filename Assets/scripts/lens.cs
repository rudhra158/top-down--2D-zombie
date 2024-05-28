using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

public class lens : MonoBehaviour
{
    public Volume volume;

    public float timedrunk = 10f;


    private void Update()
    {


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            if ((collision.gameObject.tag == "player") && (Input.GetKeyDown(KeyCode.E)))
            {

                if (volume.profile.TryGet(out LensDistortion lens))
                {
                    //Destroy(gameObject);
                    lens.intensity.value = -0.5f;
                    DOTween.To(() => lens.intensity.value, x => lens.intensity.value = x, 0.5f, 5f).SetLoops(6, LoopType.Yoyo).OnComplete(() =>
                    {
                        print("Tween Ended");
                        lens.intensity.value = 0f;
                    });
                }

                if (volume.profile.TryGet(out MotionBlur blur))
                {
                    DOTween.To(() => blur.intensity.value, x => blur.intensity.value = x, 0.6f, 30f).OnComplete(() =>
                    {
                        print("mtewwnend");
                        blur.intensity.value = 0f;  
                    });

                }

            }
        }
    }
    
}

