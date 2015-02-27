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
        public void wkat(string pth)
        {
            StolowkaDS DS = new StolowkaDS();
            StolowkaDSTableAdapters.WkatTableAdapter a = new StolowkaDSTableAdapters.WkatTableAdapter();
            DS.Wkat.Rows.Clear();
            a.Fill(DS.Wkat);
            string komm;
            try
            {
                string connStr = @"Provider=vfpoledb;Data Source=" + pth.Substring(0, pth.LastIndexOf("WKAT.DBF")) + ";Collating Sequence=machine;";

                OleDbConnection conn = new OleDbConnection(connStr);
                conn.Open();

                string cmd_string = "select * from " + pth.Substring(pth.LastIndexOf("WKAT.DBF"));

                Console.WriteLine(cmd_string);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd_string, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable dt = ds.Tables[0];

                komm = "";
                foreach (DataRow dr in dt.AsEnumerable())
                {
                    StolowkaDS.WkatRow r = DS.Wkat.NewWkatRow();
                    r.IN = (string)dr[0];   //kod produktu
                    r.NA = (string)dr[3];   //nazwa produktu
                    DS.Wkat.Rows.Add(r);
                }
                DS.AcceptChanges();
            }
            catch (Exception ex)
            {
                komm = pth + "\n" + ex.Message;
            }
        }

        public void wdow(string pth)
        {

            StolowkaDS DS = new StolowkaDS();
            StolowkaDSTableAdapters.WdowTableAdapter a = new StolowkaDSTableAdapters.WdowTableAdapter();
            a.Fill(DS.Wdow);
            DS.Wdow.Rows.Clear();
            string komm;
            
            try
            {
                string connStr = @"Provider=vfpoledb;Data Source=" + pth.Substring(0, pth.LastIndexOf("WDOW.DBF")) + ";Collating Sequence=machine;";
                OleDbConnection conn = new OleDbConnection(connStr);
                conn.Open();

                string cmd_string = "select * from " + pth.Substring(pth.LastIndexOf("WDOW.DBF"));
                OleDbDataAdapter da = new OleDbDataAdapter(cmd_string, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable dt = ds.Tables[0];

                komm = "";
                foreach (DataRow dr in dt.AsEnumerable())
                {
                    StolowkaDS.WdowRow r = DS.Wdow.NewWdowRow();
                    r.MG = (int)dr[0];                      //numer magazynu
                    r.SD = (int)dr[1];                      //kartoteka magazynowa
                    r.IN = (string)dr[8];                   //kod produktu
                    r.JM = (string)dr[10];                  //jednostka miary
                    r.CE = (float)dr[11];                   //cena
                    r.IL = (int)dr[12];                     //ilosc
                    r.WAR = (float)r.IL * r.CE;             //laczna wartosc
                    r.DD = DateTime.Parse((string)dr[5]);   //data
                    DS.Wdow.Rows.Add(r);
                    //Console.WriteLine("\n\n\n***\n\n\nDziala\n\n\n***\n\n\n");
                }
                DS.AcceptChanges();
            }
            catch (Exception ex)
            {
                komm = pth + "\n" + ex.Message;
            }
        }

        public void laczProdukty()
        {
            this.wkat("D:\\Dropbox\\IO\\Projekt\\StolowkaIO\\WpfApplication1\\WKAT.DBF");
            this.wdow("D:\\Dropbox\\IO\\Projekt\\StolowkaIO\\WpfApplication1\\WDOW.DBF");

            StolowkaDS ds = new StolowkaDS();
            StolowkaDSTableAdapters.WkatTableAdapter ad = new StolowkaDSTableAdapters.WkatTableAdapter();

            ad.Fill(ds.Wkat);

            StolowkaDSTableAdapters.WdowTableAdapter dd = new StolowkaDSTableAdapters.WdowTableAdapter();

            dd.Fill(ds.Wdow);

            StolowkaDSTableAdapters.ProduktTableAdapter pta = new StolowkaDSTableAdapters.ProduktTableAdapter();

            pta.Fill(ds.Produkt);

            ds.Produkt.Rows.Clear();

            StolowkaDSTableAdapters.WydaneTableAdapter wta = new StolowkaDSTableAdapters.WydaneTableAdapter();

            wta.Fill(ds.Wydane);

            ds.Wydane.Rows.Clear();
            int tempId;
            foreach (StolowkaDS.WdowRow r in ds.Wdow.Rows)
            {
                StolowkaDS.WkatRow t = (StolowkaDS.WkatRow)ds.Wkat.Select("IN = '" + r.IN + "'").First();
                pta.Insert(t.NA, r.JM, (double)r.CE, (int)r.SD, (int)r.MG);
                pta.Fill(ds.Produkt);
                tempId = ds.Produkt.Max(p => p.produkt_id);
                wta.Insert(tempId, r.DD, (int)r.IL);
            }
        }
    }
}
