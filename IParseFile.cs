using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIProducts
{
    public interface IPasrseFile<T>
        where T : class
     
    {
         Dictionary<System.String, T> ParseProductsFile(string FileName);

    }
}
