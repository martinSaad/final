using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;

namespace final.Models
{

    public class PutRequest
    {
        public static bool makeRequest(string targetClassName, string targetObjectId,string addedColumnName, string addedClassName, string addedObjectId)
        {
            // Create a request using a URL that can receive a post. 
            string url = buildUrl(targetClassName, targetObjectId);
            WebRequest request = WebRequest.Create(url);
            // Set the Method property of the request to POST.
            request.Method = "PUT";

            // Create POST data and convert it to a byte array.
            objects objects = new objects();
            objects.clsassName = addedClassName;
            objects.objectId = addedObjectId;

            products users = new products();
            users.objects.Add(objects);

            request requestObject = new request();
            requestObject.products = users;


            //string postDataJSON = JsonConvert.SerializeObject(requestObject);
            string postDataJSON = new JavaScriptSerializer().Serialize(requestObject);
            postDataJSON = postDataJSON.Replace(@"\", "");
            byte[] byteArray = null;
            if (postDataJSON!= null)
            {
                byteArray = Encoding.UTF8.GetBytes(postDataJSON);
            }


            // Set headers
            request.ContentType = "application/json";
            request.Headers.Add(Constants.PARSE_HEADER_APPLICATION_ID, Constants.APPLICATION_ID);
            request.Headers.Add(Constants.PARSE_HEADER_API_KEY, Constants.API_KEY);

            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.

            WebResponse response = null;
            StreamReader reader = null;
            try
            {
                response = request.GetResponse();
                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
            }
            catch (WebException e)
            {
                //add log
                return false;
                throw e;
            }
            finally
            {
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            return true;
        }

        public static string buildUrl(string targetClassName, string targetObjectId)
        {
            var builder = new UriBuilder(Constants.PARSE_URL);
            string url = builder.Uri.ToString();
            url = url + "/" + targetClassName + "/" + targetObjectId;

            return url;
        }


    }
    //json request
    public class request
    {
       public products products { get; set; }
    }
    public class products
    {
        public string __op = "AddRelation";
        public List<objects> objects = new List<objects>();
    }

    public class objects
    {
        public string __type = "Pointer";
        public string clsassName;
        public string objectId;
    }
}