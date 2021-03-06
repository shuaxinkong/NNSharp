﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NNSharp.DataTypes;
using NNSharp.Kernels.CPUKernels;
using static NNSharp.DataTypes.Data2D;
using static NNSharp.DataTypes.SequentialModelData;

namespace NNSharp.SequentialBased.SequentialLayers
{
    [Serializable()]
    public class SoftmaxLayer : SoftmaxKernel, ILayer
    {

        public IData GetOutput()
        {
            return data;
        }

        public void SetInput(IData input)
        {
            if (input == null)
                throw new Exception("SoftmaxLayer: input is null.");
            else if (!(input is Data2D))
                throw new Exception("SoftmaxLayer: input is not Data2D.");

            this.data = input as Data2D;

            Dimension dim = data.GetDimension();

            if (!(dim.h == 1 && dim.w == 1))
                throw new Exception("SoftmaxLayer: wrong intput size.");
        }

        public void SetWeights(IData weights)
        {
            // No weights.
        }

        public LayerData GetLayerSummary()
        {
            // The input and the output have the same sizes as the output
            // of the previous layer.
            return new LayerData(
                this.ToString(),
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1);
        }
    }
}
