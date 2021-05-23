using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableDoor : MonoBehaviour
{

    [SerializeField] private int _chamberIndex; //Per andare e tornare dagli interni (che sono +1 e +2 dal loro livello di riferimento)
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private GameObject _brokenDoor;
    [SerializeField] private GameObject _doorToBreak;
    [SerializeField] public GameObject _myPrefab; //DustCloud

    private bool _isOpened = false; //Pilota la possibilità della porta di funzionare come un trigger

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hitHammer()
    {
        //Porta colpita dal martello
        Instantiate(_myPrefab, this.transform.position , Quaternion.identity);
        gameObject.SetActive(false);
        _brokenDoor.SetActive(true);//cambio del game object con la versione rotta
        _isOpened = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isOpened)
        {
            _levelLoader.LoadLevelFromThis(_chamberIndex);
        }
    }

}
