﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Bowling.Test
{
    [TestFixture]
    public class Bowling_Acceptance_Tests
    {
        [TestCase("3:1,4,6,4,7,0", "5,22,29")]
        [TestCase("3:0,0,9,1,0,0", "0,10,10")]
        public void Spec_example(string input, string expected)
        {
            var scores = CalculateFrameScores(input);
            Assert.That(string.Join(",", scores), Is.EqualTo(expected), "frame scores");
        }

        [TestCase("3:1,2,6,4,5,2", "3,18,25")]
        [TestCase("2:1,2,6,4,5", "3,18")]
        [TestCase("1:2,8,5", "15")]
        [TestCase("3:0,0,9,1,0,0", "0,10,10")]
        public void Level_1(string input, string expected)
        {
            var scores = CalculateFrameScores(input);
            Assert.That(string.Join(",", scores), Is.EqualTo(expected), "frame scores");
        }

        [TestCase("4:1,4,6,4,7,3,2,5", "5,22,34,41")]
        [TestCase("2:7,3,3,7,1", "13,24")]
        public void Level_2_Spec_examples(string input, string expected)
        {
            var scores = CalculateFrameScores(input);
            Assert.That(string.Join(",", scores), Is.EqualTo(expected), "frame scores");
        }

        [TestCase("4:1,5,5,5,4,6,8,1", "6,20,38,47")]
        public void Level_2(string input, string expected)
        {
            var scores = CalculateFrameScores(input);
            Assert.That(string.Join(",", scores), Is.EqualTo(expected), "frame scores");
        }

        private static List<int> CalculateFrameScores(string input)
        {
            var rounds = int.Parse(input[0].ToString());
            var rolls = input.Substring(2).Split(',').Select(int.Parse).ToList();

            var scores = new List<int>();
            var score = 0;
            for (var i = 0; i < rolls.Count; i += 2)
            {
                if (scores.Count == rounds)
                {
                    break;
                }
                var frameScore = 0;
                if (rolls[i] == 10)
                    frameScore += rolls[i] + rolls[i + 1] + rolls[i + 2];
                else
                {
                    frameScore = rolls[i] + rolls[i + 1];
                    if (frameScore == 10)
                        frameScore += rolls[i + 2];
                }
                score += frameScore;
                scores.Add(score);
            }
            return scores;
        }
    }
}