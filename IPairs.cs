using System.Collections.Generic;

namespace Minifier
{
    public interface IPairs<TRegex, TString>
    {
        List<TString> Replaces { get; set; }
        List<TRegex> Regexes { get; set; }
        void ReleaseUnmanagedResources();
    }
}