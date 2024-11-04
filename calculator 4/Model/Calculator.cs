using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator7
{    
    public class Calculator
    {
        public string Input = "";       // 숫자 입력  계산기
        public string Operator = "";    // 연산자 입력
        public string Result = "0";     // 계산기의 결과창
        public double result = 0;       // 연산자 이전의 Input 값
        public string Save = "";        // 계산기의 결과창 위쪽 식 
        public string equation = "";
        public double Perresult = 0;

        public bool ResultTF = false;

        public void Append(object number)
        {
            if (ResultTF == true || Result == "0")
            {
                Input = number.ToString();
                Result = Input;
                ResultTF = false;
                //Save = "";
            }        
            
            else
            {
                Input += number;
                Result = Input;
            }
        }

        public void Dot()
        {
            if (!Input.Contains("."))
            {
                if (Input == "")
                {
                    Append("0.");
                }
                else
                    Append(".");

            }
        }

        public string UseOperator(string operation)
        {
            string BeforeEq = string.Empty;
            string BeforeRe = string.Empty;
            double value;
            if (double.TryParse(Input, out value))
            {
                // save의 가장 마지막이 =인지 확인                    
                if (Save.EndsWith("="))
                {
                    Save = result.ToString();
                }
                /*if (ResultTF == true)
                {
                    result = value;
                    Save += operation.ToString();
                    ResultTF = false;
                }*/
                if (ResultTF == false)
                {
                    if (!string.IsNullOrEmpty(Operator))
                    {
                        BeforeEq = result + Operator + value + "=";
                        result = OP(result, value, Operator);
                        BeforeRe = result.ToString();
                        Save = $"{result}{operation}";
                        Result = result.ToString();
                        
                    }
                    else
                    {
                        result = value;
                        Save = $"{result}{operation}";
                    }
                }
                else
                {
                    Input = Result;
                    Operator = operation;
                    Save = $"{result}{Operator}";
                }
            }
            else if (!string.IsNullOrEmpty(operation))
            {
                Operator = operation;
                Save = $"{result}{Operator}";
            }
            Operator = operation;
            Input="";
            return BeforeEq + BeforeRe;
        }

        public static double OP(double left, double right, string operation)
        {
            switch (operation)
            {
                case "+":
                    return left + right;
                case "-":
                    return left - right;
                case "*":
                    return left * right;
                case "/":
                    return right != 0 ? left / right : double.NaN;
                default:
                    return double.NaN;

            }
        }

        public string Equal()
        {
            if (!string.IsNullOrEmpty(Input))
            {
                double Value;
                if (double.TryParse(Input, out Value))
                {
                    result = OP(result, Value, Operator);
                    Save = $"{Save}{Input}=";
                    Input = result.ToString();
                    Result = Input;
                    Operator = "";
                    ResultTF = true;
                    return Save + Result;

                }
            }
            return "";
        }

        public void Back()
        {
            if (Input.Length > 0)
            {
                Input = Input.Substring(0, Input.Length - 1);
                if (Input.Length > 0)
                {
                    Result = Input;
                }
                else
                {
                    Result = "0";
                }
            }
        }

        public void Clear()
        {
            Input = "";
            Operator = "";
            Result = "0";
            result = 0;
            Save = "";            
            ResultTF = false;
        }

        public void ClearEntry()
        {
            Input = "";
            Result = "0";
            result = 0;
            ResultTF = false;
        }

        public void Percent()
        {
            double value;
            if (double.TryParse(Input, out value))
            {
                Perresult = value / 100;
                Result = Perresult.ToString();
                Input = Perresult.ToString();                         
            }

        }
                           
        /* public void Reverse()
{
   if (!string.IsNullOrEmpty(Input))
   {
       double value;
       if (double.TryParse(Input, out value) && value != 0)
       {
           result = 1 / value;
           Save = "1 /(" + value.ToString() + ")";
           Input = result.ToString();
           Result = Input;
       }
   }
}

public void Square()
{
   if (!string.IsNullOrEmpty(Input))
   {
       double value;
       if (double.TryParse(Input, out value))
       {
           result = value * value;
           Input = result.ToString();
           Save = "sqr(" + value.ToString() + ")";
           Result = Input;
           ResultTF = true;
       }
   }
}

public void SquareRoot()
{
   if (!string.IsNullOrEmpty(Input))
   {
       double value;
       if (double.TryParse(Input, out value) && value >= 0)
       {
           result = Math.Sqrt(value);
           Input = result.ToString();
           Save = "sqrt(" + value.ToString() + ")";
           Result = Input;
           ResultTF = true;
       }
   }
}

public void PlusMinus()
{
   if (!string.IsNullOrEmpty(Input))
   {
       double value;
       if (double.TryParse(Input, out value))
       {
           result = -value;
           Input = result.ToString();
           Result = Input;
       }
   }
}*/
    }
}
    




