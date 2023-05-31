using UnityEngine;
public class HeartbeatManager : MonoBehaviour
{
    public AudioSource audioSource;

    float NewNumVolume; //New Volume
    float NewNumPitch; //New Pitch

    float CurrentNumPitch; //Current Pitch
    float CurrentNumVolume; //Current Volume

    float NewNum;
    float CurrentNum;



    // Start is called before the first frame update
    void Start()
    {
        Set();
    }

    private void OnEnable()
    {
        GameEvents.OnHeartbeat += OnHeartbeat;
    }
    private void OnDisable()
    {
        GameEvents.OnHeartbeat -= OnHeartbeat;
    }

    public void OnHeartbeat(int Number)
    { 
        if(Number == 0) //Slow to Fast (Volume and Pitch)
        {
            NewNumVolume = 0;
            NewNumPitch = 0;
            Set();
        }
        else if (Number == 1)
        {
            NewNumVolume = 0.2f;
            NewNumPitch = 1;
            Set();
        }
        else if(Number == 2)
        {
            NewNumVolume = 0.4f;
            NewNumPitch = 1.1f;
            Set();
        }
        else if(Number == 3)
        {
            NewNumVolume = 0.6f;
            NewNumPitch = 1.3f;
            Set();
        }
        else if(Number == 4)
        {
            NewNumVolume = 0.7f;
            NewNumPitch = 1.5f;
            Set();
        }
        else if(Number == 5)
        {
            NewNumVolume = 0.8f;
            NewNumPitch = 1.8f;

            Set();
        }
    }

    public void Set() //Everytime it updates it changes from the Current to the New pitch. It can go up or down. 
    {
        LeanTween.value(CurrentNumVolume, NewNumVolume, 2).setOnUpdate(setVolume);
        LeanTween.value(CurrentNumPitch, NewNumPitch, 2).setOnUpdate(setPitch);

        CurrentNumVolume = NewNumVolume;
        CurrentNumPitch = NewNumPitch;
        NewNum = (CurrentNum - NewNum) * -1; //Even if it's negative.
    }

    public void setVolume(float NumVolume) //(it updated every frame)
    {
        audioSource.volume = NumVolume;
       
    }
    public void setPitch(float NumPitch)
    {
        audioSource.pitch = NumPitch;
    }
    

}
