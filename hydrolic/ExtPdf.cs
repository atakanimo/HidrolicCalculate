using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace hydrolic
{
    public class ExtPdf
    {
        iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4.Rotate());
        public SaveFileDialog save;
        int i = 0;
        string Nozzle = "";

        public ExtPdf(SaveFileDialog save)
        {
            this.save = save;
        }

        public void CreatePdf(double cbxOpen, double flowRate, double SPP, double drillStringLoss, double holeDepth, double JIF,
            double annularPressure, double mudWeight, double tfaResult, double JIFin2, double bitPressureLossResult, double PV,
            double nozzleVelocity, double HHP, double surfacePressureLoss, double YP, double ECD, double HSI, double mudMoter, int i, double x1)
        {

            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
            try
            {
                PdfWriter.GetInstance(doc, new FileStream(save.FileName, FileMode.Create));

                iTextSharp.text.pdf.BaseFont STF_Helvetica_Turkish = iTextSharp.text.pdf.BaseFont.CreateFont("Helvetica", "CP1254", iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);

                iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(STF_Helvetica_Turkish, 12, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font fontBold = new iTextSharp.text.Font(STF_Helvetica_Turkish, 12, iTextSharp.text.Font.BOLD);

                doc.Open();

                #region Table

                PdfPTable table = new PdfPTable(8);

                PdfPCell cell = new PdfPCell(new Phrase("Kuyu", fontBold));

                table.AddCell(cell);

                table.AddCell(new Phrase(cbxOpen.ToString(), fontNormal));

                table.AddCell(new Phrase("Debi", fontBold));

                table.AddCell(new Phrase(flowRate.ToString(), fontNormal));

                table.AddCell(new Phrase("SPP", fontBold));

                table.AddCell(new Phrase(SPP.ToString()));

                table.AddCell(new Phrase("Dizi İçi Basınç Kaybı", fontBold));

                table.AddCell(new Phrase(drillStringLoss.ToString()));

                table.AddCell(new Phrase("Kuyu Derinliği", fontBold));

                table.AddCell(new Phrase(holeDepth.ToString()));

                table.AddCell(new Phrase("Noozle", fontBold));

                for (int j = 0; j < i; j++)
                {
                    Nozzle = Nozzle + "-" + x1.ToString();
                }

                table.AddCell(Nozzle);

                table.AddCell(new Phrase("JIF", fontBold));

                table.AddCell(JIF.ToString());

                table.AddCell(new Phrase("Analüs Basınç Kaybı", fontBold));

                table.AddCell(annularPressure.ToString());

                table.AddCell(new Phrase("Çamur Ağırlıgı", fontBold));

                table.AddCell(mudWeight.ToString());

                table.AddCell(new Phrase("TFA", fontBold));

                table.AddCell(tfaResult.ToString());

                table.AddCell(new Phrase("JIF/in2", fontBold));

                table.AddCell(JIFin2.ToString());

                table.AddCell(new Phrase("Matkaptaki Basınç Kaybı", fontBold));

                table.AddCell(bitPressureLossResult.ToString());

                table.AddCell(new Phrase("PV", fontBold));

                table.AddCell(PV.ToString());

                table.AddCell(new Phrase("Noozle Velocity", fontBold));

                table.AddCell(nozzleVelocity.ToString());

                table.AddCell(new Phrase("HHP", fontBold));

                table.AddCell(HHP.ToString());

                table.AddCell(new Phrase("Yüzey Hatları Basınç Kaybı", fontBold));

                table.AddCell(surfacePressureLoss.ToString());

                table.AddCell(new Phrase("YP", fontBold));

                table.AddCell(YP.ToString());

                table.AddCell(new Phrase("ECD", fontBold));

                table.AddCell(ECD.ToString());

                table.AddCell(new Phrase("HSI", fontBold));

                table.AddCell(HSI.ToString());

                table.AddCell(new Phrase("Motor Basınç Kaybı", fontBold));

                table.AddCell(mudMoter.ToString());

                doc.Add(table);

                #endregion

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                doc.Close();
                MessageBox.Show("Kayıt Oluşturuldu!");
            }
        }
    }


}


