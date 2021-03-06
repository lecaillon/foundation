﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Foundation.Storage
{
    /// <summary>
    ///     Logging information about a <see cref="DbCommand" /> that is being executed.
    /// </summary>
    [Obsolete("This class is obsolete. It will be removed in a future release.")]
    public class DbCommandLogData : IEnumerable<KeyValuePair<string, object>>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DbParameterLogData" /> class.
        /// </summary>
        /// <param name="commandText"> The command text being executed. </param>
        /// <param name="commandType"> The type of command being executed. </param>
        /// <param name="commandTimeout"> The timeout configured for the command. </param>
        /// <param name="parameters"> Parameters for the command. </param>
        /// <param name="elapsedMilliseconds"> How many milliseconds the command took to execute (if it has completed). </param>
        public DbCommandLogData(string commandText, CommandType commandType, int commandTimeout, IReadOnlyList<DbParameterLogData> parameters, long? elapsedMilliseconds)
        {
            CommandText = commandText;
            CommandType = commandType;
            CommandTimeout = commandTimeout;
            Parameters = parameters;
            ElapsedMilliseconds = elapsedMilliseconds;
        }

        /// <summary>
        ///     Gets the command text being executed.
        /// </summary>
        public virtual string CommandText { get; }

        /// <summary>
        ///     Gets the type of command being executed.
        /// </summary>
        public virtual CommandType CommandType { get; }

        /// <summary>
        ///     Gets the timeout configured for the command.
        /// </summary>
        public virtual int CommandTimeout { get; }

        /// <summary>
        ///     Gets the parameters for the command.
        /// </summary>
        public virtual IReadOnlyList<DbParameterLogData> Parameters { get; }

        /// <summary>
        ///     Gets how many milliseconds the command took to execute (if it has completed).
        /// </summary>
        public virtual long? ElapsedMilliseconds { get; }

        public virtual IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            yield return new KeyValuePair<string, object>("CommandText", CommandText);
            yield return new KeyValuePair<string, object>("CommandType", CommandType);
            yield return new KeyValuePair<string, object>("CommandTimeout", CommandTimeout);
            yield return new KeyValuePair<string, object>("Parameters", Parameters);
            yield return new KeyValuePair<string, object>("ElapsedMilliseconds", ElapsedMilliseconds);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
