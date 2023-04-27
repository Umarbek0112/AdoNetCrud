using System;

namespace ExamProgram.Service.Exceptionst
{
    public class ExamProgramException : Exception 
    {
        public ExamProgramException(string message) : base(message)
        { 
        }
    }
}
