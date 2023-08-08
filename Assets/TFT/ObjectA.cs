using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectA : MonoBehaviour
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
        public Sprite[] image;

        // »ý¼ºÀÚ
        public A(int attackDamage, int spellPower, int healthPoints, int attackDefense, int spellDefense, int mana, float attackSpeed, float criticalChance, string[] synergies, Sprite[] images)
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
            image = images;
        }
    }

    public Sprite[] images;

    // Start is called before the first frame update
    void Start()
    {
        A a1 = new A(1, 1, 1, 1, 1, 10, 0.5f, 0.5f, new string[] { "Tank" }, new Sprite[] { images[0] });
    }

    // Update is called once per frame
    void Update()
    {

    }
}