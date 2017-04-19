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
        private IPatientConverter patientConverter = null;
        private IStudyConverter studyConverter = null;

        public Hashtable Convert(Hashtable srcEntity, string sEntityType)
        {
            try
            {
                string binPath = GetBinDirectory();
                string pluginFolder = Path.Combine(binPath, "Plugins");

                DirectoryInfo di = new DirectoryInfo(pluginFolder);

                if (di == null || !di.Exists)
                    return srcEntity;

                FileInfo fi = di.GetFiles().FirstOrDefault();

                if (fi == null || !fi.Exists)
                    return srcEntity;

                Assembly assembly = Assembly.LoadFrom(fi.FullName);

                Type assignTypeFrom = null;

                if (sEntityType == "Patient")
                {
                    if (patientConverter == null)
                    {
                        assignTypeFrom = typeof(IPatientConverter);
                        Type convertType = assembly.GetTypes().Where(t => assignTypeFrom.IsAssignableFrom(t)).FirstOrDefault();
                        if (convertType == null)
                            return srcEntity;
                        patientConverter = (IPatientConverter)Activator.CreateInstance(convertType);
                    }

                    return patientConverter.Convert(srcEntity);
                }
                else
                {
                    if (studyConverter == null)
                    {
                        assignTypeFrom = typeof(IStudyConverter);
                        Type convertType = assembly.GetTypes().Where(t => assignTypeFrom.IsAssignableFrom(t)).FirstOrDefault();
                        if (convertType == null)
                            return srcEntity;
                        studyConverter = (IStudyConverter)Activator.CreateInstance(convertType);
                    }

                    return studyConverter.Convert(srcEntity);
                }
            }
            catch (Exception ex)
            {
                return srcEntity;
            }
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