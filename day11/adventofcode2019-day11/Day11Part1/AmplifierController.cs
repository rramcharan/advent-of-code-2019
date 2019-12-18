using System;
using System.Collections.Generic;

namespace adventofcode2019_day11.Day11Part1
{
    public class AmplifierController
    {
        public long MaxThrusterSignal { get; private set; }
        public List<long> Output { get; private set; }

        public static AmplifierController RunSequenceOnAmplifiers(long[] input, long seq1, long seq2, long seq3, long seq4, long seq5)
        {
            var result = new AmplifierController();
            result.Run(input, seq1, seq2, seq3, seq4, seq5);
            return result;
        }

        public List<long[]> AllCombination(params long[] seq)
        {
            var test = new FormPermut();
            test.PrnPermut(seq, 0, seq.Length - 1);
            return test.Permutations;
        }

        private void Run(long[] code, long seq1, long seq2, long seq3, long seq4, long seq5)
        {
            long? maxThrusterSignal = null;
            var seqCombinations = new AmplifierController().AllCombination(seq1, seq2, seq3, seq4, seq5);

            foreach (var seq in seqCombinations)
            {
                var resultAmp1 = IntCodeComputer.ProcessWithUserInput(Clone(code), new long[] { seq[0], 0 });
                var resultAmp2 = IntCodeComputer.ProcessWithUserInput(Clone(code), SetInput(seq[1], resultAmp1.Output));
                var resultAmp3 = IntCodeComputer.ProcessWithUserInput(Clone(code), SetInput(seq[2], resultAmp2.Output));
                var resultAmp4 = IntCodeComputer.ProcessWithUserInput(Clone(code), SetInput(seq[3], resultAmp3.Output));
                var resultAmp5 = IntCodeComputer.ProcessWithUserInput(Clone(code), SetInput(seq[4], resultAmp4.Output));

                if (!(resultAmp1.IsHalted && resultAmp2.IsHalted && resultAmp3.IsHalted && resultAmp4.IsHalted && resultAmp5.IsHalted))
                {
                    throw new Exception("amp1 is halted, while at least one amp is not halted");
                }

                var output = resultAmp5.Output;
                if (output.Count != 1)
                    throw new Exception($"Unepected number of output. Expected 1, actual {output.Count}");
                if (maxThrusterSignal == null || maxThrusterSignal.Value < output[0])
                {
                    Output = output;
                    maxThrusterSignal = Output[0];
                }
            }
            if (!maxThrusterSignal.HasValue)
                throw new Exception("Did not find the maximum Thruster Signal");
            MaxThrusterSignal = maxThrusterSignal.Value;
        }


        private long[] SetInput(long seq, List<long> output)
        {
            var input = new List<long> { seq };
            if (output != null)
                input.AddRange(output);

            return input.ToArray();
        }

        private long[] Clone(long[] input)
        {
            return (long[])input.Clone();
        }
    }
    public class FormPermut
    {
        public List<long[]> Permutations { get; private set; }
        public FormPermut()
        {
            Permutations = new List<long[]>();
        }
        public void SwapTwoNumber(ref long a, ref long b)
        {
            long temp = a;
            a = b;
            b = temp;
        }
        public void PrnPermut(long[] list, long k, long m)
        {
            long i;
            if (k == m)
            {
                var aPerm = new long[list.Length];
                for (i = 0; i <= m; i++)
                {
                    aPerm[i] = list[i];
                    Console.Write("{0}", list[i]);
                }
                Permutations.Add(aPerm);
                Console.Write(" ");
            }
            else
                for (i = k; i <= m; i++)
                {
                    SwapTwoNumber(ref list[k], ref list[i]);
                    PrnPermut(list, k + 1, m);
                    SwapTwoNumber(ref list[k], ref list[i]);
                }
        }
    }
}
