using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectA1 : MonoBehaviour
{
    public class A
    {
        public int ad;
        public int ap;
        public int hp;
        public int ad_defense;
        public int ap_defense;
        public int mana;
        public float attack_Speed;
        public float critical;
        public string[] synergy;
        public SpriteRenderer spriteRenderer;

        // 생성자
        public A(int attackDamage, int spellPower, int healthPoints, int attackDefense, int spellDefense, int mana, float attackSpeed, float criticalChance, string[] synergies, SpriteRenderer renderer)
        {
            ad = attackDamage;
            ap = spellPower;
            hp = healthPoints;
            ad_defense = attackDefense;
            ap_defense = spellDefense;
            this.mana = mana;
            attack_Speed = attackSpeed;
            critical = criticalChance;
            synergy = synergies;
            spriteRenderer = renderer;
        }
    }

    public SpriteRenderer[] spriteRenderers;
    public A a1;
    public A b1;

    public static ObjectA1 instance; // 정적 변수

    // Start is called before the first frame update
    void Start()
    {
        instance = this; // 인스턴스 할당

        a1 = new A(1, 1, 1, 1, 1, 10, 0.5f, 0.5f, new string[] { "Tank" }, spriteRenderers[0]);
        b1 = new A(1, 1, 1, 1, 1, 10, 0.5f, 0.5f, new string[] { "Tank" }, spriteRenderers[1]);
        Debug.Log(a1.spriteRenderer);
    }

    // Update is called once per frame
    void Update()
    {

    }

}