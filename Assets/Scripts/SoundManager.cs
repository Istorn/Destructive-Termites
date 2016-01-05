using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{

    /// <summary>
    /// Contains all the available sounds that can be played. 
    /// Remember to insert the audio clips at the correct locations!
    /// </summary>
    public AudioClip[] available_sounds_ = new AudioClip[ System.Enum.GetValues( typeof( ESoundTypes ) ).Length ];

    /// <summary>
    /// Lists all the different kinds of sounds we can have in game.
    /// When a new type of sound is added we should add the correct type in the correct position here and inside the corresponding array.
    /// </summary>
    public enum ESoundTypes
    {
        ButtonClick = 0,
        DownDialogue = 1,
        Error = 2,
        Intro = 3,
        NewEvent = 4,
        BackgroundChatter = 5,
        UpDialogue = 6,
        VersoInfinito = 7,
        RitmoDalParadiso = 8,
        GocceDiPioggia = 9,
        Riflessione = 10,
        OrmeSullaSabbia = 11,
        Alchimist = 12,
        Disco = 13,
        Gnoa = 14,
        GQuando = 15,
    };

    // Defines info about a BGM that can be played
    // This is used inside an array to keep track of the BGMs currently being played
    private struct BGMInfo
    {
        // Reference to the sound source used for this BGM
        public AudioSource audio_source;
        // Sound type of the Audio Source
        public ESoundTypes sound_type;

        public BGMInfo( AudioSource _audio_source , ESoundTypes _sound_type )
        {
            this.audio_source = _audio_source;
            this.sound_type = _sound_type;
        }
    }

    // Array used to keep track of all the BGMs currently being played
    // When a new BGM is requested a check on the ESoundTypes inside each struct is made to find out if the BGM is already playing
    // In the same way we can also stop BGMs from playing or alter their properties (volume etc.)
    // Each BGM MUST be UNIQUE inside this array
    private List<BGMInfo> active_BGMs_;

    void Awake()
    {
        active_BGMs_ = new List<BGMInfo>();
    }

    /// <summary>
    /// Plays the specified sound at a certain volume.
    /// Used for sounds that have to be played only once.
    /// </summary>
    /// <param name="_sound">The type of sound to play.</param>
    /// <param name="_volume">The volume to play the sound at.</param>
    public void PlayOneShotSound( ESoundTypes _sound , float _volume )
    {
        // Since we are playing this sound only once we don't need to create any reference to a sound object
        // because we won't need to change any properties of the audio source
        AudioSource.PlayClipAtPoint( available_sounds_[ (int) _sound ] , Vector3.zero , _volume );
    }

    /// <summary>
    /// Finds the specified BGM index.
    /// </summary>
    /// <param name="_BGMs">List of BGMs to search.</param>
    /// <param name="_BGM_type">BGM type to search for.</param>
    /// <param name="_index">Return index for the position of the BGM.</param>
    /// <returns>Returns true if the BGM index is found. At that point the _index out value represents the index of the BGM in the array.</returns>
    private bool FindBGMIndex( List<BGMInfo> _BGMs , ESoundTypes _BGM_type , out int _index )
    {
        _index = -1; // Set to a non valid index in case the search yields negative result

        // Searches inside each BGM of the given array for the specified BGM Type
        for ( int cy_index = 0 ; cy_index < _BGMs.Count ; cy_index++ )
        {
            // Found the correspondence
            if ( _BGMs[ cy_index ].sound_type == _BGM_type )
            {
                // Set return index and return positive search result
                _index = cy_index;
                return true;
            }
        }

        // The search has failed to find the specified BGM
        return false;
    }

    /// <summary>
    /// Starts the specified BGM sound at the selected volume.
    /// This sound will loop until stopped.
    /// </summary>
    /// <param name="_sound">BGM to use.</param>
    public void StartBGM( ESoundTypes _sound , float _volume )
    {
        int temp_index;
        // Create a new BGM only if no other BGM of the same type is currently playing
        if ( !FindBGMIndex( this.active_BGMs_ , _sound , out temp_index ) )
        {
            GameObject temp_game_object = new GameObject();
            temp_game_object.name = System.Enum.GetName( typeof( ESoundTypes ) , _sound ) + "AudioSource";
            AudioSource temp_audio = temp_game_object.AddComponent<AudioSource>();
            temp_audio.clip = available_sounds_[ (int) _sound ];
            temp_audio.loop = true;
            temp_audio.volume = _volume;
            temp_audio.Play();

            this.active_BGMs_.Add( new BGMInfo( temp_audio , _sound ) );
        }
    }

    /// <summary>
    /// Smoothly changes the volume of the specified type of BGM.
    /// </summary>
    /// <param name="_BGM_sound">The BGM's volume to change.</param>
    /// <param name="_new_volume">New volume.</param>
    /// <param name="_smoothing_time">Seconds over which to smooth the volume change.</param>
    public void ChangeBGMVolume( ESoundTypes _BGM_sound , float _new_volume , float _smoothing_time )
    {
        StartCoroutine( ChangeBGMVolumeRoutine( _BGM_sound , _new_volume , _smoothing_time ) );
    }

    // Routine used by ChangeBGMVolume to actually smoothly change the volume                    
    private IEnumerator ChangeBGMVolumeRoutine( ESoundTypes _BGM_sound , float _new_volume , float _smoothing_time )
    {
        int loc_index;

        // Can only change volume of currently playing BGMs.
        if ( FindBGMIndex( this.active_BGMs_ , _BGM_sound , out loc_index ) )
        {
            AudioSource loc_audio = this.active_BGMs_[ loc_index ].audio_source;
            float loc_previous_volume = loc_audio.volume;
            float loc_starting_time = Time.time;

            // Smooth the volume change over time
            while ( ( Time.time - loc_starting_time ) < _smoothing_time )
            {
                loc_audio.volume = Mathf.Lerp( loc_previous_volume , _new_volume , ( Time.time - loc_starting_time ) / _smoothing_time );
                yield return null;
            }

            loc_audio.volume = _new_volume; // Last update sets the volume to the actual new volume
        }
    }

    /// <summary>
    /// Fades between the "in" and "out" tracks in the given time.
    /// </summary>
    /// <param name="_in">The track to start playing and fade in.</param>
    /// <param name="_out">The track to fade out and stop playing.</param>
    /// <param name="_fading_time">The time it takes to completely fade from one track to the other.</param>
    /// <param name="_in_volume">Final volume of the track faded in.</param>
    public void BGMFadeBetweenTracks( SoundManager.ESoundTypes _in , SoundManager.ESoundTypes _out , float _fading_time , float _in_volume )
    {
        StartCoroutine( BGMFadeImplementation( _in , _out , _fading_time , _in_volume ) );
    }

    /// Actual implementation of <see cref="BGMFadeBetweenTracks(ESoundTypes, ESoundTypes)"/>.
    /// This is done so that users of the SoundManager won't have to call the function as a coroutine.
    private IEnumerator BGMFadeImplementation( SoundManager.ESoundTypes _in , SoundManager.ESoundTypes _out , float _fading_time , float _in_volume )
    {
        StartBGM( _in , 0 );
        ChangeBGMVolume( _in , _in_volume , _fading_time );
        ChangeBGMVolume( _out , 0 , _fading_time );
        yield return new WaitForSeconds( _fading_time ); // Wait for the fading time before actually stopping the out BGM
        StopBGM( _out );
    }

    /// <summary>
    /// Stops the selected BGM from playing.
    /// </summary>
    /// <param name="_sound">The type of BGM to stop.</param>
    public void StopBGM( ESoundTypes _sound )
    {
        int loc_index;
        // If we find this type of BGM within the active ones we can stop and destroy it
        if ( FindBGMIndex( this.active_BGMs_ , _sound , out loc_index ) )
        {
            active_BGMs_[ loc_index ].audio_source.Stop();
            Destroy( active_BGMs_[ loc_index ].audio_source.gameObject ); // Destroys the gameobject the AudioSource is attached to
            active_BGMs_.RemoveAt( loc_index );
        }
    }
}