﻿namespace MasterMind_BLL.Model
{
    public class Result
    {
        public int userInput { get; set; }
        public int NumberOfDigitMatch { get; set; }
        public int NumberOfPositonalDigitMatch { get; set; }
        public bool IsExactMatch { get; set; }
    }
}
