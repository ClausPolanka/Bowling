using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Bowling.Test
{
    [TestFixture]
    public class Bowling_Acceptance_Tests_Level_1
    {
        [Test]
        public void Spec_example()
        {
            var input = "3:1,4,6,4,7,0";
            var scores = CalculateFrameScores(input);
            Assert.That(string.Join(",", scores), Is.EqualTo("5,22,29"), "frame scores");
        }

        private static List<int> CalculateFrameScores(string input)
        {
            var rounds = int.Parse(input[0].ToString());
            var rolls = input.Substring(2).Split(',').Select(int.Parse).ToList();

            var scores = new List<int>();
            var score = 0;
            for (var i = 0; i < rolls.Count; i += 2)
            {
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
