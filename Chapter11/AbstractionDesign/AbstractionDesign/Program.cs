using System;
using System.Collections.Generic;
using System.Linq;
using AbstractionDesign.Tools;

namespace AbstractionDesign
{
    class Program
    {
        private delegate void CommandHandler(IEnumerable<string> parameters);
        private static Sensor CurrentSensor;

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
                    {"zoom", Zoom},
                    {"capture-image", CaptureImage},
                    {"measure-height", MeasureHeight},
                    {"pitch", Pitch},
                    {"roll", Roll},
                    {"raise", Raise},
                    {"lower", Lower},
                    {"get-pressure", GetPressure},
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
            if (CurrentSensor != null)
            {
                float x, y;

                if (float.TryParse(parameters.FirstOrDefault(), out x) && float.TryParse(parameters.Skip(1).FirstOrDefault(), out y))
                {
                    CurrentSensor.Move(x, y);
                }
                else
                {
                    Console.WriteLine("Move requires two floating-point parameters (eg: 1.5 2.5)");
                }
            }
            else
            {
                Console.WriteLine("Must select a tool!");
            }
        }

        private static void Zoom(IEnumerable<string> parameters)
        {
            var camera = CurrentSensor as Camera;

            if (camera != null)
            {
                float level;

                if (float.TryParse(parameters.FirstOrDefault(), out level))
                {
                    camera.Zoom(level);
                }
                else
                {
                    Console.WriteLine("Zooming camera requires a floating-point parameter (eg: 1.5)");
                }
            }
            else
            {
                Console.WriteLine("Must select camera to zoom!");
            }
        }

        private static void CaptureImage(IEnumerable<string> parameters)
        {
            var camera = CurrentSensor as Camera;

            if (camera != null)
            {
                Console.WriteLine(camera.Capture()); //TODO
            }
            else
            {
                Console.WriteLine("Must select camera to capture an image!");
            }
        }

        private static void MeasureHeight(IEnumerable<string> parameters)
        {
            var laser = CurrentSensor as Laser;

            if (laser != null)
            {
                Console.WriteLine(laser.Measure());
            }
            else
            {
                Console.WriteLine("Must select laser to measure height!");
            }
        }

        private static void Pitch(IEnumerable<string> parameters)
        {
            var touchProbe = CurrentSensor as TouchProbe;

            if (touchProbe != null)
            {
                float level;

                if (float.TryParse(parameters.FirstOrDefault(), out level))
                {
                    touchProbe.Pitch(level);
                }
                else
                {
                    Console.WriteLine("Pitch requires a floating-point parameter (eg: 1.5)");
                }
            }
            else
            {
                Console.WriteLine("Must select touch probe to pitch!");
            }
        }

        private static void Roll(IEnumerable<string> parameters)
        {
            var touchProbe = CurrentSensor as TouchProbe;

            if (touchProbe != null)
            {
                float level;

                if (float.TryParse(parameters.FirstOrDefault(), out level))
                {
                    touchProbe.Roll(level);
                }
                else
                {
                    Console.WriteLine("Roll requires a floating-point parameter (eg: 1.5)");
                }
            }
            else
            {
                Console.WriteLine("Must select touch probe to roll!");
            }
        }

        private static void Raise(IEnumerable<string> parameters)
        {
            var touchProbe = CurrentSensor as TouchProbe;

            if (touchProbe != null)
            {
                float level;

                if (float.TryParse(parameters.FirstOrDefault(), out level))
                {
                    touchProbe.Raise(level);
                }
                else
                {
                    Console.WriteLine("Raise requires a floating-point parameter (eg: 1.5)");
                }
            }
            else
            {
                Console.WriteLine("Must select touch probe to raise!");
            }
        }

        private static void Lower(IEnumerable<string> parameters)
        {
            var touchProbe = CurrentSensor as TouchProbe;

            if (touchProbe != null)
            {
                float level;

                if (float.TryParse(parameters.FirstOrDefault(), out level))
                {
                    touchProbe.Lower(level);
                }
                else
                {
                    Console.WriteLine("Lower requires a floating-point parameter (eg: 1.5)");
                }
            }
            else
            {
                Console.WriteLine("Must select touch probe to lower!");
            }
        }

        private static void GetPressure(IEnumerable<string> parameters)
        {
            var touchProbe = CurrentSensor as TouchProbe;

            if (touchProbe != null)
            {
                Console.WriteLine($"Pressure: {touchProbe.GetPressure().Value}");
            }
            else
            {
                Console.WriteLine("Must select touch probe to get pressure!");
            }
        }

        private static void Quit(IEnumerable<string> parameters)
        {
            Environment.Exit(0);
        }
    }
}
