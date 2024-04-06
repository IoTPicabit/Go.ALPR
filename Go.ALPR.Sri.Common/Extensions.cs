using System.Runtime.CompilerServices;

namespace Go.ALPR.Sri.Common
{
    public static class Extensions
    {
        /// <summary>
        /// Devuelve un string con la traza del método en el que se está actualmente.
        /// <remarks>
        /// Uso 1: <code>this.TraceMethod();</code>
        /// </remarks>
        /// <remarks>
        /// Uso 2: <code>this.TraceMethod(new{ para1, para2, paraN });</code>
        /// </remarks>
        /// </summary>
        /// <param name="obj">Clase que contiene el método.</param>
        /// <param name="parameters">Parámetros pasados como tipo anónimo. Admite <c>null</c> si no hay ninguno.</param>
        /// <param name="methodName">No usar, se rellena solo con el nombre del método dese el que es llamado.</param>
        /// <param name="lineNumber">No usar, se rellena solo con el número de línea desde la que es llamada.</param>
        /// <returns><code>"[LineaCodigo] NombreClase.NombreMetodo({ nombreParametroN = valorParametroN, [...] })"</code></returns>
        public static string TraceMethod<T>(this T obj, object parameters = null, [CallerMemberName] string methodName = null,
            [CallerLineNumber] int lineNumber = 0) where T : class => $"[{lineNumber}] {obj.GetType().Name}.{methodName}({parameters ?? string.Empty})";

        /// <summary>
        /// Devuelve un string con la traza del método en el que se está actualmente (marcando que es auditoría).
        /// <remarks>
        /// Uso 1: <code>this.AuditAction();</code>
        /// </remarks>
        /// <remarks>
        /// Uso 2: <code>this.AuditAction(new{ para1, para2, paraN });</code>
        /// </remarks>
        /// </summary>
        /// <param name="obj">Clase que contiene el método.</param>
        /// <param name="parameters">Parámetros pasados como tipo anónimo. Admite <c>null</c> si no hay ninguno. Se puede emplear para indicar el tipo de auditoría que es.</param>
        /// <returns></returns>
        public static string AuditAction<T>(this T obj, object parameters = null) where T : class => $"[AUDIT] ({parameters ?? string.Empty})";
    }
}
