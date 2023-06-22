using UnityEngine;
public class Engine : MonoBehaviour
{
    public AudioSource audioSource;

  
    float NewNumPitch; //New Pitch

    float CurrentNumPitch; //Current Pitch

    float NewNum;
    float CurrentNum;



    // Start is called before the first frame update
    void Start()
    {
        Set();
        GameEvents.OnEngine?.Invoke(1);
    }

    private void OnEnable()
    {
        GameEvents.OnEngine += OnEngine;
    }
    private void OnDisable()
    {
        GameEvents.OnEngine -= OnEngine;
    }

    public void OnEngine(int Number)
    {
        if (Number == 1) //Slow to Fast (Volume and Pitch)
        {
           
            NewNumPitch = 1;
            Set();
        }
        else if (Number == 2)
        {
           
            NewNumPitch = 1.5f;
            Set();
        }
        else if (Number == 3)
        {
            
            NewNumPitch = 1.75f;
            Set();
        }
        else if (Number == 4)
        {

            NewNumPitch = 2f;
            Set();
        }

    }

    public void Set() //Everytime it updates it changes from the Current to the New pitch. It can go up or down. 
    {
        LeanTween.value(CurrentNumPitch, NewNumPitch, 0.5f).setOnUpdate(setPitch);

       
        CurrentNumPitch = NewNumPitch;
        NewNum = (CurrentNum - NewNum) * -1; //Even if it's negative.
    }


    public void setPitch(float NumPitch)
    {
        audioSource.pitch = NumPitch;
    }


}
