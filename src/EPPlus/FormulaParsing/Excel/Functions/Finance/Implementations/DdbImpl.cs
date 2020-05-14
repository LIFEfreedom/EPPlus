﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeOpenXml.FormulaParsing.Excel.Functions.Finance.Implementations
{
    internal static class DdbImpl
    {
        internal static FinanceCalcResult Ddb(double Cost, double Salvage, double Life, double Period, double Factor = 2.0)
        {
            double dRet;
            double dTot;
            double dExcess;
            double dTemp;
            double dNTemp;

            if(Factor <= 0d || Salvage < 0d || Period <= 0d || Period > Life)
            {
                return new FinanceCalcResult(eErrorType.Value);
            }

            if (Cost <= 0)
                return new FinanceCalcResult(0.0d);

            if(Life < 2d)
            {
                return new FinanceCalcResult(Cost - Salvage);
            }

            if(Life == 2d && Period > 1d)
            {
                return new FinanceCalcResult(0d);
            }

            if(Life == 2d && Period <= 1d)
            {
                return new FinanceCalcResult(Cost - Salvage);
            }

            if(Period <= 1d)
            {
                dRet = Cost * Factor / Life;
                dTemp = Cost - Salvage;
                if (dRet > dTemp)
                    return new FinanceCalcResult(dTemp);
                else
                    return new FinanceCalcResult(dRet);
            }

            //   Perform the calculation
            dTemp = (Life - Factor) / Life;
            dNTemp = Period - 1.0;

            //   WARSI Using the exponent operator for pow(..) in C code of DDB. Still got
            //   to make sure that they (pow and ^) are same for all conditions
            dRet = Factor * Cost / Life * System.Math.Pow(dTemp, dNTemp);

            //   WARSI Using the exponent operator for pow(..) in C code of DDB. Still got
            //  to make sure that they (pow and ^) are same for all conditions
            dTot = Cost * (1 - System.Math.Pow(dTemp, Period));
            dExcess = dTot - Cost + Salvage;

            if(dExcess > 0d)
            {
                dRet = dRet - dExcess;
            }

            if(dRet >= 0d)
            {
                return new FinanceCalcResult(dRet);
            }
            return new FinanceCalcResult(0d);
        }
    }
}