using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedSpell : MonoBehaviour
{
    public GameObject Target;
    public MonsterScript monsterStatsScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Target != null){
            Vector3 targetPostition = new Vector3(Target.transform.position.x,
                Target.transform.position.y,
                Target.transform.position.z);
            this.transform.LookAt(targetPostition);

            float distance2 = Vector3.Distance (Target.transform.position, this.transform.position);

            if(distance2 > 2.0f){
                transform.Translate(Vector3.forward * 30.0f * Time.deltaTime);
            } else {
                HitTarget();
            }
        }
    }

    void HitTarget(){
        //print(this.gameObject.health);
        Destroy(this.gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("monster"))
        {
            //print("health" + monsterStatsScript.health);
            //Destroy(collision.gameObject);
        }

    }
}
