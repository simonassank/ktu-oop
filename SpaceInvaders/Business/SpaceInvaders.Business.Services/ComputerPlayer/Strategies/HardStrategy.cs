﻿using SpaceInvaders.Business.Services.Interfaces;

namespace SpaceInvaders.Business.Services.ComputerPlayer.Strategies
{
    public class HardStrategy : IBoardStrategy
    {
        public Interfaces.Strategies Name => Interfaces.Strategies.HardStrategy;
        public int InitialSize => 10;
        public int EasyEnemyProbability => 0;
        public int MediumEnemyProbability => 30;
        public int HardEnemyProbability => 50;
    }
}