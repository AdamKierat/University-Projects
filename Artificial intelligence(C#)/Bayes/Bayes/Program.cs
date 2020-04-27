using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bayes
{
    class Program
    {

        static void Main(string[] args)
        { 
            Bayes b = new Bayes();
            b.ReadFromFiles();
           
            b.Propability("slonecznie", "ciepło", "słaby");
            Console.ReadKey();
        }

    }
    class Bayes
    {
        int temp1 { get; set; }
        private string[] _lines = File.ReadAllLines(@"..\\dane.txt");
        private string[][] _data;
        private double[] _counters=new double[5] {0,0,0,0,0};
        private double[] _sumcounters = new double[3] { 0, 0, 0 };


        public void ReadFromFiles()
        {
            _data = new string[_lines.Length][];
            for (int i = 0; i < _lines.Length; i++)
            {
                string[] tmp = _lines[i].Split(';');
                _data[i] = new string[tmp.Length];
                for (int j = 0; j < tmp.Length; j++)
                {
                    _data[i][j] = tmp[j];
                }
            }
        }
        public void Propability(string a1, string a2, string a3)
        {

            for (int i = 0; i < _lines.Length; i++)
            {
                if (_data[i][0] == a1) { _counters[0]++; }
                if (_data[i][1] == a2) { _counters[1]++; }
                if (_data[i][2] == a3) { _counters[2]++; }
                if (_data[i][0] == a1 && _data[i][3] == "tak") { _sumcounters[0]++; }
                if (_data[i][1] == a2 && _data[i][3] == "tak") { _sumcounters[1]++; }
                if (_data[i][2] == a3 && _data[i][3] == "tak") { _sumcounters[2]++; }
                if (_data[i][3] == "tak") { _counters[3]++; }
                if (_data[i][3] == "nie") { _counters[4]++; }
            }

            double[] prop1C = new double[3];
            double[] prop1B = new double[3];
            for (int i = 0; i < 3; i++)
            {
                if (_sumcounters[i]==0)
                {
                    prop1C[i] = 1 / (_counters[3] + 3);
                }
                else
                {
                    prop1C[i] = _sumcounters[i] / _counters[3] ;
                }             
            }
            for (int i = 0; i < 3; i++)
            {
                if (_counters[i] -_sumcounters[i] == 0)
                {
                    prop1B[i] = 1 / (_counters[4] + 3);
                }
                else
                {
                    prop1B[i] = (_counters[i] - _sumcounters[i]) / _counters[4] ;
                }
            }
            
            double propC1;
            double propC2;

            double pC1 = _counters[3] / _lines.Length;
            double pC2 = _counters[4] / _lines.Length;
            

            propC1 =  prop1C[0]*prop1C[1]* prop1C[2]*pC1;
            propC2 = prop1B[0] * prop1B[1] * prop1B[2] * pC2;

            Console.WriteLine("Decyzja na tak wartosc: " + propC1);
            Console.WriteLine("Decyzja na nie wartosc: " + propC2);

            if (propC1>propC2)
            {
                Console.WriteLine("Decyzja : TAK");
            }
            else 
            {
                Console.WriteLine("Decyzja : NIE");
            }
           
            
        }
    }
}

