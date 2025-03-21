using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //메소드
        Multiple(3, 4);
        Multiple(5, 8);
        Multiple(4, 6);

        //참조에 의한 전달
        int a = 3, b = 4;
        Debug.Log($"a={a}, b={b}");
        Swap(ref a, ref b);
        Debug.Log($"a={a}, b={b}");

        //메소드 오버로딩
        Debug.Log(Add(3, 5));
        Debug.Log(Add(3.143f, 2.34f));
    }

    public int Add(int num1, int num2)
    {
        int result = num1 + num2;
        return result;
    }

    public float Add(float num1, float num2)
    {
        float result = num1 + num2;
        return result;
    }

    public void Multiple(int num1, int num2)
    {
        int result = num1 * num2;
        Debug.Log($"{num1} * {num2} = {result}");
    }

    public void Swap(ref int num1, ref int num2)
    {
        int temp = num1;
        num1 = num2;
        num2 = temp;
    }
    public class Player : Practice
    {
        //멤버 변수
        public string ID;
        public int currentHP;


        // 멤버 함수
        public void TakeDamage(int damage)
        {
            if (currentHP > damage)
            {
                currentHP -= damage;
            }
            else
            {
                currentHP = 0;
            }
        }

        //깊은 복사
        public Player DeepCopy()
        {
            Player clone = new Player();
            clone.ID = ID;
            clone.currentHP = currentHP;

            return clone;
        }


    }
    public class GameController : Practice
    {
        //클래스 객체 생성
        public Player player01;
        public Player player02;

        private void Awake()
        {
            player01 = new Player();
            player01.ID = "서문";
            player01.currentHP = 1000;

            player02 = player01.DeepCopy();
            player02.ID = "수민";

            player01.TakeDamage(100);

            Debug.Log($"{player01.ID}의 현재 체력은 {player01.currentHP}입니다.");
            Debug.Log($"{player02.ID}의 현재 체력은 {player02.currentHP}입니다.");

            //상속
            Multiple(10, 10);


        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
