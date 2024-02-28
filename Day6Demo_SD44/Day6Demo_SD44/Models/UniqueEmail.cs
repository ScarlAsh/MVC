using System.ComponentModel.DataAnnotations;

namespace Day6Demo_SD44.Models
{
    public class UniqueEmail : ValidationAttribute
    {
        public UniqueEmail()
        {
            
        }

        protected override ValidationResult? IsValid(object? obj, ValidationContext validationContext)
        {
            if (obj is null)
            {
                return new ValidationResult("Email Can't be Null"); //User Validation Error Msg
            }
            else
            {
                if (obj is string)
                {
                    string suppliedValue = (string)obj;
                    
                    
                    StdDbContext context = new StdDbContext();
                    //bool EmailExist = context.Students.Any(std => std.Email == suppliedValue);
                    bool EmailExist = context.Students.Any(std => std.Email == suppliedValue
                    && ((Student)validationContext.ObjectInstance).DeptID == 1);

                    if (EmailExist == false)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult("Email " + suppliedValue + " is Already Taken!!!"); //User Validation Error Msg;
                    }
                }
                else
                {
                    return new ValidationResult("Email Should be String Value..."); //User Validation Error Msg;
                }
            }
        }
    }
}
