﻿using SpaceInvaders.Domain.Models.GameComponents.EnemiesVisitor;

namespace SpaceInvaders.Domain.Models.GameComponents.Enemies
{
    public class HardEnemy : Enemy
    {
        public HardEnemy()
        {
            Health = 3;
        }

        public override Enemy Clone()
        {
            return this.MemberwiseClone() as Enemy;
        }

        public override void Accept(EnemyVisitorBase visitor)
        {
            visitor.AddScore(this);
        }
    }
}