using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class Savedata
{
    //Members:
    private int _highScore;
    private double _highMove;
    //private int[] _allTimeItems = new int[3] { 0, 0, 0 };
    //private int[] _highItems = new int[3] { 0, 0, 0 };
    private double _allTimeMove;
    /*private List<int> _allTimeItems = new List<int>();private List<int> _highItems = new List<int>();*/
    /*public int _playTimes;*/

    //Settings:
    private int _musicIsOn = 0;
    private int _fxIsOn = 0;
    private int _isHighScore = 0;
    private int _isCreated = 0;

    //Methods:
    public bool IsHighScore()
    {
        switch(_isHighScore)
        {
            case 0: return false;
            case 1: return true;
            default: Debug.Log("Variable \'_isHighScore\' has been changed unexpectedly.");
                return false;
        }
    }

    private void InitialSavedataObject()
    {
        _highScore = 0;
        _highMove = 0;
        _allTimeMove = 0;
        return;
    }

    private Savedata CreateNewSaveData()
    {
        bool failureFlag = false;

        //I. Building Savedata object.
        //Load local file if it exists.
        string _path = Application.persistentDataPath + "/savedata.rua";
        if (File.Exists(_path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream _file = File.Open(_path, FileMode.Open);// No handle for open failure.
            if(_file == null)
            {
                Debug.Log("Open files failed. The file has been removed at runtime.");
                // failureFlag = true;// Maybe can let control stream jump to create brunch.
                InitialSavedataObject();
            }
            else
            {
                Savedata _tmpSav = (Savedata)bf.Deserialize(_file);// No handle for deserialize failure.
                if (_tmpSav == null) _tmpSav.InitialSavedataObject();
                _file.Close();
                _highScore = _tmpSav._highScore;
                _highMove = _tmpSav._highMove;
                _allTimeMove = _tmpSav._allTimeMove;

                //_highItems = _tmpSav._highItems;// Uncertain
                //_allTimeItems = _tmpSav._allTimeItems;
            }
        }
        //If not, create a new file
        else
        {
            InitialSavedataObject();
        }

        //II. Update some values of savedata object.
        GameObject _gcon = GameObject.FindWithTag("GameController");
        GameObject _player = GameObject.FindWithTag("Player");
        Score[] _score = _gcon.GetComponents<Score>();
        for (int i = 0; i < _score.Length; ++i)//To find the highscore, but not exactly.
        {
            if (_score[i].getScore() > _highScore)
            {
                _isHighScore = 1;
                _highScore = _score[i].getScore();
                _highMove = _player.transform.position.x;
                Debug.Log("New record!");
            }
        }
        _allTimeMove += _player.transform.position.x;

        if (failureFlag) Debug.Log("Savedata object creation is failed.");
        else Debug.Log("Savedata creation is completed successfully.");

        _isCreated = 1;
        return this;
    }

    private bool WriteSaveData()
    {
        if(_isCreated == 0)
        {
            Debug.Log("Savedata object is not initialized, writing process has been stopped.");
            return false;
        }
        else if(_isCreated == 1)
        {
            string _path = Application.persistentDataPath + "/savedata.rua";
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(_path);
            bf.Serialize(file, this);// No exception handler.
            file.Close();
            Debug.Log("Savedata has been updated.");
            return true;
        }
        else
        {
            Debug.Log("Variable \'_isCreated\' is changed unexpectedly, writing process has been stopped.");
            return false;
        }
    }

    public static Savedata SaveProcess()
    {
        //I. Create a new savedata object.
        Savedata sav = new Savedata();

        //II. Initialize this object by loading local file.
        sav.InitialSavedataObject();
        sav.CreateNewSaveData();

        //III. Write object to local file.
        sav.WriteSaveData();

        //IV. Return.
        return sav;//Maybe have some lifetime problem.
    }

    private Savedata LoadAndBuild()
    {
        bool failureFlag = false;

        //Load local file if it exists.
        string _path = Application.persistentDataPath + "/savedata.rua";
        if (File.Exists(_path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream _file = File.Open(_path, FileMode.Open);// No handle for open failure.
            if (_file == null)
            {
                Debug.Log("Open files failed. The file has been removed at runtime.");
                // failureFlag = true;// Maybe can let control stream jump to create brunch.
                InitialSavedataObject();
            }
            else
            {
                Savedata _tmpSav = (Savedata)bf.Deserialize(_file);// No handle for deserialize failure.
                if (_tmpSav == null) _tmpSav.InitialSavedataObject();
                _file.Close();
                _highScore = _tmpSav._highScore;
                _highMove = _tmpSav._highMove;
                _allTimeMove = _tmpSav._allTimeMove;
            }
        }
        //If not, create a new file
        else
        {
            InitialSavedataObject();
        }

        return this;
    }

    public static int GetHighScore()
    {
        //I. Building Savedata object.
        Savedata _tmpSav = new Savedata();
        _tmpSav.LoadAndBuild();

        //II. Return needed value.
        return _tmpSav._highScore;
    }

    public static double GetHighMove()
    {
        //I. Building Savedata object.
        Savedata _tmpSav = new Savedata();
        _tmpSav.LoadAndBuild();

        //II. Update some values of savedata object.
        return _tmpSav._highMove;
    }

    public static double GetAllTimesMove()
    {
        //I. Building Savedata object.
        Savedata _tmpSav = new Savedata();
        _tmpSav.LoadAndBuild();

        //II. Update some values of savedata object.
        return _tmpSav._allTimeMove;
    }
}

//e.g.   Savedata.SaveProcess().IsHighScore();
//       Savedata.GetHighScore();