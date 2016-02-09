using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelParams : MonoBehaviour {
    [SerializeField]
    UILevel ui;

    public string lvl_name;
    public int bonus_count { get; private set; }
    public int artefact_count_in_lvl;
    public bool artefact_status = false;

    public List<GameObject> artefacts = new List<GameObject>();

    void Start()
    {
        artefacts.AddRange(GameObject.FindGameObjectsWithTag("artefact"));
        artefact_count_in_lvl = artefacts.Count;
    }
    public void SetBonus(int value)
    {
        bonus_count += value;
        ui.bonus_text.text = "Bonus: " + bonus_count;
    }
    public void ArtefactRemove(GameObject artefact)
    {
        artefacts.Remove(artefact);
        artefact_count_in_lvl = artefacts.Count;

        if (artefact_count_in_lvl == 0)
        {
            artefact_status = true;
        }
    }
}
