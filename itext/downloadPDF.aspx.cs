﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;
using System.IO;

namespace itext
{
    public partial class downloadPDF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorTxt.Text = "Loaded";
        }

        protected void test_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
            sb.Append("<tr><th>Test</th></tr>");
            sb.Append("<tr><td align='center' style='background-color:#18B5F0' colspan = '2'>12</td></tr>");
            sb.Append("</table>");
            //sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Order Sheet</b></td></tr>");
            //sb.Append("<tr><td colspan = '2'></td></tr>");
            //sb.Append("<tr><td><b>Order No:</b>");
            //sb.Append("123");
            //sb.Append("</td><td><b>Date: </b>");
            //sb.Append(DateTime.Now);
            //sb.Append(" </td></tr>");
            //sb.Append("<tr><td colspan = '2'><b>Company Name :</b> ");
            //sb.Append("Test");
            //sb.Append("</td></tr>");
            //sb.Append("</table>");
            //sb.Append("<br />");
            //sb.Append("<table border = '1'>");
            //sb.Append("<tr>");
            string gridHtml = sb.ToString();
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(gridHtml);
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", "Grid.pdf");
               
            }
            //StringReader sr = new StringReader(sb.ToString());

            //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //using (MemoryStream memoryStream = new MemoryStream())
            //{
            //    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
            //    pdfDoc.Open();

            //    htmlparser.Parse(sr);
            //    pdfDoc.Close();

            //    byte[] bytes = memoryStream.ToArray();
            //    memoryStream.Close();

            //    Response.Clear();
            //    // Gets or sets the HTTP MIME type of the output stream.
            //    Response.ContentType = "application/pdf";
            //    // Adds an HTTP header to the output stream
            //    Response.AddHeader("Content-Disposition", "attachment; filename=Invoice.pdf");

            //    //Gets or sets a value indicating whether to buffer output and send it after
            //    // the complete response is finished processing.
            //    Response.Buffer = true;
            //    // Sets the Cache-Control header to one of the values of System.Web.HttpCacheability.
            //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //    // Writes a string of binary characters to the HTTP output stream. it write the generated bytes .
            //    Response.BinaryWrite(bytes);
            //    // Sends all currently buffered output to the client, stops execution of the
            //    // page, and raises the System.Web.HttpApplication.EndRequest event.

            //    Response.End();
            //    // Closes the socket connection to a client. it is a necessary step as you must close the response after doing work.its best approach.
            //    Response.Close();
            //}
           
        }
    }
}