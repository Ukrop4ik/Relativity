using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour {

    LevelParams bonus_to_params;
    [SerializeField]
    int bonus_value;
    public bool isEvil;
    [SerializeField]
    GameObject normal;
    [SerializeField]
    GameObject agression;
    public GameObject boomeffect;
    public GameObject sparks;
    void Start()
    {
        bonus_to_params = GameObject.FindGameObjectWithTag("LevelParams").GetComponent<LevelParams>();
        if (isEvil) SetEvil();
        else
        {
            bonus_to_params.bonuslist.Add(this.gameObject);
            bonus_to_params.bonusinlevel++;
        } 
    }
    public void SetEvil()
    {
        isEvil = true;
        normal.SetActive(false);
        agression.SetActive(true);
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SoundManager manager = GameObject.FindGameObjectWithTag("SoundSystem").GetComponent<SoundManager>();
            manager.PlaySound(AudioEnum.Bonus);

            if (isEvil)
            {
                SoundManager managers = GameObject.FindGameObjectWithTag("SoundSystem").GetComponent<SoundManager>();
                managers.PlaySound(AudioEnum.Boom);
                Instantiate(boomeffect, gameObject.transform.position, Quaternion.identity);
                bonus_to_params.LevelFail();

            }
            else
            {
                bonus_to_params.GetBonus();
                Instantiate(sparks, transform.position, Quaternion.identity);
            }



            Debug.Log("Collect!");
            if (bonus_to_params.bonuslist.Contains(this.gameObject))
            {
                bonus_to_params.bonuslist.Remove(this.gameObject);
            }
            Destroy(gameObject);
            
        }
    }
}
