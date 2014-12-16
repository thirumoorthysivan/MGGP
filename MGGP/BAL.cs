using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGGP
{
    public class BAL
    {
            
            private string[] _listOfStatements = new string[50];
            private string[] _questions = new string[15];
            private string[] _decutionStatements = new string[15];
            private string[] _answerList = new string[15];
            private static Dictionary<string, string> _qRomans = new Dictionary<string, string>();
            private static Dictionary<string, string> _qUnknownRomans = new Dictionary<string, string>();
            private static Dictionary<string, int> _romans = new Dictionary<string, int>();
            private static RomanToNumber _romanTonumeric = new RomanToNumber();
            private static NumericToRoman _NumericToRoman = new NumericToRoman();
        public void Build()
        {
          

           string test = _NumericToRoman.ToRoman(18999);
           //int value = _NumericToRoman.toNumber(test);
            _romans.Add("I", 1);
            _romans.Add("V", 5);
            _romans.Add("X", 10);
            _romans.Add("L", 50);
            _romans.Add("C", 100);
            _romans.Add("D", 500);
            _romans.Add("M", 1000);
            string endWordInStatement = string.Empty;
            string statement;
            string bstatement;
            int i = 0;
            int ds = 0;
            int qs = 0;
            do
            
            {

               statement = string.Empty;
               bstatement = Console.ReadLine();
                statement = bstatement.ToUpper().Replace("PISH","VALMI82GHEE");
               string[] wordsOfStatement = statement.Split(' ');
               _listOfStatements[i] = statement;
               int totalWordsInStatement = (wordsOfStatement.Length) - 1;
               endWordInStatement = wordsOfStatement[totalWordsInStatement].ToString().Trim().ToLower();
               if (endWordInStatement == "credits")
               {
                   _decutionStatements[ds] = statement;
                   ds++;
               }
               else if (endWordInStatement == "?")
               {
                   _questions[qs] = statement;
                   qs++;
               }
               else if (isINRomans(endWordInStatement))
               {
                   if (isNotInQRomans(wordsOfStatement[0]))
                   {
                      
                       _qRomans.Add(wordsOfStatement[0].ToUpper(), endWordInStatement.ToUpper());
                   }
                   
               }
               i++;
            } while (endWordInStatement != ".");
            // start process
            decutionStatementsValues();
            answerQuestion();
            for (int x = 0; x < _answerList.Length; x++)
            {
                Console.Write(_answerList[x]);
            }
            string endProgram  = Console.ReadLine();   
            if(endProgram == ".")
            {

            }
        }
        private static bool isINRomans(string roman)
        {
            bool isRoman = false;
            foreach (KeyValuePair<string, int> eromans in _romans)
            {
                if(eromans.Key == roman.ToUpper())
                {
                    isRoman = true;
                    break;
                }
            }
            return isRoman;
        }
        private static bool isNotInQRomans(string roman)
        {
            bool isRoman = true;
            foreach (KeyValuePair<string, string> eromans in _qRomans)
            {
                if (eromans.Key == roman.ToUpper())
                {
                    isRoman = false;
                    break;
                }
            }
            return isRoman;
        }

        private void decutionStatementsValues()
        {
            string[] splitByIs;
            string[] keyStatement;
            int creditsvalue = 0;
            string decutionStatement;
            string knownValues;
            double findUnKnownKeyValue;
            string UnknownKey;
            for (int i = 0; i < _decutionStatements.Length; i++)
            {
                findUnKnownKeyValue = 0;
                decutionStatement = string.Empty;
                UnknownKey = string.Empty;
                knownValues = string.Empty;
                decutionStatement = _decutionStatements[i];
                if (decutionStatement != null && decutionStatement != "" && decutionStatement.Length != 0)
                {
                    string[] stringSeparators = new string[] { "IS" };
                    splitByIs = decutionStatement.Split(stringSeparators, StringSplitOptions.None);
                    keyStatement = splitByIs[0].Trim().Split(' ');
                    string[] getcreditValue = splitByIs[1].Trim().Split(' ');
                    creditsvalue = Tools.ConvertToNumeric(getcreditValue[0].ToString());

                    for (int j = 0; j < keyStatement.Length; j++)
                    {
                        if (keyStatement[j] != "" || keyStatement[j] != string.Empty)
                        {


                            string value = getqRomanValue(keyStatement[j].ToUpper());
                            if (value != null && value != string.Empty)
                            {
                                knownValues = knownValues + value;
                            }
                            else
                            {
                                UnknownKey = keyStatement[j].ToUpper();
                            }
                            if (UnknownKey.Length > 0)
                            {
                                findUnKnownKeyValue = (creditsvalue / _romanTonumeric.toNumber(knownValues));
                                _qRomans.Add(UnknownKey, _NumericToRoman.ToRoman(Tools.ConvertToNumeric(findUnKnownKeyValue)));
                                _qUnknownRomans.Add(UnknownKey, _NumericToRoman.ToRoman(Tools.ConvertToNumeric(findUnKnownKeyValue)));
                            }
                        }
                    }
                }
            }
        }
       
        private string getqRomanValue(string key)
        {
            string value = string.Empty;
            foreach (KeyValuePair<string, string> eromans in _qRomans)
            {
                if (eromans.Key == key.ToUpper())
                {
                    value = eromans.Value;
                    break;
                }
            }
            return value;
        }
        private string getqUnknownRomanValue(string key)
        {
            string value = string.Empty;
            foreach (KeyValuePair<string, string> eromans in _qUnknownRomans)
            {
                if (eromans.Key == key.ToUpper())
                {
                    value = eromans.Value;
                    break;
                }
            }
            return value;
        }
        private void answerQuestion()
        {
            
            string question;
            string[] splitByIs;
            string[] questionSeprators = new string[] { "IS" };
            string knownValues;
            int unknownValues;
            string CreditString;
            string answerStatement;
            for (int i = 0; i < _questions.Length; i++)
            {
                knownValues = string.Empty;
                unknownValues = 0;
                CreditString = string.Empty;
                answerStatement = string.Empty;
                question = _questions[i];
                if (question != null && question.Length > 0)
                {
                    string[] splitQuestion;
                    splitByIs = question.Split(questionSeprators, StringSplitOptions.None);
                    if (splitByIs.Length == 2)
                    {
                        string creditBeforeIs = splitByIs[0].Trim();
                        string qromansAfterIs = splitByIs[1].Trim();
                        string[] questionkeys = qromansAfterIs.Split(' ');
                        string[] findCreditKey = creditBeforeIs.Split(' ');
                        int creditBeforeIsCount = findCreditKey.Length - 1;
                        if (findCreditKey[creditBeforeIsCount].ToString() == "CREDITS")
                        {
                            CreditString = "CREDITS";
                        }
                        for (int j = 0; j < questionkeys.Length - 1; j++)
                        {

                            string value = getqRomanValue(questionkeys[j].ToUpper());
                            if (value != null && value != string.Empty)
                            {
                                string qUnknownRomanValue = getqUnknownRomanValue(questionkeys[j]);
                                if (qUnknownRomanValue.Length > 0)
                                {
                                    unknownValues = _romanTonumeric.toNumber(qUnknownRomanValue);
                                }
                                else
                                {
                                    knownValues = knownValues + value;
                                }
                                if (answerStatement.Length == 0)
                                {
                                    answerStatement = questionkeys[j];
                                }
                                else
                                {
                                    answerStatement = answerStatement + " " + questionkeys[j];
                                }
                            }
                        }
                        int result;
                        if (unknownValues == 0)
                        {
                            result = _romanTonumeric.toNumber(knownValues);
                        }
                        else
                        {
                            result = _romanTonumeric.toNumber(knownValues) * unknownValues;
                        }
                        _answerList[i] = answerStatement.Replace("VALMI82GHEE","PISH") + " is " + result + " " + CreditString +"\n";
                    }
                    else
                    {
                        _answerList[i] = "I have no idea what you are talking about" + "\n";
                    }
                }
            }
        }

        }
    
}
