using Sahab_Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sahab_Desktop.Utils
{
    public class TaskPriorityEffectCalculator
    {
        public static Dictionary<TaskPriority, int> PeriotitiesScore = new Dictionary<TaskPriority, int>
        {
            {TaskPriority.CompulsiveCompulsive, 5},
            {TaskPriority.CompulsiveNormal, 3},
            {TaskPriority.CompulsiveDaily, 4},
            {TaskPriority.NormalCompulsive, 3},
            {TaskPriority.NormalNormal, 1},
            {TaskPriority.NormalDaily, 2},
            {TaskPriority.VariableCompulsive, 3},
            {TaskPriority.VariableNormal, 1},
            {TaskPriority.VariableDaily, 2},
        };

        public static ulong CalculatePeriorityScore(List<Doctrine> doctrines, List<Frame> frames, TaskPriority priority)
        {
            ulong score = (ulong)doctrines.Sum(d => d.Score);
            score += (ulong)frames.Sum(f => f.Score);
            score *= (ulong)(PeriotitiesScore.TryGetValue(priority, out var priorityScore) ? priorityScore : 0);
            return score;
        }
    }
}
