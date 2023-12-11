namespace GetirClone.API.Utilities
{
    public static class TypeConvertions
    {

        public static string GetString(this object value)
        {
            var output = "";
            try
            {
                output = Convert.ToString(value);
            }
            catch (Exception)
            {


            }

            return output;
        }
        public static decimal GetDeci(this object value, decimal nullValue = 0)
        {
            decimal output = nullValue;
            try
            {
                output = Convert.ToDecimal(value);
            }
            catch (Exception)
            {


            }

            return output;
        }
        public static double GetDouble(this object value, double nullValue = 0)
        {
            double output = nullValue;
            try
            {
                output = Convert.ToDouble(value);
            }
            catch (Exception)
            {


            }

            return output;
        }
        public static int GetInt(this object value, int nullValue = 0)
        {
            int output = nullValue;
            try
            {
                output = Convert.ToInt32(value);
            }
            catch (Exception)
            {

            }
            return output;
        }
        public static byte GetByte(this object value, byte nullValue = 0)
        {
            byte output = nullValue;
            try
            {
                output = Convert.ToByte(value);
            }
            catch (Exception)
            {

            }
            return output;
        }
        public static Guid GetGuid(this object value)
        {
            Guid output = Guid.Empty;

            try
            {
                output = Guid.Parse(value.GetString());
            }
            catch (Exception)
            {
            }
            return output;
        }
        public static Guid? GetNullableGuid(this object value)
        {
            Guid? output = Guid.Empty;
            try
            {
                output = Guid.Parse(value.GetString());
                return output;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static DateTime GetDate(this object value)
        {
            DateTime output = new DateTime(1899, 12, 31);
            try
            {
                output = Convert.ToDateTime(value);
            }
            catch (Exception)
            {

            }


            return output;
        }
        /// <summary>
        /// Datetime 1899 tan küçük ise date taşması olmaması için 1899,12,31  tarihini döner
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime GetDateOrDefault(this object value)
        {
            DateTime output = new DateTime(1899, 12, 31);
            try
            {
                output = Convert.ToDateTime(value);
                if (output < new DateTime(1899, 12, 31))
                {
                    output = new DateTime(1899, 12, 31);
                }
            }
            catch (Exception)
            {

            }


            return output;
        }
        public static short GetShort(this object value)
        {
            try
            {
                return Convert.ToInt16(value);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        //TODO Bu metodun bütün referanslarını EnumarationExtentions.GetDescription olarak değiştirip bu metodu kaldır.
        //public static string GetEnumDescription(this Enum value)
        //{
        //    System.Reflection.FieldInfo field = value.GetType().GetField(value.ToString());
        //    System.ComponentModel.DescriptionAttribute attribute
        //            = Attribute.GetCustomAttribute(field, typeof(System.ComponentModel.DescriptionAttribute))
        //                as System.ComponentModel.DescriptionAttribute;
        //    return attribute == null ? value.ToString() : attribute.Description;
        //}
    }
}
