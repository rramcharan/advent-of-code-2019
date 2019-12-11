using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019_day9.Part1
{
    public class AmplifierWithFeedbackLookController
    {
        public long MaxThrusterSignal { get; private set; }
        public List<long> Output { get; private set; }

        public static AmplifierWithFeedbackLookController RunSequenceOnAmplifiers(long[] input, long seq1, long seq2, long seq3, long seq4, long seq5)
        {
            var result = new AmplifierWithFeedbackLookController();
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
            long? lastOutput = null;
            var seqCombinations = new AmplifierWithFeedbackLookController().AllCombination(seq1, seq2, seq3, seq4, seq5);

            foreach (var seq in seqCombinations)
            {
                var amp1 = IntCodeComputer.Create("Amp1", Clone(code), SetInput(seq[0], new List<long> { 0 })); ;
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


        private long[] SetInput(long seq)
        {
            return new long[1] { seq };
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
}
