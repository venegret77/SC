using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public sealed class MaxJsonLengthAttribute : ValidationAttribute
    {
        private string Name { get; set; }
        private int MaxLength { get; set; }

        public MaxJsonLengthAttribute(string name, int maxLenght)
        {
            this.Name = name;
            this.MaxLength = maxLenght;
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string _value = value.ToString();
                if (_value.Length > MaxLength)
                {
                    this.ErrorMessage = $"Превышена длина строки {MaxLength} для параметра {Name}";
                    return false;
                }
            }
            return true;
        }
    }
}
