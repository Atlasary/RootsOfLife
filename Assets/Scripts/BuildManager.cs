using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    private RootBluePrint rootToBuild;
    public YggdrasilBlueprint yggdrasil;
    public RootBluePrint root;

    internal void BuildRootFromAToB(RootBluePrint rootPrefab, Vector3 origin, Vector3 destination)
    {
        float x = destination.x - origin.x;
        float z = destination.z - origin.z;

        Vector3 offset = new Vector3(x, 0, z);
        Debug.Log("destination : " + destination);
        Debug.Log("origin : " + origin);
        Debug.Log("offset : " + offset);

        Vector3 position = offset / 2.0f;
        position.x += origin.x;
        position.z += origin.z;

        Debug.Log("position : " + position);

        // Génère une taille en fonction de clique de la souris et l'origine
        float dist = Vector3.Distance(destination, origin) / 2f;

        Vector3 scale = new Vector3(10f, dist, 10f);
        rootPrefab.prefab.transform.localScale = scale;

        // Crée un angle à partir d'un offset
        float angle = Vector3.Angle(offset, transform.forward);

        // Corrige l'angle si jamais destination.x < origin.x car Vector3.Angle(from, to) ne retourne qu'un angle sur 180°, il faut donc l'inverser quand on est dans les négatifs
        if (destination.x < origin.x) angle = -angle;

        // Fait un angle de 90 degés pour que a racine soit bien orientée
        Quaternion spawnRotation = Quaternion.Euler(90, angle, 0);

        // Instancie une racine
        GameObject root = Instantiate(rootPrefab.prefab, position, spawnRotation);
        
    }

}
