using System;
using System.Collections.Generic;

namespace Minifier
{
    public class Pairs<TRegex, TString> : IDisposable, IPairs<TRegex, TString>
    {
        public List<TString> Replaces { get; set; }
        public List<TRegex> Regexes { get; set; }

        public void ReleaseUnmanagedResources()
        {
            Replaces.Clear();
            Regexes.Clear();
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
        }


        ~Pairs()
        {
            ReleaseUnmanagedResources();
        }
    }
}