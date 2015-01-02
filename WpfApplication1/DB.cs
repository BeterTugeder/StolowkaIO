using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;



namespace Stolowka
{
    class DB
    {
        public void wkat(string pth, string kat)
        {

            StolowkaDS DS = new StolowkaDS();
            StolowkaDSTableAdapters.WkatTableAdapter a = new StolowkaDSTableAdapters.WkatTableAdapter();
            DS.Wkat.Rows.Clear();
            a.Fill(DS.Wkat);
            string komm;
            try
            {
                string connStr = @"Provider=vfpoledb;Data Source=" + pth.Substring(0, pth.LastIndexOf(kat)) + ";Collating Sequence=machine;";
                OleDbConnection conn = new OleDbConnection(connStr);
                conn.Open();

                string cmd_string = "select * from " + pth.Substring(0, pth.LastIndexOf("WKAT.DBF"));
                OleDbDataAdapter da = new OleDbDataAdapter(cmd_string, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable dt = ds.Tables[0];

                komm = "";
                foreach (DataRow dr in dt.AsEnumerable())
                {
                    StolowkaDS.WkatRow r = DS.Wkat.NewWkatRow();
                    r.IN = (string)dr[0];   //kod produktu
                    r.NA = (string)dr[3];   // nazwa produktu
                    DS.Wkat.Rows.Add(r);
                }
                DS.AcceptChanges();
            }
            catch (Exception ex)
            {
                komm = pth + "\n" + ex.Message;
            }
        }

        public void wdow(string pth, string kat)
        {

            StolowkaDS DS = new StolowkaDS();
            StolowkaDSTableAdapters.WdowTableAdapter a = new StolowkaDSTableAdapters.WdowTableAdapter();
            DS.Wdow.Rows.Clear();
            a.Fill(DS.Wdow);
            string komm;
            try
            {
                string connStr = @"Provider=vfpoledb;Data Source=" + pth.Substring(0, pth.LastIndexOf(kat)) + ";Collating Sequence=machine;";
                OleDbConnection conn = new OleDbConnection(connStr);
                conn.Open();

                string cmd_string = "select * from " + pth.Substring(0, pth.LastIndexOf("WDOW.DBF"));
                OleDbDataAdapter da = new OleDbDataAdapter(cmd_string, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable dt = ds.Tables[0];

                komm = "";
                foreach (DataRow dr in dt.AsEnumerable())
                {
                    StolowkaDS.WdowRow r = DS.Wdow.NewWdowRow();
                    r.MG = (int)dr[0];   //numer magazynu
                    r.SD = (int)dr[1];   //kartoteka magazynowa
                    r.IN = (string)dr[8];  //kod produktu
                    r.JM = (string)dr[10];   //jednostka miary
                    r.CE = (float)dr[11];   //cena
                    r.IL = (int)dr[12];    //ilosc
                    r.WAR = (float)r.IL * r.CE;  //laczna wartosc
                    DS.Wdow.Rows.Add(r);
                }
                DS.AcceptChanges();
            }
            catch (Exception ex)
            {
                komm = pth + "\n" + ex.Message;
            }
        }

    }
}
