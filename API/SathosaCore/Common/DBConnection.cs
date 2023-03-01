﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Common
{
    [Serializable()]
    public class DBConnection : IDisposable
    {
        [NonSerialized]
        //public OdbcConnection con;
        public SqlConnection con;
        [NonSerialized]
        //public OdbcCommand cmd;
        public SqlCommand cmd;
        [NonSerialized]
        public SqlTransaction tr;
        //public OdbcTransaction tr;
        [NonSerialized]
        public SqlDataReader dr;
        //public OdbcDataReader dr;

        public DBConnection()
        {
            //con = new OdbcConnection(System.Configuration.ConfigurationSettings.AppSettings["dbConString"].ToString());
            //cmd = new OdbcCommand();
            con = new SqlConnection("Data Source=119.235.4.29;Initial Catalog=CEAT;User ID=sa;Password=Bell123");
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            try
            {
                this.con.Open();
                this.tr = con.BeginTransaction();
                this.cmd.Transaction = tr;
            }
            catch (Exception ex)
            {
                this.RollBack();
            }
        }

        public void Commit()
        {
            this.cmd.Dispose();
            if (this.dr != null)
                this.dr.Close();
            tr.Commit();
            this.con.Close();
        }
        public void RollBack()
        {
            //this.tr.Rollback();
            this.cmd.Dispose();
            this.con.Close();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }


        //[NonSerialized]
        ////public OdbcConnection con;
        //public OdbcConnection con;
        //[NonSerialized]
        ////public OdbcCommand cmd;
        //public OdbcCommand cmd;
        //[NonSerialized]
        //public OdbcTransaction tr;
        ////public OdbcTransaction tr;
        //[NonSerialized]
        //public OdbcDataReader dr;
        ////public OdbcDataReader dr;

        //public DBConnection()
        //{
        //    //con = new OdbcConnection(System.Configuration.ConfigurationSettings.AppSettings["dbConString"].ToString());
        //    //cmd = new OdbcCommand();
        //    con = new OdbcConnection(System.Configuration.ConfigurationSettings.AppSettings["dbConString"].ToString());
        //    cmd = new OdbcCommand();
        //    cmd.Connection = con;
        //    cmd.CommandType = CommandType.Text;
        //    try
        //    {
        //        this.con.Open();
        //        this.tr = con.BeginTransaction();
        //        this.cmd.Transaction = tr;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.RollBack();
        //    }
        //}
        //public void Commit()
        //{
        //    this.cmd.Dispose();
        //    if (this.dr != null)
        //        this.dr.Close();
        //    tr.Commit();
        //    this.con.Close();
        //}
        ///*   public void Commit()
        //   {
        //       tr.Commit();
        //       this.cmd.Dispose();
        //       this.con.Close();
        //   }*/
        //public void RollBack()
        //{
        //    this.tr.Rollback();
        //    this.cmd.Dispose();
        //    this.con.Close();
        //}
        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
