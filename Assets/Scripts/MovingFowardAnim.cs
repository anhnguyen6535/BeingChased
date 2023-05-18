using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFowardAnim : MonoBehaviour
{
    public bool walk = false;
    private int state = 0;
    public float WalkingVelocity = 0.5f;
    public float StopingVelocity = 0.7f;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(walk){
            state = 1;
            anim.SetInteger("walk",state);
            transform.Translate(Vector3.forward * Time.deltaTime * WalkingVelocity);
        }else if(state == 1){
            state = 2;
            anim.SetInteger("walk",state);
            transform.Translate(Vector3.forward * Time.deltaTime * StopingVelocity);
            StartCoroutine(AnimFinish());
        }
    }

    IEnumerator AnimFinish() {
        yield return new WaitWhile(()=>anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1);
        state = 0;
        anim.SetInteger("walk",state);
    }
}
