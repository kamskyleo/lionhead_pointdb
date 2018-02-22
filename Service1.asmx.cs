using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace LocateMe
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string InsertLocationPostgres(string pntname, float latstr, float longstr)
        {
            try
            {


                NpgsqlTypes.NpgsqlPoint point = new NpgsqlTypes.NpgsqlPoint(latstr, longstr);

                using (var con = new NpgsqlConnection(
                    "Server=127.0.0.1;Port=5432;Database=lionhead_pointdb;User Id=lionhead;Password=Manager10;"))
                using (var cmd = new NpgsqlCommand(
                    "INSERT INTO public.geopoint (pntid,pntname,latlong,dttime)"
                    + "VALUES(nextval('pntid_seq'::regclass), @pntname  , @point ,current_timestamp );", con))

                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@pntname", NpgsqlTypes.NpgsqlDbType.Varchar, pntname);
                    cmd.Parameters.AddWithValue("@point", NpgsqlTypes.NpgsqlDbType.Point, point);

                    cmd.ExecuteNonQuery();
                }
                return "Record Inserted Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    

    [WebMethod]
    public string InsertLocationMssql(string pntname, float latstr, float longstr)
    {
        try
        {
 

            using (var con = new SqlConnection(
                "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFileName =|DataDirectory|\\Database1.mdf;Integrated Security = True;MultipleActiveResultSets = True"))
            using (var cmd = new SqlCommand(
                "INSERT INTO geopoint (pntname,lat,long,dttime)VALUES(@pntname  , @lat,@long,GETDATE() );", con))

            {
                con.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@pntname",  pntname);
                cmd.Parameters.AddWithValue("@lat", latstr);
                cmd.Parameters.AddWithValue("@long", longstr);
                cmd.ExecuteNonQuery();
            }
            return "Record Inserted Successfully";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
}
