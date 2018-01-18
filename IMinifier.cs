using System;
using System.Threading.Tasks;

namespace Minifier
{
    public interface IMinifier
    {
        string RemoveNewLines();
        Task<string> AsyncRemoveNewLines();
    }
}