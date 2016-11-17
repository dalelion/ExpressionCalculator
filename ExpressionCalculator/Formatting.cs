using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionCalculator {
    class Formatting {

        public static Dictionary<int[], String> Pars = new Dictionary<int[], string>();
        //TODO Finish grouping method
        public static String GroupPar (String x) {

            int[] ParIndex = new int[2];

            if (x.Contains("(")) {
                ParIndex[0] = x.LastIndexOf("(");
                ParIndex[1] = x.IndexOf(")") - x.LastIndexOf("(") + 1;
                String Par = x.Substring(ParIndex[0], ParIndex[1]);

                Pars.Add(ParIndex, Par);
                Console.WriteLine(Par);
            }
            //TODO NewS will be a new string with the last group of parenthesis removed and a placeholder in its spot
            String NewS = "";

            return (x.Contains("(")) ? GroupPar(NewS) : NewS;
        }

    }
}
