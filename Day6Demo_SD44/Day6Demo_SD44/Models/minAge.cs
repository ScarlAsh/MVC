using System.ComponentModel.DataAnnotations;

namespace Day6Demo_SD44.Models
{
    public class minAge : ValidationAttribute
    {
        int AgeValue;

        public minAge(int num)
        {
            AgeValue = num;
        }

        public override bool IsValid(object obj)
        {
            if(obj is null)
            {
                ErrorMessage = "Age Can't be Null";///User Validation Error Msg
                return false;
            }
            else 
            {
                if(obj is int)
                {
                    int suppliedValue = (int)obj;
                    if(suppliedValue > AgeValue)
                    {
                        return true;
                    }
                    else 
                    {
                        ErrorMessage = "Minimum Value For Age Should be +" + AgeValue; //User Validation Error Msg
                        return false;
                    }
                }
                else 
                {
                    ErrorMessage = "Age Should be Int Value!!";///User Validation Error Msg
                    return false;
                }
            }
        }
    }
}
