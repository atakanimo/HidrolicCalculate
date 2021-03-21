using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hydrolic
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        double cbxValue, holeDepth, casingId, casingShoe, mudWeight, flowRate, PV, YP, dcLength, dcId, dcOd;

        private void BtnClean_Click(object sender, EventArgs e)
        {     
            #region clean
            i = 0;
            btnPDF.Enabled = false;
            tbxCasingID.Text = "";
            tbxHole.Text = "";
            tbxCasingShoe.Text = "";
            tbxDcId.Text = "";
            tbxDcLength.Text = "";
            tbxDpId.Text = "";
            tbxDcOd.Text = "";
            tbxDpOd.Text = "";
            tbxHwdpId.Text = "";
            tbxFlowRate.Text = "";
            tbxHwdpLength.Text = "";
            tbxYP.Text = "";
            tbxNozzle9.Text = "";
            tbxNozzle8.Text = "";
            tbxNozzle7.Text = "";
            tbxNozzle6.Text = "";
            tbxNozzle5.Text = "";
            tbxNozzle4.Text = "";
            tbxNozzle3.Text = "";
            tbxNozzle2.Text = "";
            tbxNozzle1.Text = "";
            tbxHwdpOd.Text = "";
            tbxDpLength.Text = "";
            tbxMudMoter.Text = "";
            tbxMudWeight.Text = "";
            tbxPV.Text = "";
            tbxYP.Text = "";
            tbxSurfacePressure.Text = "";
            cbxOpenHole.Text = "";

            #endregion
        }

        double hwdpLength, hwdpId, hwdpOd, dpId, dpOd, dpLength, mudMoter, surfacePressureLoss;
        double x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12;
        double bitPressureLossResult, HHP, HSI, tfaResult, JIF, JIFin2, nozzleVelocity, drillStringLoss, annularPressure, ECD, SPP;

        public int i;

        private void Form1_Load(object sender, EventArgs e)
        {
            btnPDF.Enabled = false;
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            i = 0;

            #region InputFromTbx

            CbxSelectIndexValue();
            try
            {
                holeDepth = 0; casingId = 0; casingShoe = 0; mudWeight = 0; flowRate = 0; PV = 0; YP = 0; dcLength = 0; dcId = 0; dcOd = 0;
                hwdpLength = 0; hwdpId = 0; hwdpOd = 0; surfacePressureLoss = 0; mudMoter = 0; dpLength = 0; dpOd = 0; dpId = 0;

                if (!string.IsNullOrEmpty(tbxHole.Text))
                {
                    holeDepth = Convert.ToDouble(tbxHole.Text);
                }
                if (!string.IsNullOrEmpty(tbxCasingID.Text))
                {
                    casingId = Convert.ToDouble(tbxCasingID.Text);
                }
                if (!string.IsNullOrEmpty(tbxCasingShoe.Text))
                {
                    casingShoe = Convert.ToDouble(tbxCasingShoe.Text);
                }
                if (!string.IsNullOrEmpty(tbxMudWeight.Text))
                {
                    mudWeight = Convert.ToDouble(tbxMudWeight.Text);
                }
                if (!string.IsNullOrEmpty(tbxFlowRate.Text))
                {
                    flowRate = Convert.ToDouble(tbxFlowRate.Text);
                }
                if (!string.IsNullOrEmpty(tbxPV.Text))
                {
                    PV = Convert.ToDouble(tbxPV.Text);
                }
                if (!string.IsNullOrEmpty(tbxYP.Text))
                {
                    YP = Convert.ToDouble(tbxYP.Text);
                }
                if (!string.IsNullOrEmpty(tbxDcLength.Text))
                {
                    dcLength = Convert.ToDouble(tbxDcLength.Text);
                }
                if (!string.IsNullOrEmpty(tbxDcId.Text))
                {
                    dcId = Convert.ToDouble(tbxDcId.Text);
                }
                if (!string.IsNullOrEmpty(tbxDcOd.Text))
                {
                    dcOd = Convert.ToDouble(tbxDcOd.Text);
                }
                if (!string.IsNullOrEmpty(tbxHwdpLength.Text))
                {
                    hwdpLength = Convert.ToDouble(tbxHwdpLength.Text);
                }
                if (!string.IsNullOrEmpty(tbxHwdpId.Text))
                {
                    hwdpId = Convert.ToDouble(tbxHwdpId.Text);
                }
                if (!string.IsNullOrEmpty(tbxHwdpOd.Text))
                {
                    hwdpOd = Convert.ToDouble(tbxHwdpOd.Text);
                }
                if (!string.IsNullOrEmpty(tbxDpId.Text))
                {
                    dpId = Convert.ToDouble(tbxDpId.Text);
                }
                if (!string.IsNullOrEmpty(tbxDpOd.Text))
                {
                    dpOd = Convert.ToDouble(tbxDpOd.Text);
                }
                if (!string.IsNullOrEmpty(tbxDpLength.Text))
                {
                    dpLength = Convert.ToDouble(tbxDpLength.Text);
                }
                if (!string.IsNullOrEmpty(tbxMudMoter.Text))
                {
                    mudMoter = Convert.ToDouble(tbxMudMoter.Text);
                }
                if (!string.IsNullOrEmpty(tbxSurfacePressure.Text))
                {
                    surfacePressureLoss = Convert.ToDouble(tbxSurfacePressure.Text);
                }
            }
            catch
            {

            }

            #endregion

            TryCatchNozzle();

            Calculate calculate = new Calculate();

            tbxResultSurfacePressure.Text = surfacePressureLoss.ToString();
            tbxResultSurfacePressure.ForeColor = Color.Blue;

            tfaResult = Math.Round(calculate.CalculateResult(x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12), 3);
            lblResultTotalFlow.Text = tfaResult.ToString();
            lblResultTotalFlow.ForeColor = Color.Blue;

            bitPressureLossResult = Math.Round(calculate.CalculateBitPressure(mudWeight, flowRate, tfaResult));
            tbxResultBitPressure.Text = bitPressureLossResult.ToString();
            tbxResultBitPressure.ForeColor = Color.Blue;

            HHP = Math.Round(calculate.CalculateHHP(bitPressureLossResult, flowRate));
            tbxResultHHP.Text = HHP.ToString();
            tbxResultHHP.ForeColor = Color.Blue;

            HSI = Math.Round(calculate.CalculateHSI(HHP, cbxValue), 2);
            tbxResultHSI.Text = HSI.ToString();
            tbxResultHSI.ForeColor = Color.Blue;

            JIF = Math.Round(calculate.JIF(flowRate, mudWeight, bitPressureLossResult));
            tbxResultJIF.Text = JIF.ToString();
            tbxResultJIF.ForeColor = Color.Blue;

            JIFin2 = Math.Round(calculate.JIFin2(JIF, cbxValue), 2);
            tbxResultJIFin2.Text = JIFin2.ToString();
            tbxResultJIFin2.ForeColor = Color.Blue;

            nozzleVelocity = Math.Round(calculate.NoozleResult(flowRate, tfaResult));
            tbxResultNoozle.Text = nozzleVelocity.ToString();
            tbxResultNoozle.ForeColor = Color.Blue;

            drillStringLoss = Math.Round(calculate.DrillStringLosses(mudWeight, flowRate, PV, hwdpLength, hwdpId, dcLength, dcId, dpLength, dpId));
            tbxResultDrillString.Text = drillStringLoss.ToString();
            tbxResultDrillString.ForeColor = Color.Blue;

            annularPressure = Math.Round(calculate.AnnularPressure(hwdpLength, mudWeight, flowRate, cbxValue, hwdpOd, PV, YP, dpLength, dpOd, dcLength, dcOd));
            tbxResultAnnular.Text = annularPressure.ToString();
            tbxResultAnnular.ForeColor = Color.Blue;

            ECD = Math.Round(calculate.ECD(annularPressure, holeDepth, mudWeight), 2);
            tbxResultECD.Text = ECD.ToString();
            tbxResultECD.ForeColor = Color.Blue;

            SPP = calculate.SPP(surfacePressureLoss, drillStringLoss, bitPressureLossResult, annularPressure, mudMoter);
            tbxResultSPP.Text = Math.Round(SPP).ToString();
            tbxResultSPP.ForeColor = Color.Blue;

            btnPDF.Enabled = true;
        }

        private void BtnPDF_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog save = new SaveFileDialog() { Filter = "Pdf File|*.pdf", ValidateNames = true })
            {
                if (save.ShowDialog() == DialogResult.OK)
                {
                    ExtPdf ext = new ExtPdf(save);
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());

                    ext.CreatePdf(cbxValue, flowRate, SPP, drillStringLoss, holeDepth, JIF, annularPressure, mudWeight, tfaResult,
                        JIFin2, bitPressureLossResult, PV, nozzleVelocity, HHP, surfacePressureLoss, YP, ECD, HSI, mudMoter, i, x1);
                }
            }

            btnPDF.Enabled = false;
        }
        #region Try-CatchNozzle
        private void TryCatchNozzle()
        {
            try
            {
                x1 = Convert.ToDouble(tbxNozzle1.Text);
                i++;

                if (string.IsNullOrEmpty(tbxNozzle2.Text))
                {
                    x2 = 0;
                }
                else
                {
                    x2 = Convert.ToDouble(tbxNozzle2.Text);
                    i++;
                }

                if (string.IsNullOrEmpty(tbxNozzle3.Text))
                {
                    x3 = 0;
                }
                else
                {
                    x3 = Convert.ToDouble(tbxNozzle3.Text);
                    i++;
                }

                if (string.IsNullOrEmpty(tbxNozzle4.Text))
                {
                    x4 = 0;
                }
                else
                {
                    x4 = Convert.ToDouble(tbxNozzle4.Text);
                    i++;
                }

                if (string.IsNullOrEmpty(tbxNozzle5.Text))
                {
                    x5 = 0;
                }
                else
                {
                    x5 = Convert.ToDouble(tbxNozzle5.Text);
                    i++;
                }

                if (string.IsNullOrEmpty(tbxNozzle6.Text))
                {
                    x6 = 0;
                }
                else
                {
                    x6 = Convert.ToDouble(tbxNozzle6.Text);
                    i++;
                }

                if (string.IsNullOrEmpty(tbxNozzle7.Text))
                {
                    x7 = 0;
                }
                else
                {
                    x7 = Convert.ToDouble(tbxNozzle7.Text);
                    i++;
                }

                if (string.IsNullOrEmpty(tbxNozzle8.Text))
                {
                    x8 = 0;
                }
                else
                {
                    x8 = Convert.ToDouble(tbxNozzle8.Text);
                    i++;
                }

                if (string.IsNullOrEmpty(tbxNozzle9.Text))
                {
                    x9 = 0;
                }
                else
                {
                    x9 = Convert.ToDouble(tbxNozzle9.Text);
                    i++;
                }

                if (string.IsNullOrEmpty(tbxNozzle10.Text))
                {
                    x10 = 0;
                }
                else
                {
                    x10 = Convert.ToDouble(tbxNozzle10.Text);
                    i++;
                }

                if (string.IsNullOrEmpty(tbxNozzle11.Text))
                {
                    x11 = 0;
                }
                else
                {
                    x11 = Convert.ToDouble(tbxNozzle11.Text);
                    i++;
                }

                if (string.IsNullOrEmpty(tbxNozzle12.Text))
                {
                    x12 = 0;
                }
                else
                {
                    x12 = Convert.ToDouble(tbxNozzle12.Text);
                    i++;
                }

            }

            catch
            {
            }
        }
        #endregion

        #region CbxSelectIndexValue
        private void CbxSelectIndexValue()
        {

            cbxValue = 0;
            if (Convert.ToInt32(cbxOpenHole.SelectedIndex) == 2)
            {
                cbxValue = 17.5;
            }
            else if (Convert.ToInt32(cbxOpenHole.SelectedIndex) == 4)
            {
                cbxValue = 12.25;
            }
            else if (Convert.ToInt32(cbxOpenHole.SelectedIndex) == 5)
            {
                cbxValue = 10.625;
            }
            else if (Convert.ToInt32(cbxOpenHole.SelectedIndex) == 6)
            {
                cbxValue = 8.5;
            }
            else
            {
                if (!string.IsNullOrEmpty(cbxOpenHole.Text))
                {
                    cbxValue = Convert.ToDouble(cbxOpenHole.SelectedItem.ToString());
                }
            }
        }
        #endregion
    }
}
