﻿using KlazzRelationShipFinder.KRSFinder.Base;
using KlazzRelationShipFinder.KRSFinder.Module;
using KlazzRelationShipFinder.KRSFinder.Module.Smali;

namespace KlazzRelationShipFinder.KRSFinder.Handler
{
    class ArrayOpCodeHandler : IBaseHandler
    {
        /// <summary>
        /// 处理array操作码
        /// </summary>
        /// <param name="lineCode">NEED</param>
        /// <param name="smaliFileAnalyseModule">NONEED</param>
        /// <param name="tempRegister">NEED</param>
        /// <returns>NULL</returns>
        public object lineHandler(string lineCode, SmaliFileAnalyseModule smaliFileAnalyseModule = null, TempRegisterMap tempRegister = null)
        {
            string head = lineCode.Split(" ")[0].Trim();
            string[] blocks = lineCode.Replace(head, "").Split(",");
            if (head.Equals("array-length") || head.Equals("new-array"))
            {
                //array-length vx,vy
                string register = blocks[0].Trim();
                object value = tempRegister.getRegister(register);
                if (value is Var && ((Var)value).isFuncArg) return null;
                tempRegister.removeRegister(register);
                return null;
            }
            return null;
        }
    }
}
