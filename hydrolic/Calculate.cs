using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace hydrolic
{
    public class Calculate
    {
        private double result;
        public double CalculateResult(double x1, double x2, double x3, double x4, double x5, double x6, double x7, double x8, double x9, double x10, double x11, double x12)
        {
            return result = 3.142 * (Math.Pow(x1 / 64, 2) + Math.Pow(x2 / 64, 2) + Math.Pow(x3 / 64, 2) +
                                     Math.Pow(x4 / 64, 2) + Math.Pow(x5 / 64, 2) + Math.Pow(x6 / 64, 2) +
                                     Math.Pow(x7 / 64, 2) + Math.Pow(x8 / 64, 2) + Math.Pow(x9 / 64, 2) +
                                     Math.Pow(x10 / 64, 2) + Math.Pow(x11 / 64, 2) + Math.Pow(x12 / 64, 2));
        }

        public double CalculateBitPressure(double MudWeight, double FlowRate, double tfaresult)
        {
            return ((MudWeight / 7.48) * Math.Pow(FlowRate, 2)) / (10857 * Math.Pow(tfaresult, 2));
        }

        public double CalculateHHP(double BitPressureLossResult, double FlowRate)
        {
            return BitPressureLossResult * FlowRate / 1714;
        }

        public double CalculateHSI(double HHP, double CbxValue)
        {
            return HHP / (3.142 * Math.Pow(CbxValue, 2) / 4);
        }

        public double JIF(double flowrate, double mudweight, double bitpressure)
        {
            return 0.017319 * flowrate * Math.Sqrt((mudweight / 7.48) * bitpressure);
        }

        public double JIFin2(double JIF, double cbxValue)
        {
            return JIF / (3.142 * (Math.Pow(cbxValue, 2) / 4));
        }
        public double NoozleResult(double flowrate, double TFA)
        {
            return (0.32086 * flowrate / TFA);
        }
        public double DrillStringLosses(double mudweight, double flowrate, double pv, double hwdpLength, double hwdpId, double dcLength, double dcId, double dpLength, double dpId)
        {
            return (0.00006775 * Math.Pow(mudweight / 7.48, 0.88) * Math.Pow(flowrate, 1.8) * Math.Pow(pv, 0.18) *
                    (hwdpLength * 3.281 * Math.Pow(hwdpId, -4.78) + dcLength * 3.281 * Math.Pow(dcId, -4.78) +
                     dpLength * 3.281 * Math.Pow(dpId, -4.78)));
        }

        public double AnnularPressure(double hwdpLength, double mudWeight, double flowRate, double openHoleDia, double hwdpOd, double pv, double yp, double dpLength, double dpOd, double dcLength, double dcOd)
        {
            return ((hwdpLength * 3.281 / 250) * (0.000055 * Math.Pow(mudWeight / 7.48, 0.88) *
                       Math.Pow(
                           (flowRate * 24.5) /
                           (Math.Pow(openHoleDia, 2) - Math.Pow(hwdpOd, 2)), 1.8)
                       * Math.Pow((pv + (yp / 10)), 0.2) / (openHoleDia - hwdpOd)))
                   +
                   ((dpLength * 3.281 / 250) * (0.000055 * Math.Pow(mudWeight / 7.48, 0.88) *
                                                    Math.Pow(
                                                        (flowRate * 24.5) /
                                                        (Math.Pow(openHoleDia, 2) - Math.Pow(dpOd, 2)), 1.8)
                                                    * Math.Pow((pv + (yp / 10)), 0.2) / (openHoleDia - dpOd)))
                   +
                   ((dcLength * 3.281 / 250) * (0.000055 * Math.Pow(mudWeight / 7.48, 0.88) *
                       Math.Pow(
                           (flowRate * 24.5) /
                           (Math.Pow(openHoleDia, 2) - Math.Pow(dcOd, 2)), 1.8)
                       * Math.Pow((pv + (yp / 10)), 0.2) / (openHoleDia - dcOd)));
        }

        public double ECD(double annularPressure, double holeDepth, double mudWeight)
        {
            return ((annularPressure * 7.48) / (0.052 * holeDepth * 3.28)) + mudWeight;
        }

        public double SPP(double surfacePressure, double drillString, double bitPressure, double annularPressure, double mudMoter)
        {
            return surfacePressure + drillString + bitPressure + annularPressure + mudMoter;
        }
    }
}
