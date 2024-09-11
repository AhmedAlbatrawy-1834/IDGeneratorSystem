using IDGeneratorSystem.Models;

namespace IDGeneratorSystem
{
    /// <summary>
    /// this Class Has Generate ID Method
    /// </summary>
    public static class IDGenerator
    {
        private static Dictionary<JopPositions, string> Positions =
            new Dictionary<JopPositions, string>
            {
                {JopPositions.Doctor,"Dr" },
                {JopPositions.Prof,"Prof" },
                {JopPositions.Engineer,"Eng" },
                {JopPositions.Employee,"Emp" },
                {JopPositions.Teacher,"Mr" }
            };
        /// <summary>
        /// this Method Check If The <paramref name="str"/> is valid or not.
        /// </summary>
        /// <param name="str">First Name or Second Name</param>
        /// <exception cref="FormatException">when <paramref name="str"/> has characters which is not Alphabet letters</exception>
        private static void Validate(string str)
        {
            var check = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            foreach(var ch in str)
            {
                if (!check.Contains(ch))
                    throw new FormatException($"{str} is Invalid Format please use Alphabet letters only");
            }
        }
        /// <summary>
        /// this method Create Second Part Of ID
        /// <list type="bullet">
        /// <item><paramref name="Length"/>:</item>
        /// <description>number of numbers in Second Part Of ID</description><br/>
        /// <item><paramref name="MinValue"/>:</item>
        /// <description>Start Value of number</description>
        ///<item><paramref name="MaxValue"/>:</item>
        /// <description>End Value of number</description>
        /// </list>
        /// </summary>
        /// <param name="Length"></param>
        /// <param name="MinValue"></param>
        /// <param name="MaxValue"></param>
        /// <returns></returns>
        private static string CreateSecondPart(int Length,int MinValue,int MaxValue)
        {
            var Num=Random.Shared.Next(MinValue, MaxValue);
            return Num.ToString().PadLeft(Length, '0');
        }
        /// <summary>
        /// Create First Part of ID By JopPositions Enum.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private static string CreateFirstPart(JopPositions position)
        {
            return Positions[position] + "-";
        }
        /// <summary>
        /// Create First Part of ID By <paramref name="FName"/> and <paramref name="LName"/> .
        /// </summary>
        /// <param name="FName"></param>
        /// <param name="LName"></param>
        /// <exception cref="FormatException"></exception>
        /// <returns>First Part of ID</returns>
        private static string CreateFirstPart(string FName,string LName)
        {
            FName = FName.Trim();FName = FName.ToUpper();
            LName = LName.Trim();LName = LName.ToUpper();
            Validate(FName);
            Validate(LName);
            return ""+FName[0] + LName[0]+"-";
        }
        /// <summary>
        /// this method Create ID By <paramref name="FName"/> and <paramref name="LName"/>.
        /// </summary>
        /// <param name="FName"></param>
        /// <param name="LName"></param>
        /// <param name="LengthOfSecondPart"></param>
        /// <param name="MinValue"></param>
        /// <param name="MaxValue"></param>
        /// <returns>ID As String</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string GenerateId(string FName,string LName, int LengthOfSecondPart = 3, int MinValue = 1, int MaxValue = -1)
        {
            if (MaxValue == -1)
                MaxValue = (int)Math.Pow(10, LengthOfSecondPart);
            if (LengthOfSecondPart < 1)
                throw new ArgumentException($"{nameof(LengthOfSecondPart)} should be greater than Zero");
            if (MinValue < 0 || MaxValue < 0)
                throw new ArgumentException($"{nameof(MaxValue)} and {nameof(MinValue)} should be positive value");
            if (MaxValue <= MinValue || MaxValue - MinValue == 1)
                throw new ArgumentException($"Invalid values For {nameof(MaxValue)} and {nameof(MinValue)}");
            return CreateFirstPart(FName,LName) + CreateSecondPart(LengthOfSecondPart,MinValue,MaxValue);
        }
        
        /// <summary>
        /// the Method Generate ID By JopPosition Enum.
        /// </summary>
        /// <param name="Position"></param>
        /// <param name="LengthOfSecondPart"></param>
        /// <param name="MinValue"></param>
        /// <param name="MaxValue"></param>
        /// <returns>ID As String</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string GenerateId(JopPositions Position, int LengthOfSecondPart=3,int MinValue=1,int MaxValue=-1)
        {
            if (MaxValue == -1) 
                MaxValue = (int)Math.Pow(10, LengthOfSecondPart);
            if (LengthOfSecondPart < 1)
                throw new ArgumentException($"{nameof(LengthOfSecondPart)} should be greater than Zero");
            if (MinValue < 0 || MaxValue < 0)
                throw new ArgumentException($"{nameof(MaxValue)} and {nameof(MinValue)} should be positive value");
            if (MaxValue <= MinValue || MaxValue - MinValue == 1)
                throw new ArgumentException($"Invalid values For {nameof(MaxValue)} and {nameof(MinValue)}");
            return CreateFirstPart(Position) + CreateSecondPart(LengthOfSecondPart,MinValue,MaxValue);
        }
        
    }
}