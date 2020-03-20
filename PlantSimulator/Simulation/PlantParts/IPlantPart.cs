﻿using System.Collections.Generic;
using PlantSimulator.Simulation.Cells;

namespace PlantSimulator.Simulation.PlantParts
{
    /// <summary>
    /// Interface for all the things that the different plant parts have in common.
    /// This includes plant cells, the ability to grow etc.
    /// </summary>
    public interface IPlantPart
    {
        /// <summary>
        /// Get all the plant cells
        /// </summary>
        public IEnumerable<IPlantCell> Cells { get; }

        /// <summary>
        /// Let this plant part grow
        /// </summary>
        public void Grow();
    }
}