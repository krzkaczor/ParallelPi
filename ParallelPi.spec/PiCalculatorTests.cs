using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParallelPi.spec
{
    public class PiCalculatorTests
    {
        [Fact]
        public void ShouldGenerateHexPi() {
            var piCalculator = new PiGenerator(new BbfFormula());
                
            var result = piCalculator.CalculateHexPi(50);
            Assert.Equal("3.243F6A8885A308D313198A2E03707344A4093822299F31D008", result);
        }

        [Fact]
        public void ShouldGenerateDecPi()
        {
            var piCalculator = new PiGenerator(new BbfFormula());

            var result = piCalculator.CalculateDecPi(50);
            Assert.Equal("3.14159265358979323846264338327950288419716939937510", result);
        }
    }
}
