using System;
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
        [TestCase("3:1,5,5,5,4,6,8", "6,20,38")]
        public void Level_2(string input, string expected)
        {
            var scores = CalculateFrameScores(input);
            Assert.That(string.Join(",", scores), Is.EqualTo(expected), "frame scores");
        }

        [TestCase("3:1,4,10,2,5", "5,22,29")]
        [TestCase("1:10,1,3", "14")]
        public void Level_3_Spec_examples(string input, string expected)
        {
            var scores = CalculateFrameScores(input);
            Assert.That(string.Join(",", scores), Is.EqualTo(expected), "frame scores");
        }

        [TestCase("3:3,4,10,1,2", "7,20,23")]
        [TestCase("2:3,4,10,1,2", "7,20")]
        public void Level_3(string input, string expected)
        {
            var scores = CalculateFrameScores(input);
            Assert.That(string.Join(",", scores), Is.EqualTo(expected), "frame scores");
        }

        [TestCase("4:1,4,10,10,3,6", "5,28,47,56")]
        [TestCase("3:10,10,10,3,6", "30,53,72")]
        public void Level_4_Spec_examples(string input, string expected)
        {
            var scores = CalculateFrameScores(input);
            Assert.That(string.Join(",", scores), Is.EqualTo(expected), "frame scores");
        }

        [TestCase("4:1,5,10,10,1,7", "6,27,45,53")]
        [TestCase("3:1,5,10,10,1,7", "6,27,45")]
        public void Level_4(string input, string expected)
        {
            var scores = CalculateFrameScores(input);
            Assert.That(string.Join(",", scores), Is.EqualTo(expected), "frame scores");
        }

        [TestCase("3:1,4,10,7,3,8", "5,25,43")]
        [TestCase("2:7,3,10,1,4", "20,35")]
        public void Level_5_Spec_examples(string input, string expected)
        {
            var scores = CalculateFrameScores(input);
            Assert.That(string.Join(",", scores), Is.EqualTo(expected), "frame scores");
        }

        [TestCase("4:2,7,10,4,6,4,5", "9,29,43,52")]
        [TestCase("4:2,7,4,6,10,4,5", "9,29,48,57")]
        [TestCase("3:2,7,4,6,10,4,5", "9,29,48")]
        public void Level_5(string input, string expected)
        {
            var scores = CalculateFrameScores(input);
            Assert.That(string.Join(",", scores), Is.EqualTo(expected), "frame scores");
        }

        [TestCase("10:1,4,4,5,6,4,5,5,10,0,1,7,3,6,4,10,2,8,6", "5,14,29,49,60,61,77,97,117,133")]
        public void Level_6_Spec_examples(string input, string expected)
        {
            var scores = CalculateFrameScores(input);
            Assert.That(string.Join(",", scores), Is.EqualTo(expected), "frame scores");
        }

        [TestCase("10:1,4,4,5,6,4,5,5,10,0,1,7,3,6,4,10,2,8,6", "5,14,29,49,60,61,77,97,117,133")]
        [TestCase("10:0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0", "0,0,0,0,0,0,0,0,0,0")]
        [TestCase("10:10,10,10,10,10,10,10,10,10,10,10,10", "30,60,90,120,150,180,210,240,270,300")]
        [TestCase("10:7,2,1,9,6,4,5,5,10,3,7,7,3,6,4,10,2,8,6", "9,25,40,60,80,97,113,133,153,169")]
        public void Level_6(string input, string expected)
        {
            var scores = CalculateFrameScores(input);
            Assert.That(string.Join(",", scores), Is.EqualTo(expected), "frame scores");
        }

        private static List<int> CalculateFrameScores(string input)
        {
            var rounds = int.Parse(input.Split(':')[0]);
            var rolls = input.Split(':')[1].Split(',').Select(int.Parse).ToList();

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
                {
                    frameScore += rolls[i] + rolls[i + 1] + rolls[i + 2];
                    i--;
                }
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
