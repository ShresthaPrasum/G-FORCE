using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu: MonoBehaviour
{
    public void Game()
    {
        SceneManager.LoadScene("Levels");
    }

    public void Level()
    {
        
        SceneManager.LoadScene("Levels");
        
    }
    public void Level1()
    {
        
        SceneManager.LoadScene("Level1");
    }
    public void Level2()
    {
        
        SceneManager.LoadScene("Level2");
    }
    public void Level3()
    {
        
        SceneManager.LoadScene("Level3");
    }
    
    public void Level4()
    {
        
        SceneManager.LoadScene("Level4");
    }
    
    public void Home()
    {

        SceneManager.LoadScene("Home");
    }
    public void Guide()
    {

        SceneManager.LoadScene("Guide");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}