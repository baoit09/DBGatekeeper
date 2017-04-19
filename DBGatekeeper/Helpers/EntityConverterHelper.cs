using DBGatekeeper.Plugin;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Hosting;

namespace DBGatekeeper.Helpers
{
    public class EntityConverterHelper
    {
        public Hashtable Convert(Hashtable srcEntity, string sEntityType)
        {
            string binPath = GetBinDirectory();
            string pluginFolder = Path.Combine(binPath, "Plugins");

            DirectoryInfo di = new DirectoryInfo(pluginFolder);

            if (!di.Exists)
                return srcEntity;

            FileInfo fi = di.GetFiles().FirstOrDefault();

            if (!fi.Exists)
                return srcEntity;

            Assembly assembly = Assembly.LoadFrom(fi.FullName);

            Type assignTypeFrom = null;

            if (sEntityType == "Patient")
            {
                assignTypeFrom = typeof(IPatientConverter);
            }

            Type convertType = assembly.GetTypes().Where(t => assignTypeFrom.IsAssignableFrom(t)).FirstOrDefault();

            IPatientConverter patientConverter = (IPatientConverter)Activator.CreateInstance(convertType);

            return patientConverter.Convert(srcEntity);
        }

        private string GetBinDirectory()
        {
            if (HostingEnvironment.IsHosted)
            {
                //hosted
                return HttpRuntime.BinDirectory;
            }

            //not hosted. For example, run either in unit tests
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}