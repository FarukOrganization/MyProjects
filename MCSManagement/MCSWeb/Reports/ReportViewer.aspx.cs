using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DALManagment;
using Microsoft.Reporting.WebForms;
using ParameterManagment;
using BusinessManagement;

public partial class Reports_ReportViewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //DataSet oDataSet = new DataSet();
        //DataTable oDataTable = new DataTable();
        //oDataSet.Tables.Add(oDataTable);

        //List<GetAllCurrencyInformationResult> lstAllCurrencyInformationList = CCurrencyInformationManagement.GetAllCurrency();

        //ReportDataSource oReportDataSource = new ReportDataSource("DataSet2_GetAllCurrencyInformation", lstAllCurrencyInformationList);

        //ReportViewer1.DocumentMapCollapsed = true;
        //ReportViewer1.DocumentMapWidth = Unit.Percentage(100);
        //ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "\\Reports\\Report.rdlc";
        //ReportViewer1.LocalReport.ReportEmbeddedResource = "Report.rdlc";
        //ReportViewer1.LocalReport.DataSources.Add(oReportDataSource);

        PrepareAndLoadReport();
    }

   private void PrepareAndLoadReport()
    {
        if (Request.QueryString["report"] != null && Request.QueryString["report"].ToString().Equals("purchaselistbydate"))
        {
            LoadPurchaseByDateReport();

        }
        else if (Request.QueryString["report"] != null && Request.QueryString["report"].ToString().Equals("selllistbydate"))
        {
            LoadSellByDateReport();

        }
        else if (Request.QueryString["report"] != null && Request.QueryString["report"].ToString().Equals("purchasesellbalance"))
        {
            LoadPurchaseSellBalanceReport();

        }

      //report=purchaselistbydate&fromdate=" + fromdate.value + "&todate
    
    }

   private void LoadPurchaseByDateReport()
   {
       DateTime dtFromDate = DateTime.Today.Date;
       DateTime dtToDate = DateTime.Today.Date;

        if (Request.QueryString["fromdate"] != null)
        {
            dtFromDate = Convert.ToDateTime(Request.QueryString["fromdate"]);
        }
        if (Request.QueryString["todate"] != null)
        {
            dtToDate = Convert.ToDateTime(Request.QueryString["todate"]);
        }

    
        //DataSet oDataSet = new DataSet();
        //DataTable oDataTable = new DataTable();
        //oDataSet.Tables.Add(oDataTable);

        List<GetPurchaseInformationForReportResult> lstPurchaseInfoList = CPurchaseInformationManagment.GetPurchaseInformationForReport(dtFromDate, dtToDate);

        ReportDataSource oReportDataSource = new ReportDataSource("GetPurchaseInformationForReportResult", lstPurchaseInfoList);

        ReportViewer1.DocumentMapCollapsed = true;
        ReportViewer1.DocumentMapWidth = Unit.Percentage(100);
        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "\\Reports\\PurchaseReports\\PurchaseSummaryReport.rdlc";
        ReportViewer1.LocalReport.ReportEmbeddedResource = "PurchaseSummaryReport.rdlc";
        ReportViewer1.LocalReport.DataSources.Add(oReportDataSource);
       
   }


   private void LoadSellByDateReport()
   {
       DateTime dtFromDate = DateTime.Today.Date;
       DateTime dtToDate = DateTime.Today.Date;

       if (Request.QueryString["fromdate"] != null)
       {
           dtFromDate = Convert.ToDateTime(Request.QueryString["fromdate"]);
       }
       if (Request.QueryString["todate"] != null)
       {
           dtToDate = Convert.ToDateTime(Request.QueryString["todate"]);
       }


       //DataSet oDataSet = new DataSet();
       //DataTable oDataTable = new DataTable();
       //oDataSet.Tables.Add(oDataTable);

       List<GetSellInformationForReportResult> lstSellInfoList = CSellInformationManagment.GetSellInformationForReport(dtFromDate, dtToDate);

       ReportDataSource oReportDataSource = new ReportDataSource("GetSellInformationForReportResult", lstSellInfoList);

       ReportViewer1.DocumentMapCollapsed = true;
       ReportViewer1.DocumentMapWidth = Unit.Percentage(100);
       ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "\\Reports\\SellReports\\SellSummaryReport.rdlc";
       ReportViewer1.LocalReport.ReportEmbeddedResource = "SellSummaryReport.rdlc";
       ReportViewer1.LocalReport.DataSources.Add(oReportDataSource);

   }

   private void LoadPurchaseSellBalanceReport()
   {
       DateTime dtDate = DateTime.Today.Date;

       if (Request.QueryString["date"] != null)
       {
           dtDate = Convert.ToDateTime(Request.QueryString["date"]);
       }

       List<GetPurchaseSellBalanceByDateResult> lstPurchaseSellBalanceList = CBusinessManagement.GetPurchaseSellBalanceByDate(dtDate);

       ReportDataSource oReportDataSource = new ReportDataSource("GetPurchaseSellBalanceByDateResult", lstPurchaseSellBalanceList);

       ReportViewer1.DocumentMapCollapsed = true;
       ReportViewer1.DocumentMapWidth = Unit.Percentage(100);
       ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "\\Reports\\PurchaseSellBalanceReport.rdlc";
       ReportViewer1.LocalReport.ReportEmbeddedResource = "PurchaseSellBalanceReport.rdlc";
       ReportViewer1.LocalReport.DataSources.Add(oReportDataSource);
       

   }
}