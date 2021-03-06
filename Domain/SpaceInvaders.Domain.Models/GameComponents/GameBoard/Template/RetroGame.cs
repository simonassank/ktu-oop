﻿using SpaceInvaders.Business.Contracts;
using SpaceInvaders.Domain.Models.GameComponents.Enemies.Collection.Base;
using SpaceInvaders.Domain.Models.GameComponents.Spaceship;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Domain.Models.GameComponents.GameBoard.Template
{
    public class RetroGame : DrawTemplateBase
    {
        public override string DrawSpaceship(SpaceShip spaceShip)
        {
            FileLogger.Log("Retro Template method pattern: drawing spaceship");

            var builder = new StringBuilder();

            var everySecond = false;
            for (var position = 0; position < Contracts.GameSizeWidth; position++)
            {
                var contains = spaceShip.Position.From.X < position && position <= spaceShip.Position.To.X;
                if (contains)
                {
                    if (everySecond)
                    {
                        builder.Append("\u25CA");
                    }

                    builder.Append("\u25CA");
                    everySecond = !everySecond;
                }
                else
                {
                    builder.Append(" ");
                }
                //builder.Append(contains ? "_" : " ");
            }
            return builder.ToString();
        }

        public override string DrawEnemiesAndBullets(IEnemyCollection enemies, IList<Bullet> spaceshipBullets)
        {
            FileLogger.Log("Retro Template method pattern: drawing enemies");

            var builder = new StringBuilder();

            var skip = false;
            for (var column = 0; column < Contracts.GameSizeHeight; column++)
            {
                if (skip)
                {
                    builder.AppendLine();
                    skip = false;
                }
                else
                {
                    for (var row = 0; row < Contracts.GameSizeWidth; row++)
                    {
                        var contains = enemies.Count(x => x.Position.From.X < row && row <= x.Position.To.X) != 0;

                        var containsBullet = spaceshipBullets
                            .Count(bullet => bullet.Position.X == row
                            && bullet.Position.Y == column) != 0;

                        if (contains)
                        {
                            builder.Append("\u2302");
                        }
                        else if (containsBullet)
                        {
                            builder.Append("|");
                        }
                        else
                        {
                            builder.Append(" ");
                        }
                    }
                    skip = true;
                }

                if (!skip)
                {
                    skip = enemies.Count(x => x.Position.From.Y < column && column <= x.Position.To.Y) == 0;
                }
            }
            return builder.ToString();
        }

        protected string DrawBullets(IList<Bullet> spaceshipBullets)
        {
            var builder = new StringBuilder();

            for (var column = 0; column < Contracts.GameSizeHeight; column++)
            {
                for (var row = 0; row < Contracts.GameSizeWidth; row++)
                {
                    var contains = spaceshipBullets.Count(x => x.Position.X == row && x.Position.Y == column) != 0;
                    builder.AppendLine(contains ? "|" : " ");
                }
            }

            return builder.ToString();
        }
    }
}