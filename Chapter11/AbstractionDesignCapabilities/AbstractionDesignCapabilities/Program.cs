using System;
using System.Collections.Generic;
using System.Linq;
using AbstractionDesignCapabilities.Interfaces;
using AbstractionDesignCapabilities.Tools;

namespace AbstractionDesignCapabilities
{
    class Program
    {
        private delegate void CommandHandler(IEnumerable<string> parameters);
        private static ISensor CurrentSensor;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine() ?? string.Empty;
                var tokens = input.Split(' ');

                if (tokens.Length < 1)
                {
                    Console.WriteLine("Please supply a command");
                    continue;
                }

                var command = tokens.First();
                var parameters = tokens.Skip(1);

                var handlers = new Dictionary<string, CommandHandler>
                {
                    {"select", SelectTool},
                    {"move", Move},
                    {"measure", Measure},
                    {"rotate", Rotate},
                    {"adjust-height", AdjustHeight},
                    {"quit", Quit}
                };

                if (!handlers.ContainsKey(command))
                {
                    Console.WriteLine($"Unrecognized command: {command}");
                }
                else
                {
                    handlers[command].Invoke(parameters);
                }
            }
        }

        private static void SelectTool(IEnumerable<string> parameters)
        {
            switch (parameters.FirstOrDefault())
            {
                case "camera":
                    CurrentSensor = new Camera();
                    Console.WriteLine("Tool is now the camera");
                    break;
                case "laser":
                    CurrentSensor = new Laser();
                    Console.WriteLine("Tool is now the laser");
                    break;
                case "touchprobe":
                    CurrentSensor = new TouchProbe();
                    Console.WriteLine("Tool is now the touch probe");
                    break;
                default:
                    Console.WriteLine("Possible Tools are camera, laser or touchprobe");
                    break;
            }
        }

        private static void Move(IEnumerable<string> parameters)
        {
            var movableSensor = CurrentSensor as IMovable;

            if (movableSensor == null)
            {
                Console.WriteLine($"Current sensor '{CurrentSensor?.GetName()}' is not movable");
                return;
            }

            float x, y;
            if (float.TryParse(parameters.FirstOrDefault(), out x) && float.TryParse(parameters.Skip(1).FirstOrDefault(), out y))
            {
                movableSensor.Move(x, y);
            }
            else
            {
                Console.WriteLine("Move requires two floating-point parameters (eg: 1.5)");
            }
        }

        private static void Measure(IEnumerable<string> parameters)
        {
            var measureableSensor = CurrentSensor as IMeasurable;

            if (measureableSensor == null)
            {
                Console.WriteLine($"Current sensor '{CurrentSensor?.GetName()}' is not measurable");
                return;
            }

            measureableSensor.WriteMeasurement(Console.Out);
        }

        private static void Rotate(IEnumerable<string> parameters)
        {
            var rotatableSensor = CurrentSensor as IRotatable;

            if (rotatableSensor == null)
            {
                Console.WriteLine($"Current sensor '{CurrentSensor?.GetName()}' is not rotatable");
                return;
            }

            float value;

            if (parameters.Count() >= 2 && float.TryParse(parameters.Skip(1).FirstOrDefault(), out value))
            {
                var direction = parameters.FirstOrDefault();
                switch (direction)
                {
                    case "pitch":
                    {
                        rotatableSensor.Pitch(value);
                        break;
                    }
                    case "roll":
                    {
                        rotatableSensor.Roll(value);
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("First parameter to height adjustment must be 'pitch' or 'roll'");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Rotate requires two parameters: 'pitch/roll' and height (eg: 1.5f)");
            }
        }

        private static void AdjustHeight(IEnumerable<string> parameters)
        {
            var heightAdjustableSensor = CurrentSensor as IHeightAdjustable;

            if (heightAdjustableSensor == null)
            {
                Console.WriteLine($"Current sensor '{CurrentSensor?.GetName()}' is not height adjustable");
                return;
            }

            float height;

            if (parameters.Count() >= 2 && float.TryParse(parameters.Skip(1).FirstOrDefault(), out height))
            {
                var direction = parameters.FirstOrDefault();
                switch (direction)
                {
                    case "raise":
                    {
                        heightAdjustableSensor.Raise(height);
                        break;
                    }
                    case "lower":
                    {
                        heightAdjustableSensor.Lower(height);
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("First parameter to height adjustment must be 'raise' or 'lower'");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Height adjustment requires two parameters: 'raise/lower' and height (eg: 1.5f)");
            }
        }

        private static void Quit(IEnumerable<string> parameters)
        {
            Environment.Exit(0);
        }
    }
}
