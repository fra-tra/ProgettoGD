using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagGlow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject _tagObjectA; //Hammer
    [SerializeField] Material _glowMaterial; //Material for glowing tag
    [SerializeField] int _numlevel;
    [SerializeField] int _numObj;
    [SerializeField] GameObject _post;

    [SerializeField] public LevelLoader _levelLoader;

    public int _currentLevel;
    public int _firstObject;
    public int _secondObject;
    private Counter _myCounter;
    private bool done = false;


    void Start()
    {
         _myCounter = (Counter)FindObjectOfType(typeof(Counter));
    }

    // Update is called once per frame
    void Update()
    {
        if(done == false)
            glowTag();
    }


    public void glowTag()
    {
        //_currentLevel = _levelLoader.CurrentLevel();
        _firstObject = _myCounter.GetFirstObject();
        _secondObject = _myCounter.GetSecondObject();

        
        //if( _currentLevel == 4) //Poesia Epica
        //{
            if(_firstObject == _numObj || _secondObject == _numObj ) //martello
            {
                Glow();
                done = true;
            }
        /*}
        else if ( _currentLevel == 8)
        {
            Glow();
            done = true;
        }*/
    }

    public void Glow()
    {
        _tagObjectA.GetComponent<MeshRenderer> ().material = _glowMaterial;
        _post.SetActive(true);
    }
}
