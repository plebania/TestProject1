namespace TestProject1
{

    public class MachinePowerCalculator
    {
        public String[] GetMachineTypes()
        {
            throw new NotImplementedException();
        }
        public double GetPowerConsumtion(string machineType, int durotion, bool isEnergySaving)
        {
            throw new NotImplementedException();
        }
    }

    public class MachinePowerCalculatorTests
    {
        MachinePowerCalculator calc;
        string[] machines = { "MillingMachine", "Press", "Lathe" };
        [Fact]
        public void GetPowerConsumtion_InvalidMachineTypeTest_ShouldThrow()
        {
            calc = new MachinePowerCalculator();
            Action act = () => calc.GetPowerConsumtion("", 1, false);
            Assert.Throws<ArgumentException>(act);

            act = () => calc.GetPowerConsumtion(null, 1, false);
            Assert.Throws<ArgumentException>(act);
        }
        [Fact]
        public void GetPowerConsumtion_DurationLessOrEqualZero_ShouldThrow()
        {
            calc = new MachinePowerCalculator();

            Action act = () => calc.GetPowerConsumtion(machines[0], 0, false);
            Assert.Throws<ArgumentException>(act);

            act = () => calc.GetPowerConsumtion(machines[0], -1, false);
            Assert.Throws<ArgumentException>(act);
        }
        [Fact]
        public void GetPowerConsumtion_MillingMachineBasePowerConsumtion5kWh_ShouldBeLinearyProportional()
        {
            calc = new MachinePowerCalculator();

            double resPower = calc.GetPowerConsumtion(machines[0], 1, false);
            double predictedPower = 5;
            double tolerance = 0.01;
            Assert.InRange<double>(resPower, predictedPower - tolerance, predictedPower + tolerance);


            resPower = calc.GetPowerConsumtion(machines[0], 3, false);
            predictedPower = 15;
            Assert.InRange<double>(resPower, predictedPower - tolerance, predictedPower + tolerance);
        }
        [Fact]
        public void GetPowerConsumtion_PressBasePowerConsumtion7_2kWh_ShouldBeLinearyProportional()
        {
            calc = new MachinePowerCalculator();

            double resPower = calc.GetPowerConsumtion(machines[1], 1, false);
            double predictedPower = 7.2;
            double tolerance = 0.01;
            Assert.InRange<double>(resPower, predictedPower - tolerance, predictedPower + tolerance);


            resPower = calc.GetPowerConsumtion(machines[1], 3, false);
            predictedPower = 21.6;
            Assert.InRange<double>(resPower, predictedPower - tolerance, predictedPower + tolerance);
        }

        [Fact]
        //P=3.5*log(durtation+1)
        public void GetPowerConsumtion_LatheBasePowerConsumtion3_5kWh_ShouldFollowNonStandardEquation()
        {
            calc = new MachinePowerCalculator();

            double resPower = calc.GetPowerConsumtion(machines[3], 1, false);
            double predictedPower = 1.05;
            double tolerance = 0.01;
            Assert.InRange<double>(resPower, predictedPower - tolerance, predictedPower + tolerance);


            resPower = calc.GetPowerConsumtion(machines[3], 2, false);
            predictedPower = 1.67;
            Assert.InRange<double>(resPower, predictedPower - tolerance, predictedPower + tolerance);

            resPower = calc.GetPowerConsumtion(machines[3], 10, false);
            predictedPower = 3.64;
            Assert.InRange<double>(resPower, predictedPower - tolerance, predictedPower + tolerance);


            resPower = calc.GetPowerConsumtion(machines[3], 100, false);
            predictedPower = 7.02;
            Assert.InRange<double>(resPower, predictedPower - tolerance, predictedPower + tolerance);
        }

        [Fact]
        public void GetPowerConsumtion_UnknownMachineType_ShouldThrow()
        {
            calc = new MachinePowerCalculator();
            const string unknownMachine = "oaneeicubeiucosiencosiemclvjnsflsuydhblvisdujnlibsdnfbviusndf";
            Action act = () => calc.GetPowerConsumtion(unknownMachine, 0, false);
            var exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Invalid machine type", exception.Message);
        }

        [Fact]
        public void GetPowerConsumtion_MillingMachineEnergySave_ShouldBe20percentLess()
        {
            calc = new MachinePowerCalculator();

            double resPower = calc.GetPowerConsumtion(machines[0], 1, true);
            double predictedPower = 5 - 5 * 0.2;

            double tolerance = 0.01;
            Assert.InRange<double>(resPower, predictedPower - tolerance, predictedPower + tolerance);


            resPower = calc.GetPowerConsumtion(machines[0], 3, true);
            predictedPower = 15 - 15 * 0.2;
            Assert.InRange<double>(resPower, predictedPower - tolerance, predictedPower + tolerance);
        }
        [Fact]
        public void GetPowerConsumtion_PressEnergySaveMode_ShouldBe20percentLess()
        {
            calc = new MachinePowerCalculator();

            double resPower = calc.GetPowerConsumtion(machines[1], 1, false);
            double predictedPower = 7.2 - 0.2 * 7.2;
            double tolerance = 0.01;
            Assert.InRange<double>(resPower, predictedPower - tolerance, predictedPower + tolerance);


            resPower = calc.GetPowerConsumtion(machines[1], 3, false);
            predictedPower = 21.6 - 0.2 * 21.6;
            Assert.InRange<double>(resPower, predictedPower - tolerance, predictedPower + tolerance);
        }

        [Fact]
        //P=3.5*log(durtation+1)
        public void GetPowerConsumtion_LatheEnergySaveMode_ShouldBe20percentLess()
        {
            calc = new MachinePowerCalculator();

            double resPower = calc.GetPowerConsumtion(machines[3], 1, false);
            double predictedPower = 1.05 - 0.2 * 1.05;
            double tolerance = 0.01;
            Assert.InRange<double>(resPower, predictedPower - tolerance, predictedPower + tolerance);


            resPower = calc.GetPowerConsumtion(machines[3], 2, false);
            predictedPower = 1.67 - 0.2 * 1.67;
            Assert.InRange<double>(resPower, predictedPower - tolerance, predictedPower + tolerance);

            resPower = calc.GetPowerConsumtion(machines[3], 10, false);
            predictedPower = 3.64 - 0.2 * 3.64;
            Assert.InRange<double>(resPower, predictedPower - tolerance, predictedPower + tolerance);


            resPower = calc.GetPowerConsumtion(machines[3], 100, false);
            predictedPower = 7.02 - 0.2 * 7.02;
            Assert.InRange<double>(resPower, predictedPower - tolerance, predictedPower + tolerance);
        }
    }
}