﻿using System;
using Microsoft.Extensions.DependencyInjection;
using PlantSimulator.Simulation.Options;

namespace PlantSimulator.Runtime.Helpers
{
    internal static class ServiceProviderExtensions
    {
        private static readonly Type _optionsType = typeof(IPlantSimulatorOptions);

        public static Simulation.PlantSimulator ResolvePlantSimulatorConstructor(this IServiceProvider provider, PlantSimulationOptions options)
        {
            var type = typeof(Simulation.PlantSimulator);

            InvalidOperationException exception = null;

            foreach (var constructor in type.GetConstructors())
            {
                try
                {
                    var parameters = constructor.GetParameters();

                    object[] parameterValues = new object[parameters.Length];

                    for (int i = 0; i < parameters.Length; i++)
                    {
                        var parameter = parameters[i];

                        if (_optionsType.IsAssignableFrom(parameter.ParameterType))
                        {
                            parameterValues[i] = options;
                        }
                        else
                        {
                            parameterValues[i] = provider.GetRequiredService(parameter.ParameterType);
                        }
                    }
                    return (Simulation.PlantSimulator) Activator.CreateInstance(type, parameterValues, null);
                }
                catch (InvalidOperationException e)
                {
                    exception = e;
                }
            }

            if (exception != null) throw exception;
            return null;
        }
    }
}