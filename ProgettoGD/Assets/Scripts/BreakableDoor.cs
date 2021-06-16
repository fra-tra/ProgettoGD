using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableDoor : MonoBehaviour
{

    [SerializeField] private int _chamberIndex; //Per andare e tornare dagli interni (che sono +1 e +2 dal loro livello di riferimento)
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private GameObject _brokenDoor;
    [SerializeField] private GameObject _doorToBreak;
    [SerializeField] public GameObject _myPrefabDust; //DustCloud
    [SerializeField] public AudioSource audioSource;

    private bool _done = false;

    private bool _isOpened = false; //Pilota la possibilità della porta di funzionare come un trigger

    public void hitHammer()
    {
        //Porta colpita dal martello
        Instantiate(_myPrefabDust, this.transform.position , Quaternion.identity);
        _doorToBreak.SetActive(false);
        _brokenDoor.SetActive(true);//cambio del game object con la versione rotta
        audioSource.Play();
        _isOpened = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && _isOpened && !_done )
        {
            _done = true;
            Debug.Log("Minchia funziona sto cazzo di cambio scena");
            _levelLoader.LoadLevelFromThis(_chamberIndex);
            
        }
    }

    public bool GetOpenDoor()
    {
        return _done;
    }
    
    

}
