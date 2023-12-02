using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //Params verilince IResult Runa istediğimiz kadar parametre verebiliyoruz
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success )
                {
                    //Başarısız olanları Business tarafına döndürüyoruz.
                    return logic;
                }
            }
            return null;
        }
    }
}
