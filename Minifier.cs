using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Minifier
{
    public class Minifier : IDisposable, IMinifier
    {
        #region Fields
        private readonly Pairs<Regex, string> _pairs = new Pairs<Regex, string>()
        {
            // Regexes for checking the css document
            Regexes =
            {
                new Regex(@"\s?\{\s+"),
                new Regex(@";\s+"),
                new Regex(@"\s>\s"),
                new Regex(@"\}\s+"),
                new Regex(@":\s+?"),
                new Regex(@",\s+?"),
                new Regex(@"\s+?\+\s+?"),
                new Regex(@"@media\s+")
            },
            //String to replace the maches
            Replaces =
            {
                "{",";",">","}",":",",","+","@media"
            }
        };
        #endregion
        #region Propeties
        public FileStream File { get; set; }
        public string Path { get; set; }
        public FileStream MinifiedFile { get; private set; }
        public Pairs<Regex,string> Pairs
        {
            get => _pairs;
        }
        
        #endregion
        #region Contrutors
        //Simple constructor without additional Regex for maching
        public Minifier(string pathToFile)
        {
            Path = pathToFile;
            File = new FileStream(pathToFile, FileMode.Open);
        }
        public Minifier(string pathToFile, IEnumerable<Regex> regexes, IEnumerable<string> replaces)
        {
            foreach (var reg in regexes)
            {
                Pairs.Regexes.Add(reg);
            }
            foreach (var replase in replaces)
            {
                Pairs.Replaces.Add(replase);
            }
            File = new FileStream(pathToFile, FileMode.Open);
            Path = pathToFile;
            File.Close();
        }
        #endregion
        #region Methods
        /// <summary>
        /// Using (string).Replace function to remove all \n or \r\n 
        /// </summary>
        /// <returns>File without new lines</returns>
        /// <exception cref="NotImplementedException"></exception>
        private string RemoveNewLines()
        {
            var reg = new Regex(@"\r\n");
            return (reg.IsMatch(Path)) ? Path.Replace("\r\n", "") : Path.Replace("\n", "");
        }

        public void Minify()
        {
            RemoveNewLines();
            if(Pairs.Regexes.Count == Pairs.Replaces.Count)
            {
                var count = Pairs.Regexes.Count;
                var regexes = Pairs.Regexes;
                var replaces = Pairs.Replaces;
                for(var i = 0; i < count; i++)
                {
                    if (regexes[i].IsMatch(Path))
                    {
                        Path = regexes[i].Replace(Path, replaces[i]);
                    }
                }
            }
        }
        #endregion 
        /// <summary>
        /// Disposing Resourses
        /// </summary>
        public void Dispose()
        {
            MinifiedFile?.Dispose();
            File?.Dispose();
            Pairs.Dispose();
        }
    }

}