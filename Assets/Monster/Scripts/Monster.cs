using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public int scorePoint;

    private ParticleSystem[] particleDead;
    private AudioSource explosion;

    private Text scoreText;
    private score Score;

    private void Awake()
    {
        explosion = gameObject.GetComponentsInChildren<AudioSource>()[0];
        particleDead = GameObject.Find("Explosion 1").GetComponentsInChildren<ParticleSystem>();
        Score = FindObjectOfType<score>();
        StartCoroutine("changePosition");
        scoreText = FindObjectOfType<Text>();
        gameObject.transform.localScale = new Vector3(100,100,100);
        
    }
    
    private void dieMonster()
    {
        Debug.Log("matar");
        
        explosion.Play();
        
        foreach (ParticleSystem particle in particleDead)
        {
            if (particle != null)
            {
                particle.Play();
            }
        }
        
        foreach (ParticleSystem particle in particleDead)
        {
            if (particle != null)
            {
                particle.Stop();
            }
        }
        
        Destroy(gameObject);

        score.Score += scorePoint;
        
        string scoreTextInformation = "Score " + score.Score;
        scoreText.text = scoreTextInformation;
        Debug.Log(scoreTextInformation);
        
        
        Score.createMonster();
    }
    
    IEnumerator changePosition()
    {
        while (gameObject.activeInHierarchy)
        {
            transform.position = Score.vectorAleatory();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0)) {
            dieMonster();
        }
    }
}
