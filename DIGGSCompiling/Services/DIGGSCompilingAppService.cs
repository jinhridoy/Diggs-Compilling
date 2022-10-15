using DIGGSCompiling.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DIGGSCompiling.Services
{
    public class DIGGSCompilingAppService : IDIGGSCompilingAppService
    {
        public string Compiling (string body)
        {
            // Try to decode request and parse the XML string
            XmlDocument doc = new XmlDocument();
            try
            {
                byte[] textBytes = Convert.FromBase64String(body);
                string xmlRequest = Encoding.UTF8.GetString(textBytes);
                doc.LoadXml(xmlRequest);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to parse request. " + ex.Message);
            }

            ExtractProject(doc);

            return body;
        }


        public object ExtractProject (XmlDocument xmlDoc)
        {
            var projects = new List<object>();
            var boreholes = new List<object>();
            var projectTests = new List<object>();
            var wellInfos = new List<object>();
            var stratigraphy = new List<object>();
            var samplingActivities = new List<object>();
            var fieldTests = new List<object>();
            var labTests = new List<object>();
            var propertiesArray = new List<object>();

            //Array of all project tags in the XML
            var projectTagsArray =  xmlDoc.GetElementsByTagName("project");

            if (projectTagsArray[0] == null)
            {
                throw new Exception("Cannot display Project data, no Project tag found in input DIGGS file.");
            }

            //const skipProperties = (obj) => {
            //    var keys = Object.keys(obj);
            //    var returnObj = { };
            //    var skipProperties = ["Boreholes", "Tests", "SamplingActivities", "Stratigraphy", "FieldTests", "WellInfos"];
            //    $.each(keys, (i, item) => {
            //        if (!skipProperties.includes(item))
            //        {
            //            returnObj[item] = obj[item];
            //        }
            //    });

            //    return returnObj;
            //};

            for (int i = 0; i < projectTagsArray.Count; i++)
            {
                var projectNumber = i + 1;
                var projectObj = new {};

                var projectNode = projectTagsArray[i];

                var projectID = projectNode
                    .SelectSingleNode("Project").Attributes.GetNamedItem("gml:id");


            }


            return new
            {
                Projects = projects,
                Boreholes = boreholes,
                ProjectTests = projectTests,
                WellInfos = wellInfos,
                Stratigraphy = stratigraphy,
                SamplingActivities = samplingActivities,
                FieldTests = fieldTests,
                LabTests = labTests,
                PropertiesArray = propertiesArray,
            };
        }
    }
}
