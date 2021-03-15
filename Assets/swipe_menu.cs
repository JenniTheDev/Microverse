using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
Inspired by: https://www.youtube.com/watch?v=GURPmGoAOoM
*/

public class swipe_menu : MonoBehaviour
{
    public GameObject scrollbar;
    float scroll_pos = 0;
    float[]pos;
    //Loads next scene when game is clicked
    public void PlayGame ()
    {
      //loads next level in queue -- get index of current loaded level
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    // Update is called once per frame
    //for transitions of buttons when user is scrolling
    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for(int i = 0; i < pos.Length; i++) {
          pos[i] = distance * i;
        }
        // Jenni changed this from on mouse button
        if(UnityEngine.Input.anyKeyDown) {
          scroll_pos = scrollbar.GetComponent<Scrollbar> ().value;
        } else {
          for(int i = 0; i < pos.Length; i++) {
            if(scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2)) {
              scrollbar.GetComponent <Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
            }
          }
        }
        //show trannsformations when sliding through each button
        for(int i = 0; i < pos.Length; i++) {
          if(scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2)) {
            transform.GetChild(i).localScale = Vector2.Lerp (transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
            for(int a = 0; a < pos.Length; a++) {
              if(a != i) {
                transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.8f, 0.8f), 0.1f);
              }
            }
          }
        }
    }
}
