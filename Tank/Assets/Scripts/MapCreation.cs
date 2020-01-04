﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//(0,0,8,10)
public class MapCreation : MonoBehaviour
{
    //用来装饰 初始化地图所需物体数组
    // 0老家、1墙、2障碍、3出生效果 4河流 5草 6空气墙
    public GameObject[] item;
    //已经有东西的列表
    private List<Vector3> itemPositionList = new List<Vector3>();


    private void Awake()
    {
        InitMap();
    }

    private void InitMap()
    {
        //实例化老家
        CreateItem(item[0], new Vector3(0, -8, 0), Quaternion.identity);
        //用墙把老家围起来
        CreateItem(item[1], new Vector3(-1, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(1, -8, 0), Quaternion.identity);
        for (int i = -1; i < 2; i++)
        {
            CreateItem(item[1], new Vector3(i, -7, 0), Quaternion.identity);
        }

        //实例化外围墙
        for (int i = -11; i < 12; i++)
        {
            CreateItem(item[6], new Vector3(i, 9, 0), Quaternion.identity);
        }
        //bottom
        for (int i = -11; i < 12; i++)
        {
            CreateItem(item[6], new Vector3(i, -9, 0), Quaternion.identity);
        }
        //left
        for (int y = -8; y < 9; y++)
        {
            CreateItem(item[6], new Vector3(-11, y, 0), Quaternion.identity);
        }
        //right
        for (int y = -9; y < 9; y++)
        {
            CreateItem(item[6], new Vector3(11, y, 0), Quaternion.identity);
        }

        //初始化玩家 3出生效果
        GameObject go = Instantiate(item[3], new Vector3(-2, -8, 0), Quaternion.identity);
        go.GetComponent<Born>().createPlayer = true;

        //初始化敌人 3出生效果
        CreateItem(item[3], new Vector3(-10, 8, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(0, 8, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(10, 8, 0), Quaternion.identity);

        InvokeRepeating("CreatetEnemy", 4, 5);

        //实例化地图 1墙、2障碍、 4河流 5草
        for (int i = 0; i < 60; i++)
        {
            CreateItem(item[1], createRandomPositon(), Quaternion.identity);

        }
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[1], createRandomPositon(), Quaternion.identity);
            CreateItem(item[2], createRandomPositon(), Quaternion.identity);
            CreateItem(item[4], createRandomPositon(), Quaternion.identity);
            CreateItem(item[5], createRandomPositon(), Quaternion.identity);
        }
    }

    private void CreateItem(GameObject createGameObject, Vector3 createPosition,Quaternion rotation)
    {
        GameObject itemGo = Instantiate(createGameObject, createPosition, rotation);
        itemGo.transform.SetParent(gameObject.transform);
        itemPositionList.Add(createPosition);
    }

    //产生随机位置的方法
    private Vector3 createRandomPositon()
    {
        //不生成x =-10,10的两列， =-8 8正两行的位置
        while (true)
        {
            Vector3 createPosition = new Vector3(Random.Range(-9, 10), Random.Range(-7, 8),0);

            if (!HasThePosition(createPosition)){
                return createPosition;
            }

        }
    }

    //用来判断位置列表中是否有这个位置
    private bool HasThePosition(Vector3 createPos)
    {
        for (int i = 0; i < itemPositionList.Count; i++){
            if(createPos == itemPositionList[i])
            {
                return true;
            }
        }
        return false;
    }

    //产生敌人的方法
    private void CreatetEnemy()
    {
        int num = Random.Range(0, 3);
        Vector3 EnemyPos = new Vector3();
        if(num == 0)
        {
            EnemyPos = new Vector3(-10, 8, 0);
        }else if(num == 1)
        {
            EnemyPos = new Vector3(0, 8, 0);
        }
        else 
        {
            EnemyPos = new Vector3(10, 8, 0);
        }
        CreateItem(item[3], EnemyPos, Quaternion.identity);
    }
}
