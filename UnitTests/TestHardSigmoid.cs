﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NNSharp.SequentialBased.SequentialLayers;
using NNSharp.DataTypes;
using NNSharp.IO;
using NNSharp.Models;
using UnitTests.Properties;

namespace UnitTests
{
    [TestClass]
    public class TestHardSigmoid
    {
        [TestMethod]
        public void Test_HardSigmoid_Execute()
        {
            hardsigmoid = new HardSigmoidLayer();

            Data2D data = new Data2D(2, 3, 1, 1);
            data[0, 0, 0, 0] = 4;
            data[0, 1, 0, 0] = 2;
            data[0, 2, 0, 0] = -2;

            data[1, 0, 0, 0] = 3;
            data[1, 1, 0, 0] = -1;
            data[1, 2, 0, 0] = -3;

            hardsigmoid.SetInput(data);

            hardsigmoid.Execute();

            Data2D output = hardsigmoid.GetOutput() as Data2D;

            Assert.AreEqual(output[0, 0, 0, 0], HardSigmoidFunc(4.0), 0.00000001);
            Assert.AreEqual(output[0, 1, 0, 0], HardSigmoidFunc(2.0), 0.00000001);
            Assert.AreEqual(output[0, 2, 0, 0], HardSigmoidFunc(-2.0), 0.00000001);

            Assert.AreEqual(output[1, 0, 0, 0], HardSigmoidFunc(3.0), 0.00000001);
            Assert.AreEqual(output[1, 1, 0, 0], HardSigmoidFunc(-1.0), 0.00000001);
            Assert.AreEqual(output[1, 2, 0, 0], HardSigmoidFunc(-3.0), 0.00000001);
        }

        private double HardSigmoidFunc(double x)
        {
            return Math.Max(0.0, Math.Min(1, 0.2*x+0.5));
        }

        [TestMethod]
        public void Test_HardSigmoid_KerasModel()
        {
            string pathModel = Resources.TestsFolder + "test_hard_sigmoid_model.json";
            string pathInput = Resources.TestsFolder + "test_hard_sigmoid_input.json";
            string pathOutput = Resources.TestsFolder + "test_hard_sigmoid_output.json";

            Utils.KerasModelTest(pathInput, pathModel, pathOutput);
        }


        private HardSigmoidLayer hardsigmoid;
    }
}
