using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2018.Runner
{
    public class Day7Solution
    {
        public Dictionary<string, List<string>> Parse(IEnumerable<string> inputs)
        {
            var dict = new Dictionary<string, List<string>>();
            
            foreach (var input in inputs)
            {
                var parts = input.Split(new string[] {"Step ", " must be finished before step ", " can begin."}, StringSplitOptions.RemoveEmptyEntries);
                var step = parts[1];
                var requirement = parts[0];
                
                if (!dict.ContainsKey(step))
                {
                    dict.Add(step, new List<string>());
                }
                if (!dict.ContainsKey(requirement))
                {
                    dict.Add(requirement, new List<string>());
                }
                
                dict[step].Add(requirement);
            }

            return dict;
        }

        public string SolvePart1(Dictionary<string,List<string>> steps)
        {
            var sb = new StringBuilder();
            while (steps.Count > 0)
            {
                var stepWithNoRequirement = steps.Where(kv => kv.Value.Count == 0).Select(kv => kv.Key).OrderBy(s => s).First();
                sb.Append(stepWithNoRequirement);
                steps.Remove(stepWithNoRequirement);

                foreach (var step in steps)
                {
                    step.Value.Remove(stepWithNoRequirement);
                }
            }
            return sb.ToString();
        }

        public string SolvePart1(IEnumerable<string> inputs)
        {
            return SolvePart1(Parse(inputs));
        }

        public int SolvePart2(int workerCount, int timePadding, Dictionary<string,List<string>> steps)
        {
            int time = 0;
            List<Worker> workers = new List<Worker>();
            for (int i = 0; i < workerCount; i++)
            {
                workers.Add(new Worker());
            }

            while (workers.Any(w => w.Step != null) || steps.Count > 0)
            {
                var availableSteps = steps.Where(kv => kv.Value.Count == 0).Select(kv => kv.Key).OrderBy(s => s).ToList();
                foreach (var worker in workers)
                {
                    if (!worker.Working && availableSteps.Count > 0)
                    {
                        var step = availableSteps[0];
                        availableSteps.RemoveAt(0);
                        steps.Remove(step);
                        worker.Step = step;
                        worker.TimeRemaining = timePadding + (step[0] - 64);
                    }

                    if (worker.Working)
                    {
                        worker.TimeRemaining--;
                        if (worker.TimeRemaining == 0)
                        {
                            foreach (var step in steps)
                            {
                                step.Value.Remove(worker.Step);
                            }
                            worker.Step = null;
                        }
                    }
                }

                time++;
            }
            return time;
        }

        public int SolvePart2(IEnumerable<string> inputs)
        {
            return SolvePart2(5, 60, Parse(inputs));
        }

        public class Worker
        {
            public string Step { get; set; }
            public int TimeRemaining { get; set; }
            public bool Working => Step != null;
        }
    }
}