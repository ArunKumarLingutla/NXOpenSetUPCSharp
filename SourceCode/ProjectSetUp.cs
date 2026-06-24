using NXOpen;
using NXOpen.UF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXOpenSetUPCSharp
{
    public class ProjectSetUp
    {
        private static Session _session;
        private static UFSession _ufSession;
        private static Part _workPart;
        private static Part _displayPart;

        public static Session theSession
        {
            get
            {
                if (_session == null)
                    _session = Session.GetSession();

                return _session;
            }
        }

        public static UFSession UFSession
        {
            get
            {
                if (_ufSession == null)
                    _ufSession = UFSession.GetUFSession();

                return _ufSession;
            }
        }
        public static Part workPart
        {
            get
            {
                if (_workPart == null)
                    _workPart = theSession.Parts.Work;

                return _workPart;
            }
        }

        public static Part displayPart
        {
            get
            {
                if (_displayPart == null)
                    _displayPart = theSession.Parts.Display;

                return _displayPart;
            }
        }

        /// <summary>
        /// Refreshes the references to the current work and display parts in the session.
        /// </summary>
        /// <remarks>Call this method to ensure that subsequent operations use the latest work and display
        /// parts from the session. This is useful if the active parts may have changed since the last reference was
        /// obtained.</remarks>
        public static void Refresh()
        {
            _workPart = theSession.Parts.Work;
            _displayPart = theSession.Parts.Display;
        }

        /// <summary>
        /// Initializes the tool by configuring input and output directories and setting up logging.
        /// </summary>
        /// <remarks>This method ensures that the output directory exists, creating it if necessary or
        /// clearing its contents if it already exists. It also initializes the logging system and records the paths of
        /// the input and output directories. Call this method before performing any operations that depend on the
        /// tool's directory structure or logging.</remarks>
        public static void InitializeTool()
        {
            string BaseDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            ProjectVariables.InputDirectory = Path.Combine(BaseDirectory, "Input");
            ProjectVariables.OutputDirectory = Path.Combine(BaseDirectory, "Output");

            if (!Directory.Exists(ProjectVariables.OutputDirectory))
            {
                Directory.CreateDirectory(ProjectVariables.OutputDirectory);
            }
            else
            {
                FileManager.DeleteFilesInDirectory(ProjectVariables.OutputDirectory);
            }
            NXLogger.Init(System.IO.Path.Combine(ProjectVariables.OutputDirectory, "NXLog"), true, true);
            NXLogger.Instance.Log("Tool initialized with input directory: " + ProjectVariables.InputDirectory, LogLevel.Info);
            NXLogger.Instance.Log("Output directory set to: " + ProjectVariables.OutputDirectory, LogLevel.Info);
        }
    }
}
