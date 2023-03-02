/** This is a script that allows us to keep track of variables in our game that will be used by multiple objects. 
 * Currently it keeps track of manifesto's collected, gun ownership of Ivan and if the game is paused
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableCount : MonoBehaviour
{
    private int manifestoCount;
    private bool hasGun;
    private bool isPaused;


    void Start()
    {
        manifestoCount = 0;
        hasGun = false;
        isPaused = false;
    }
    public void addManifesto()
    {
        manifestoCount++;
    }
    public void removeManifesto()
    {
        manifestoCount--;
    }
    public int returnManifestoCount()
    {
        return manifestoCount;
    }
    public void setPause(bool paused)
    {

        isPaused = paused;
        
    }    
    public bool returnPause()
    {
        return isPaused;
    }
    
    public void gotGun()
    {
        hasGun = true;
    }
    public bool returnGun()
    {
        return hasGun;

        
    }
}
