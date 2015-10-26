using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class googlemap_test12_6 : System.Web.UI.Page, System.Web.UI.ICallbackEventHandler
{
    string returnValue;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            data_conn cn = new data_conn();
            DataSet ds = cn.mdb_ds("select * from TB_ToPort", "port");
            Repeater1.DataSource = ds.Tables["port"].DefaultView;
            Repeater1.DataBind();
        }
    }

    public string GetCallbackResult()
    {
        try
        {

            string[] stringArray = returnValue.Split('^');
            if (stringArray[0] == "search")
            {
                returnValue = stringArray[1];
                double distance = 0;
                string[] pointArray = returnValue.Split('|');

                data_conn cn = new data_conn();
                DataSet ds = cn.mdb_ds("select * from TB_ToPort", "port");

                point[] destinationPoint = new point[3];
                point departurePoint = new point(Convert.ToString(pointArray[2]), Convert.ToDouble(pointArray[0]), Convert.ToDouble(pointArray[1]));

                for (int i = 0; i < ds.Tables["port"].Rows.Count; i++)//destinationPoint
                {
                    point tempPoint = new point(Convert.ToString(ds.Tables["port"].Rows[i]["toPort"]), Convert.ToDouble(ds.Tables["port"].Rows[i]["latitude"]), Convert.ToDouble(ds.Tables["port"].Rows[i]["longitude"]));

                    for (int j = 0; j < destinationPoint.Length; j++)
                    {
                        if (destinationPoint[j] == null || Fun_GetDistance(departurePoint, tempPoint) < Fun_GetDistance(destinationPoint[j], departurePoint))
                        {

                            for (int k = destinationPoint.Length - 1; k > j; k--)
                            {
                                destinationPoint[k] = destinationPoint[k - 1];
                            }
                            destinationPoint[j] = tempPoint;
                            break;
                        }
                    }
                }

                returnValue = "";

                for (int i = 0; i < destinationPoint.Length; i++)
                {
                    returnValue += destinationPoint[i].lat + "|" + destinationPoint[i].lng + "|" + destinationPoint[i].place;
                    //returnValue += destinationPoint[i].place;
                    if (i != destinationPoint.Length - 1)
                    {
                        returnValue += "$";
                    }
                }

                return returnValue;
            }
            else
            {
                return "";
            }

        }
        catch
        {
            return "";
        }
    }

    public void RaiseCallbackEvent(String eventArgument)
    {
        returnValue = eventArgument; //客户端传递来的值不作处理
    }

    public double Fun_Rad(double d)
    {
        return d * Math.PI / 180.0;
    }

    public double Fun_GetDistance(point point1, point point2)
    {
        double lat1, lng1, lat2, lng2;
        lat1 = point1.lat;
        lng1 = point1.lng;
        lat2 = point2.lat;
        lng2 = point2.lng;
        double d_EarthRadius = 6378.137;
        double radLat1 = Fun_Rad(lat1);
        double radLat2 = Fun_Rad(lat2);
        double radLat = Fun_Rad(lat1) - Fun_Rad(lat2);
        double radLng = Fun_Rad(lng1) - Fun_Rad(lng2);
        double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(radLat / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(radLng / 2), 2)));
        s = s * d_EarthRadius;
        s = Math.Round(s * 10000) / 10000;
        return s;
    }





    protected void Button2_Click(object sender, EventArgs e)
    {
        data_conn cn = new data_conn();
        string[] tempArray = hidaddPort.Value.Split('|');
        if (tempArray[2] != "")
        {
            DataSet ds = cn.mdb_ds("select * from TB_ToPort where toPort='" + tempArray[2] + "' or (latitude=" + tempArray[0] + " and longitude=" + tempArray[1] + ")", "port");
            if (ds.Tables["port"].Rows.Count == 0)
            {
                cn.mdb_exe("insert into TB_ToPort (toPort,latitude,longitude) values ('" + tempArray[2] + "'," + tempArray[0] + "," + tempArray[1] + ")");
            }
        }
        
    }
}
public class point
{
    public string place;
    public double lat;
    public double lng;
    public point(string place, double lat, double lng)
    {
        this.place = place;
        this.lat = lat;
        this.lng = lng;
    }

    public point(double lat, double lng)
    {
        this.place = "";
        this.lat = lat;
        this.lng = lng;
    }


}