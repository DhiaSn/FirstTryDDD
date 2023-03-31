namespace FirstTryDDD.SharedKarnel.Services
{
    public static class GenericServices<T>
    {
        #region IsDefaultValue
        public static bool IsDefaultValue(dynamic value) => EqualityComparer<T>.Default.Equals(value, default(T));
        #endregion
    }
}
