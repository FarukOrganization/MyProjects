using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;
using ParameterManagment;
using DALManagment;
using System.Data;


public partial class Reports_Reporttest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet oDataSet=new DataSet();
        DataTable oDataTable=new DataTable();
        oDataSet.Tables.Add(oDataTable);

        List<GetAllCurrencyInformationResult> lstAllCurrencyInformationList = CCurrencyInformationManagement.GetAllCurrency();

        ReportDataSource oReportDataSource = new ReportDataSource("DataSet2_GetAllCurrencyInformation", lstAllCurrencyInformationList);

        ReportViewer1.DocumentMapCollapsed = true;
        ReportViewer1.DocumentMapWidth = Unit.Percentage(100);
        ReportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "\\Reports\\Report.rdlc";
        ReportViewer1.LocalReport.ReportEmbeddedResource = "Report.rdlc";
        ReportViewer1.LocalReport.DataSources.Add(oReportDataSource);
        
    }
}
