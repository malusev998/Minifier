using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Minifier
{
    internal class EntryClass
    {
        /// <summary>
        ///  -f for files
        ///  -e regular expresions
        ///  -r replace strings
        /// </summary>
        private static string[] Arguments = new[]
        {
            "-f", "-e", "-r"
        };
        /// <summary>
        /// Extrecting arguments from default args in main function
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static (string[] files, Regex[] newRegexes, string[] newReplaces) ExtractArguments(string[] args)
        {
            if (!(args.Length > 0) || args == null)
            {
                throw new Exception("Arguments must be supplied");
            }

            var fArgument = args.First(f => f == Arguments[0]);
            if( fArgument.Length != 1 )
                throw new ArgumentNotSuppliedException();
            else
            {
                var fPosition = Array.IndexOf(args,fArgument);
                ExtractEAndR();
            }

            #region Extract E and R
            
            void ExtractEAndR()
            {
                try
                {
                    var eArgument = args.First(e => e == Arguments[1]);
                    var rArguments = args.First(r => r == Arguments[2]);
                    if (eArgument.Length == 1 && rArguments.Length == 1)
                    {
                        //Get Positions
                        var ePosition = Array.IndexOf(args, eArgument);
                        var rPosition = Array.IndexOf(args, rArguments);
                        
                    }
                }
                catch (Exception)
                {
                }
                
            }
            #endregion
            throw new NotImplementedException();
        }
        private static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                var extracted = ExtractArguments(args);
            }
            
        }
    }
}