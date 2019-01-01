using RecrutingWebApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecrutingWebApp.Util.ParserEnum
{
    /// <summary>
    /// Parser criado para transformar as informacoes recebidas pela API no Enum
    /// </summary>
    public class JobLevelParser
    {
        public ExperienceLevel Parse(int value)
        {            
            switch (value)
            {
                case 1:
                    return ExperienceLevel.Intern;
                        
                case 2:
                    return ExperienceLevel.Junior;

                case 3:
                    return ExperienceLevel.Full;

                case 4:
                    return ExperienceLevel.Senior;

                case 5:
                    return ExperienceLevel.Specialist;

                default:
                    throw new Exception(string.Format("Error parsing value: {0}", value));
            }
        }
    }
}
