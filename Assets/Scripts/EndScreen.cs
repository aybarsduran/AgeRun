using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{

    public Transform endPosition;
    public Transform Player;
    public Transform path;
    public Transform startPath;

    public Transform Parent;


    public WearableManager wManager;

    public Animator PlayerAnim;
    public Animator podiumAnim;
    public Animator firstJuriAnim;
    public Animator secondJuriAnim;
    public Animator thirdJuriAnim;

    public Animator perdeAnim;



    public endscreenParticles endscreenParticles;

    bool firstJuriAnimated;
    bool secondJuriAnimated;
    bool thirdJuriAnimated;

 



 
    public Transform spotlight1;
    public Transform spotlight2;
    public Transform spotlight3;



    float score;
    int firstScore;
    int secondScore;
    int thirdScore;
   
    public float distance;
    public float pathDistance;
    public float startPathDistance;

    public List<Animator> seyirciler;

    bool pathReached;
    bool startPathReached;


    public TextMeshPro firstScoreElement;
    public TextMeshPro secondScoreElement;
    public TextMeshPro thirdScoreElement;
    void Start()
    {
        score = 0;
        firstScore = 0;
        secondScore = 0;
        thirdScore = 0;

        firstJuriAnimated = false;




        pathReached = false;
        startPathReached = false;

        perdeAnim.enabled = false;
        foreach(Animator anim in seyirciler)
        {
            anim.enabled = false ;
        }

        podiumAnim.enabled = false;
        firstJuriAnim.enabled = false;
        secondJuriAnim.enabled = false;
        thirdJuriAnim.enabled = false;
        endscreenParticles.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector3.Distance(Player.transform.position, endPosition.transform.position);
        pathDistance = Vector3.Distance(Player.transform.position, path.transform.position);
        startPathDistance= Vector3.Distance(Player.transform.position, startPath.transform.position);

       
        if(startPathDistance<9f && startPathDistance > 0.5f&& startPathReached==false)
        {
            Player.transform.position = Vector3.MoveTowards(Player.transform.position,startPath.transform.position, 3 * Time.fixedDeltaTime);
            Parent.transform.LookAt(startPath);
           
        }
        if (pathDistance < 18  && pathDistance>0.6f&& pathReached==false&& startPathReached)
        {
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, path.transform.position, 3 * Time.fixedDeltaTime);
            Parent.transform.LookAt(path);
           
        }
        if (pathDistance <= 0.6f && pathDistance > 0.5f)
        {
            pathReached = true;
        }
        if(startPathDistance<=0.5f && startPathDistance > 0.4f)
        {
            startPathReached = true;
        }
        if (distance<4f && distance >= 0.3f && pathReached && startPathReached)
        {

                //Debug.Log("calisiyor");
                Parent.LookAt(endPosition);
                Player.transform.position = Vector3.MoveTowards(Player.transform.position, endPosition.transform.position, 3 * Time.fixedDeltaTime);

               
        }
        if(distance < 20f && distance>0.3f)
        {
            spotlight1.transform.LookAt(Player.transform);
            spotlight2.transform.LookAt(Player.transform);
            spotlight3.transform.LookAt(Player.transform);
        }
        
        if (distance < 0.3f) {
            PlayerAnim.SetBool("EndScreenPose",true);
            podiumAnim.enabled = true;
           
            if (Parent.transform.rotation.y<22.4f)
            {
                StartCoroutine(FirstJuriAnimation());
                
                




                endscreenParticles.enabled = true;
                

            }




        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.End);
            perdeAnim.enabled = true;
            foreach (Animator anim in seyirciler)
            {
                anim.enabled = true;
            }

            print(CalculateScores(wManager.ReturnActiveHat(), wManager.ReturnActiveUpper(), wManager.ReturnActiveLower(), wManager.ReturnActiveBoot()));
            if (score >= 8)
            {
                firstScore = Random.Range(8, 11);
                secondScore = Random.Range(8, 11);
                thirdScore = Random.Range(8, 11);
            }
            if(score >= 6 && score < 8)
            {
                firstScore = Random.Range(6, 9);
                secondScore= Random.Range(6, 9);
                thirdScore= Random.Range(6, 9);
            }
            if(score>=4 && score < 6)
            {
                firstScore = Random.Range(4, 7);
                secondScore = Random.Range(4, 7);
                thirdScore = Random.Range(4, 7);
            }
            if(score>=2 && score < 4)
            {
                firstScore = Random.Range(2, 5);
                secondScore = Random.Range(2, 5);
                thirdScore = Random.Range(2, 5);
            }
            if (score < 2)
            {
                firstScore = Random.Range(0, 3);
                secondScore = Random.Range(0, 3);
                thirdScore = Random.Range(0, 3);
            }
            firstScoreElement.text = firstScore.ToString();
            secondScoreElement.text = secondScore.ToString();
            thirdScoreElement.text = thirdScore.ToString();
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


    IEnumerator FirstJuriAnimation()
    {
        
        if (firstJuriAnimated == false) {
            thirdJuriAnim.enabled = true;
        }
        yield return new WaitForSeconds(1f);
        firstJuriAnimated = true;
        StartCoroutine(SecondJuriAnimation());
    }
    IEnumerator SecondJuriAnimation()
    {
        if (firstJuriAnimated == true)
        {
            secondJuriAnim.enabled = true;
        }
        yield return new WaitForSeconds(1f);
        secondJuriAnimated = true;
        StartCoroutine(ThirdJuriAnimation());
    }
    IEnumerator ThirdJuriAnimation()
    {
        if (secondJuriAnimated == true)
        {
            firstJuriAnim.enabled = true;
        }
        yield return new WaitForSeconds(1f);
    }
}
