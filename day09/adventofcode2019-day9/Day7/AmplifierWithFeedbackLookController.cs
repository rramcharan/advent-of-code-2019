using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019_day9.Day7
{
    public class AmplifierWithFeedbackLookController
    {
        public int MaxThrusterSignal { get; private set; }
        public List<int> Output { get; private set; }

        public static AmplifierWithFeedbackLookController RunSequenceOnAmplifiers(int[] input, int seq1, int seq2, int seq3, int seq4, int seq5)
        {
            var result = new AmplifierWithFeedbackLookController();
            result.Run(input, seq1, seq2, seq3, seq4, seq5);
            return result;
        }

        public List<int[]> AllCombination(params int[] seq)
        {
            var test = new FormPermut();
            test.PrnPermut(seq, 0, seq.Length - 1);
            return test.Permutations;
        }

        private void Run(int[] code, int seq1, int seq2, int seq3, int seq4, int seq5)
        {
            int? maxThrusterSignal = null;
            int? lastOutput = null;
            var seqCombinations = new AmplifierWithFeedbackLookController().AllCombination(seq1, seq2, seq3, seq4, seq5);

            foreach (var seq in seqCombinations)
            {
                var amp1 = IntCodeComputer.Create("Amp1", Clone(code), SetInput(seq[0], new List<int> { 0 })); ;
                var amp2 = IntCodeComputer.Create("Amp2", Clone(code), SetInput(seq[1]));
                var amp3 = IntCodeComputer.Create("Amp3", Clone(code), SetInput(seq[2]));
                var amp4 = IntCodeComputer.Create("Amp4", Clone(code), SetInput(seq[3]));
                var amp5 = IntCodeComputer.Create("Amp5", Clone(code), SetInput(seq[4]));
                while (true)
                {
                    amp1.Process();
                    amp2.AddInput(amp1.Output.First());

                    amp2.Process();
                    amp3.AddInput(amp2.Output.First());

                    amp3.Process();
                    amp4.AddInput(amp3.Output.First());

                    amp4.Process();
                    amp5.AddInput(amp4.Output.First());

                    amp5.Process();

                    if (amp1.IsHalted)
                    {
                        lastOutput = amp5.Output.First();
                        if (amp2.IsHalted && amp3.IsHalted && amp4.IsHalted && amp5.IsHalted)
                        {
                            break;
                        }
                        else
                            throw new Exception("amp1 is halted, while at least one amp is not halted");
                    }
                    else
                    {
                        if (amp2.IsHalted || amp3.IsHalted || amp4.IsHalted || amp5.IsHalted)
                        {
                            throw new Exception("amp1 is not halted, while at least one amp IS halted");
                        }
                    }
                    amp1.AddInput(amp5.Output.First());

                }

                //var output = nextInput;
                // throw new Exception($"Unepected number of output. Expected 1, actual {output.Count}");
                if (lastOutput != null)
                {
                    if (maxThrusterSignal == null || maxThrusterSignal.Value < lastOutput.Value)
                    {
                        //Output = output;
                        maxThrusterSignal = lastOutput.Value;
                    }
                }
            }
            if (!maxThrusterSignal.HasValue)
                throw new Exception("Did not find the maximum Thruster Signal");
            MaxThrusterSignal = maxThrusterSignal.Value;
        }


        private int[] SetInput(int seq)
        {
            return new int[1] { seq };
        }

        private int[] SetInput(int seq, List<int> output)
        {
            var input = new List<int> { seq };
            if (output != null)
                input.AddRange(output);

            return input.ToArray();
        }

        private int[] Clone(int[] input)
        {
            return (int[])input.Clone();
        }
    }
}
