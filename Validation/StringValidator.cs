using Common.Logging;
using System;
using System.Collections.Generic;

namespace Validation
{
    /// <summary>
    /// Validate the string if it is properly quoted and parenthesized.
    /// </summary>
    public class StringValidator : IValidator
    {
        /// <summary>
        /// Logger object to log traces, exceptions etc.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Properties to associate with traces, exception etc.
        /// </summary>
        private readonly Dictionary<string, string> _loggingProperties;

        public StringValidator(ILogger logger)
        { 
            _logger = logger;
            _loggingProperties = new Dictionary<string, string>()
                {
                    {"ClassName",nameof(StringValidator) }
                };
        }

        /// <summary>
        /// To validate if string is properly quoted and parenthesized 
        /// </summary>
        /// <param name="input"></param>
        /// <exception cref="System.ArgumentNullException"> Thrown if parameter is null </exception>
        public bool Validate(string input)
        {
            try
            {
                _logger.Information($"Validation Started. Input : {input}");

                bool isValid; 
                if (input == null)
                {
                    throw new ArgumentNullException();
                }


                Stack<char> stack = new Stack<char>();
                foreach (char c in input)
                {
                    if (c.Equals('('))
                    {
                        stack.Push(c);
                    }
                    else if (c.Equals(')'))
                    {
                        if (stack.Count > 0 && stack.Peek().Equals('('))
                        {
                            stack.Pop();
                            continue;
                        }
                        else
                        {
                            stack.Push(c);
                        }
                    }
                    else if (c.Equals('\''))
                    {
                        if (stack.Count > 0 && stack.Peek().Equals('\''))
                        {
                            stack.Pop();
                            continue;
                        }
                        else
                        {
                            stack.Push(c);
                        }
                    }
                }

                isValid = stack.Count > 0 ? false : true;

                _logger.Information($"Validation Completed. Result : {isValid.ToString()}");

                return isValid;
            }
            catch(Exception ex)
            {
                _logger.Exception(ex, _loggingProperties);
                throw;
            }
        }

        
    }
}
