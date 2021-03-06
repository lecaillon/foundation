﻿using System;
using System.Reflection;
using Foundation.Metadata.Annotations;
using Foundation.Utilities;

namespace Foundation.Metadata
{
    /// <summary>
    ///     Base type for navigation and scalar properties.
    /// </summary>
    public abstract class PropertyBase : Annotable
    {
        protected PropertyBase(string name, PropertyInfo propertyInfo)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(propertyInfo, nameof(propertyInfo));

            Name = name;
            PropertyInfo = propertyInfo;
        }

        /// <summary>
        ///     Gets the name of the property.
        /// </summary>
        public virtual string Name { get; }

        public virtual PropertyInfo PropertyInfo { get; }

        /// <summary>
        ///     Gets the entity that this property belongs to.
        /// </summary>
        public abstract Entity DeclaringEntity { get; }

        public abstract Type ClrType { get; }
    }
}