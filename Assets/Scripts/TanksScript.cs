﻿using UnityEngine;
using Assets.Game;
using Assets.Game.GameEntities;
using System;

public class TanksScript : MonoBehaviour
{
    Vector3 originPosition;
    float tPosition;

    Vector3 originRotation;
    float tRotation;

    float positionY;

    // Use this for initialization
    void Start()
    {
        positionY = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        int playerNumber = int.Parse(gameObject.name.Substring(4));
        if (playerNumber - 1 < GameManager.Instance.GameEngine.Tanks.Count)
        {
            Tank tank = GameManager.Instance.GameEngine.Tanks[playerNumber - 1];
            if (tank.Health > 0)
            {
                animateMove(tank.PositionX, tank.PositionY);
                animateRotation(tank.Direction);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    void animateMove(int destinationX, int destinationZ)
    {
        if (destinationX * 80 == transform.position.x &&
            destinationZ * 80 == transform.position.z)
        {
            originPosition = transform.position;
            tPosition = 0;
        }

        transform.position = Vector3.Lerp(originPosition, new Vector3(destinationX * 80, positionY, destinationZ * 80), tPosition);

        tPosition += 0.1f;
    }

    void animateRotation(Direction direction)
    {
        int angle = getAngle(direction);
        Vector3 rotationVector = transform.rotation.eulerAngles;

        if (angle == rotationVector.y)
        {
            originRotation = transform.rotation.eulerAngles;
            tRotation = 0;
        }

        transform.rotation = Quaternion.Euler(Vector3.Lerp(originRotation, new Vector3(originRotation.x, angle, originRotation.z), tRotation));

        tRotation += 0.1f;
    }

    int getAngle(Direction direction)
    {
        if (direction == Direction.NORTH)
        {
            return 90;
        }
        else if (direction == Direction.EAST)
        {
            return 0;
        }
        else if (direction == Direction.SOUTH)
        {
            return 270;
        }
        else
        {
            return 180;
        }
    }
}
