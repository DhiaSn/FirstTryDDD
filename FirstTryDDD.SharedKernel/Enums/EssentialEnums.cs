using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTryDDD.SharedKernel.Enums
{
    /// <summary>
    /// DbMode is for choosing the target database the program runs in.
    /// <remarks>
    /// <para>
    /// - <c>DbMode.Debug</c> for the development database 
    /// </para>
    /// <para>
    /// - <c>DbMode.Release</c> is for the Production database 
    /// </para>
    /// </remarks>
    /// </summary>
    public enum DbMode { None, Debug, Release }

    public enum ResponseResult { None, Success, Exception, Error }  

}
