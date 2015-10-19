﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Game.GameEntities
{
    abstract class MovingObject : GameObject
    {
        #region Variables
        //Direction the tank is turned to
        protected Direction direction;    //Enumeration in GameObject C=class
        public Direction Direction
        {
            get
            {
                return direction;
            }

            set
            {
                direction = value;
            }
        }
        #endregion

        public MovingObject(int positionX, int positionY, Direction direction) : base(positionX, positionY)
        {
            this.direction = direction;
        }
    }
}