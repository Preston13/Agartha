using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public enum Status { attacking, hit, frozen, stunned};
    public float maxHealth;

    public float curHealth;
    public WorldProgressController wpc;

    private Rigidbody rigid;
    private MeshRenderer body;
    private Color matColor;
    // Start is called before the first frame update
    void Start()
    {
        wpc = FindObjectOfType<WorldProgressController>();
        curHealth = maxHealth;
        rigid = GetComponent<Rigidbody>();
        body = GetComponentInChildren<MeshRenderer>();
        matColor = body.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(curHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Weapon")
        {
            //Will pass in whatever damage the weapon does
            TakeDamage(10);
        }
    }

    public void TakeDamage(float damage)
    {
        curHealth -= damage;
        rigid.AddForce(-transform.forward * 300);
        body.material.color = new Color(1f, 0f, 0f);
        Invoke("NormalColorChange", .2f);
       
    }

    void NormalColorChange()
    {

        body.material.color = matColor;
    }

    private void OnDestroy()
    {
        wpc.EnemySlain();

        if (wpc.enemiesKilled >= 5)
        {
            wpc.QuestCompleted();
        }
    }

}
