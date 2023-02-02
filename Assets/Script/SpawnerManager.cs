using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] float _timeBetweenSpawnEnemie;
    float resetTimeSpawnEnemie;
    float timeSpawnEnemie;
    [SerializeField] float _timeBetweenSpawnPowerUp;
    float resetTimeSpawnPowerUp;
    [SerializeField] GameObject[] _enemy;
    [SerializeField] GameObject _PowerUp;
    float _cameraWidth;
    float _cameraHeight;
    Camera _camera;
    [SerializeField] AnimationCurve _difficultyCurve;
    [SerializeField] float _timeForMaxDifficulty;
    
    // Start is called before the first frame update
    void Start()
    {
        resetTimeSpawnEnemie = _timeBetweenSpawnEnemie;
        resetTimeSpawnPowerUp = _timeBetweenSpawnPowerUp;
        // Obtenir les limites de la caméra
        _camera = Camera.main;
        _cameraWidth = _camera.orthographicSize * Camera.main.aspect;
        _cameraHeight = _camera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemie();
        SpawnPowerUp();
    }
    void SpawnEnemie()
    {
        timeSpawnEnemie += Time.deltaTime;
        _timeBetweenSpawnEnemie -= Time.deltaTime;
        if (_timeBetweenSpawnEnemie <= 0)
        {
            Vector3 RandomPos = RandomPosInCameraView();
            int randomEnemy = Random.Range(0, _enemy.Length);
            Instantiate(_enemy[randomEnemy], RandomPos, Quaternion.identity);
            _timeBetweenSpawnEnemie = _difficultyCurve.Evaluate(timeSpawnEnemie / _timeForMaxDifficulty) * resetTimeSpawnEnemie;
        }
    }
    void SpawnPowerUp()
    {
        _timeBetweenSpawnPowerUp -= Time.deltaTime;
        if (_timeBetweenSpawnPowerUp <= 0)
        {
            Vector3 RandomPos = RandomPosInCameraView();
            Instantiate(_PowerUp, RandomPos, Quaternion.identity);
            _timeBetweenSpawnPowerUp =  resetTimeSpawnPowerUp;
        }
    }
    Vector3 RandomPosInCameraView()
    {
        // Générer des positions aléatoires dans les limites de la caméra
        float x = Random.Range(-_cameraWidth, _cameraWidth);
        float y = Random.Range(-_cameraHeight, _cameraHeight);

        // Définir la position de l'objet
        return new Vector3(x+ _camera.transform.position.x, y+ _camera.transform.position.y, 0) ;
    }
}
