using Domain.Enums;

namespace Domain.Common
{
    public class Condition
    {
        public Operator Operator { get; set; }
        public string FieldName { get; set; }
        public object Value { get; set; }
    }
}
