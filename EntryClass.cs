using System;
using System.Collections.Generic;
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
        private (int rPosition, int ePosition) ExtractEAndR(string[] args)
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
                    return (Array.IndexOf<string>(args, eArgument), Array.IndexOf<string>(args, rArguments));
                }
                
            }
            catch (Exception)
            {
                throw;
            }
            return (-1, -1);
        }
        /// <summary>
        /// Extrecting arguments from default args in main function
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private (string[] files, Regex[] newRegexes, string[] newReplaces) ExtractArguments(string[] args)
        {
            (int rPosition, int ePosition) = (-1, -1);
            List<string> files = new List<string>();
            List<Regex> newRegexes = new List<Regex>();
            List<string> newReplaces = new List<string>();
            if (!(args.Length > 0) || args == null)
            {
                throw new Exception("Arguments must be supplied");
            }

            var fArgument = args.First(f => f == Arguments[0]);
            if( fArgument.Length != 1 )
            {
                throw new ArgumentNotSuppliedException();
            }
            else
            {
                var fPosition = Array.IndexOf(args,fArgument);
                (rPosition, ePosition) = ExtractEAndR(args);
                #region Error
                //if( rPosition != -1 )
                //{
                //    if (ePosition != -1)
                //    {
                //        var smaller = (rPosition > ePosition) ? ePosition : rPosition;
                //        var greater = (rPosition > ePosition) ? rPosition : ePosition;
                //        //Return files, newRegexes and newReplaces and convert them to arrays and clear all Lists
                //    }
                //    else
                //    {
                //        var filesCount = rPosition - fPosition;
                //        while (fPosition < filesCount)
                //        {
                //            files.Add(args[++fPosition]);
                //        }
                //        //retrun files and newRegexes
                //    }
                //}
                //else
                //{
                //    while(fPosition < args.Length)
                //    {
                //        files.Add(args[++fPosition]);
                //    }
                //    //Retrun files with all null
                //}
                #endregion
                //If -r and -e argument are not the same lenght or one of them is not supplied trow an error
                if( rPosition != -1 && ePosition != -1 && rPosition == ePosition)
                {
                    // TODO - if argument are supplied, then convert all Lists into arrays and return them 
                }
                //TODO - Else: return -r -e nulls with just files (-f)
            }
            //implement
            throw new NotImplementedException();
            
        }

        private static void Main(string[] args)
        {
            var entry = new EntryClass();
            if (args.Length > 0)
            {
                var extracted = entry.ExtractArguments(args);
            }
            
        }
    }
}