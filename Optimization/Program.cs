using System;

namespace Optimization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press M for Monte Carlo and G for Gradient Descent");
            string checkMethod;
            checkMethod = Console.ReadLine();
            double StressA;
            double StressB;
            double R;
            double b;
            double Rout;
            double Rin;
            double h;
            double Rn;
            double e;
            double V;
            double Vmin = 100;
            double minRin=0;
            double minRout=0;
            double minb=0;

            if (checkMethod == "m")
            {
                for (int j = 0; j < 100000000; j++)
                {
                    Random rnd = new Random();
                    Rin = rnd.NextDouble()* 10 + 1.5;
                    b = rnd.NextDouble() * 10 + 0.2;
                    Rout = rnd.NextDouble() * 10 + Rin+ 0.001;

                    R = (Rout + Rin) / 2;
                    h = (Rout - Rin);
                    Rn = h / Math.Log(Rout / Rin);
                    e = R - Rn;
                    StressA = 100 * R * (Rout - Rn) / (b * h * e * Rout);
                    StressB = 100 * R * (Rn - Rin) / (b * h * e * Rin);
                    if (StressA <= 430 & StressB <= 430)
                    {
                        V = Math.PI * ((Rout * Rout) - (Rin * Rin)) * b;

                        if (V < Vmin)
                        {
                            Vmin = V;
                            minRin = Rin;
                            minRout = Rout;
                            minb = b;
                        }

                        Console.WriteLine(" V = {0}, Rin = {1}, Rout = {2}, b = {3}", Vmin,Rin,Rout,b);

                    }
                }

                Console.WriteLine(" V = {0}, Rin = {1}, Rout = {2}, b = {3}", Vmin, minRin, minRout, minb);
            }

            
            //const double LearningRate = 0.09;
            //const double dx = 0.001;
            //const double Convergence = 0.000001;
            //double[] Gradient = new double[3];
            //double[] Parameter = new double[3]; //0=Rout 1=Rin 2=b
            //if (checkMethod == "g")
            //{
            //Parameter[0] = 5;
            //Parameter[1] = 2.5;
            //Parameter[2] = 3;
            //Gradient Descent
            //do
            //{
            //Calculate Gradient
            //for (int i = 0; i < 3; i++)
            //{
            //Parameter[i] = Parameter[i] + dx;
            //double VPlus = Math.PI * ((Parameter[0] * Parameter[0]) - (Parameter[1] * Parameter[1])) * Parameter[2];
            //Parameter[i] = Parameter[i] - dx;
            //V = Math.PI * ((Parameter[0] * Parameter[0]) - (Parameter[1] * Parameter[1])) * Parameter[2];
            //Gradient[i] = (VPlus - V) / dx;
            //}
            //Descent
            //for (int i = 0; i < 3; i++)
            //{

            //Parameter[i] = LearningRate * -(Gradient[i]);
            //}

            //R = (Rout + Rin) / 2;
            //h = (Rout - Rin);
            //Rn = h / Math.Log(Rout / Rin);
            //e = R - Rn;
            //StressA = 100 * R * (Rout - Rn) / (b * h * e * Rout);
            //StressB = 100 * R * (Rn - Rin) / (b * h * e * Rin);

            //if (StressA <= 430 & StressB <= 430)
            //{
            //V = Math.PI * ((Parameter[0] * Parameter[0]) - (Parameter[1] * Parameter[1])) * Parameter[2];
            //Console.WriteLine(" V = {0}, Rout = {1}, Rin = {2}, b = {3}", V, Parameter[0], Parameter[1], Parameter[2]);
            //}


            //} while (true);


            //}

        }
    }
}
