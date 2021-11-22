using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAI : MonoBehaviour
{
    public GameObject projectile;
    
    [SerializeField] GameObject bossModel;
    [SerializeField] GameObject lazerModel1;
    [SerializeField] List<GameObject> walls;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(attack(5f));
    }

    void randomAttack()
    {
        
        switch(Random.Range(0, 3))
        {
            case 0:
                StartCoroutine(spray1(.1f, 30, 0, true));
                break;
            case 1:
                StartCoroutine(spray2(.5f, true, 0));
                break;
            case 2:
                StartCoroutine(lazer1(5f));
                break;
            default:
                
                break;
        }
    }

    void disableWalls()
    {
        foreach (GameObject wall in walls)
        {
            wall.SetActive(false);
        }
    }

    void enableWalls()
    {
        walls[Random.Range(0, walls.Capacity)].SetActive(true);
        walls[Random.Range(0, walls.Capacity)].SetActive(true);
    }

    IEnumerator attack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime-1);
        disableWalls();
        yield return new WaitForSeconds(.3f);
        enableWalls();
        yield return new WaitForSeconds(.3f);
        randomAttack();

        StartCoroutine(attack(waitTime));

    }

    IEnumerator lazer1(float waitTime)
    {
        lazerModel1.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        lazerModel1.SetActive(false);


    }

    IEnumerator spray2(float waitTime, bool flip, int currentBullet)
    {
        yield return new WaitForSeconds(waitTime);

        int maxBullets = 5;
        int add = 0;


        if (currentBullet > maxBullets)
        {
            yield break;
        }

        if (flip)
        {
            add = 5;
        }

        Instantiate(projectile, bossModel.transform.position + bossModel.transform.forward * 7, bossModel.transform.rotation * Quaternion.Euler(Vector3.up * (-50 - add)));
        Instantiate(projectile, bossModel.transform.position + bossModel.transform.forward * 7, bossModel.transform.rotation * Quaternion.Euler(Vector3.up * (-40-add)));
        Instantiate(projectile, bossModel.transform.position + bossModel.transform.forward * 7, bossModel.transform.rotation * Quaternion.Euler(Vector3.up * (-30 - add)));
        Instantiate(projectile, bossModel.transform.position + bossModel.transform.forward * 7, bossModel.transform.rotation * Quaternion.Euler(Vector3.up * (-20 - add)));
        Instantiate(projectile, bossModel.transform.position + bossModel.transform.forward * 7, bossModel.transform.rotation * Quaternion.Euler(Vector3.up * (-10 - add)));
        Instantiate(projectile, bossModel.transform.position + bossModel.transform.forward * 7, bossModel.transform.rotation * Quaternion.Euler(Vector3.up * (1- add)));
        Instantiate(projectile, bossModel.transform.position + bossModel.transform.forward * 7, bossModel.transform.rotation * Quaternion.Euler(Vector3.up * (10 - add)));
        Instantiate(projectile, bossModel.transform.position + bossModel.transform.forward * 7, bossModel.transform.rotation * Quaternion.Euler(Vector3.up * (20 - add)));
        Instantiate(projectile, bossModel.transform.position + bossModel.transform.forward * 7, bossModel.transform.rotation * Quaternion.Euler(Vector3.up * (30 - add)));
        Instantiate(projectile, bossModel.transform.position + bossModel.transform.forward * 7, bossModel.transform.rotation * Quaternion.Euler(Vector3.up * (40 - add)));
        Instantiate(projectile, bossModel.transform.position + bossModel.transform.forward * 7, bossModel.transform.rotation * Quaternion.Euler(Vector3.up * (50 - add)));

        StartCoroutine(spray2(waitTime, !flip, currentBullet + 1));
    }

    IEnumerator spray1(float waitTime, float degrees, int currentBullet, bool down)
    {
        yield return new WaitForSeconds(waitTime);

        int maxBullets = 40;
        int deg = 45;
        int stepSize = 5;

        if (currentBullet > maxBullets)
        {
            yield break;
        }

        Instantiate(projectile, bossModel.transform.position + bossModel.transform.forward * 7, bossModel.transform.rotation * Quaternion.Euler(Vector3.up * degrees));

        if (degrees >= deg)
        {
            degrees = deg - stepSize;
            down = true;
        }
        else if (degrees <= -deg)
        {
            degrees = -deg + stepSize;
            down = false;
        }
        else if(down)
        {
            degrees = degrees - stepSize;
        }
        else
        {
            degrees = degrees + stepSize;
        }


        StartCoroutine(spray1(waitTime, degrees, currentBullet+1, down));
    }

    /*
        StartCoroutine(wait(5f));
        GameObject bullet = Instantiate(projectile, gun.transform.position + gun.transform.forward, gun.transform.rotation);
        bullet.GetComponent<doDamage>().damageValue = BulletDamage;
        */
}
