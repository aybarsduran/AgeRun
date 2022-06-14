using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{

    public Transform endPosition;
    public Transform Player;
    public Animator PlayerAnim;
    public WearableManager wManager;

    public Animator firstJuriAnim;
    public Animator secondJuriAnim;
    public Animator thirdJuriAnim;

    float score;
   
    public float distance;

    public TextMeshPro scoreElement;
    void Start()
    {
        score = 0;
        firstJuriAnim.enabled = false;
        secondJuriAnim.enabled = false;
        thirdJuriAnim.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(Player.transform.position, endPosition.transform.position);
       

        if (distance < 10f && distance >= 0.3f)
        {
          
           Player.transform.position = Vector3.MoveTowards(Player.transform.position, endPosition.transform.position, 2 * Time.deltaTime);
        }
        if (distance < 0.3f) {
            PlayerAnim.SetBool("EndScreenPose",true);

            firstJuriAnim.enabled = true;
            secondJuriAnim.enabled = true;
            thirdJuriAnim.enabled = true;


        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.End);

            print(CalculateScores(wManager.ReturnActiveHat(), wManager.ReturnActiveUpper(), wManager.ReturnActiveLower(), wManager.ReturnActiveBoot()));
            scoreElement.text = score.ToString();
        }
    }

    /*
     * basecloth -> 0 puan
     * roma 400.yýl -> 0.5 puan hepsine 2 ile 4 arasýnda puan
     * england 1700ler -> 0.75 puan hepsine 3 ile 5 arasýnda puan vercekler 
     * kovboy 1800lerin ortasýnda -> 1 puan hepsine 4 ile 6 arasýnda puan alcak
     * disco 1970ler -> 1.5 puan hepsine 6 ile 8 arasýnda alcak
     * suit 2000ler -> 2 þer puan hepsine 4 parca 8 ila 10 arasýnda alcak
     * 
     * */

    public float CalculateScores(string hatTag,string upperTag,string lowerTag,string bootTag)
    {
        //HATS
        if (hatTag == "RomenHat")
        {
            score +=0.5f;
        }
        if (hatTag == "EnglandHat")
        {
            score += 0.75f;
        }
        if (hatTag == "CowboyHat")
        {
            score += 1f;
        }
        if (hatTag == "DiscoHat")
        {
            score += 1.5f;
        }
        if (hatTag == "SuitSunglass")
        {
            score += 2f;
        }
        //UPPER
        if (upperTag == "RomenShirt")
        {
            score += 0.5f;
        }
        if (upperTag == "EnglandShirt")
        {
            score += 0.75f;
        }
        if (upperTag == "CowboyShirt")
        {
            score += 1f;
        }
        if (upperTag == "DiscoShirt")
        {
            score += 1.5f;
        }
        if (upperTag == "SuitShirt")
        {
            score += 2f;
        }
        //LOWER
        if (lowerTag == "RomenPants")
        {
            score += 0.5f;
        }
        if (lowerTag == "EnglandPant")
        {
            score += 0.75f;
        }
        if (lowerTag == "CowboyPants")
        {
            score += 1f;
        }
        if (lowerTag == "DiscoPants")
        {
            score += 1.5f;
        }
        if (lowerTag == "SuitPant")
        {
            score += 2f;
        }

        //BOOT

        if (bootTag == "RomenShoe")
        {
            score += 0.5f;
        }
        if (bootTag == "EnglandShoe")
        {
            score += 0.75f;
        }
        if (bootTag == "CowboyShoe")
        {
            score += 1f;
        }
        if (bootTag == "DiscoShoe")
        {
            score += 1.5f;
        }
        if (bootTag == "SuitShoe")
        {
            score += 2f;
        }


        return score;

    }
}
