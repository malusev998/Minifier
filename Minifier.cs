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
        }
        #endregion
        #region Methods
        /// <summary>
        /// Using (string).Replace function to remove all \n or \r\n 
        /// </summary>
        /// <returns>File without new lines</returns>
        /// <exception cref="NotImplementedException"></exception>
        public string RemoveNewLines()
        {
            throw new NotImplementedException();
        }
        #endregion 
        #region Async Methods
        /// <inheritdoc />
        /// <summary>
        /// Using (string).Replace function to remove all \n or \r\n asyncly
        /// </summary>
        /// <returns>File without new lines</returns>
        /// <exception cref="T:System.NotImplementedException"></exception>
        public async Task<string> AsyncRemoveNewLines()
        {
            throw new NotImplementedException();
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