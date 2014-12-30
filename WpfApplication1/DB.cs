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
                    r.IN = dr[0];
                    r.NA = dr[3];
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
                    r.MG = dr[0];
                    r.SD = dr[1];
                    r.IN = dr[8];
                    r.JM = dr[10];
                    r.CE = dr[11];
                    r.IL = dr[12];
                    r.WAR = r.IL * r.CE;  
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
