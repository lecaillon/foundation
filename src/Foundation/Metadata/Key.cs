﻿using System.Collections.Generic;
using System.Linq;
using Foundation.Metadata.Annotations;
using Foundation.Utilities;

namespace Foundation.Metadata
{
    /// <summary>
    ///     Represents a primary or alternate key on an entity.
    /// </summary>
    public class Key : Annotable
    {
        public Key(IReadOnlyList<Property> properties)
        {
            Check.NotEmpty(properties, nameof(properties));
            Check.HasNoNulls(properties, nameof(properties));

            Properties = properties;
        }

        /// <summary>
        ///     Gets the properties that make up the key.
        /// </summary>
        public IReadOnlyList<Property> Properties { get; }

        /// <summary>
        ///     Gets the entity type the key is defined on. This may be different from the type that <see cref="Properties" />
        ///     are defined on when the key is defined a derived type in an inheritance hierarchy (since the properties
        ///     may be defined on a base type).
        /// </summary>
        public Entity DeclaringEntity => Properties[0].DeclaringEntity;

        public bool IsPrimaryKey => this == DeclaringEntity.FindPrimaryKey();

        public List<ForeignKey> ReferencingForeignKeys { get; set; }

        public IEnumerable<ForeignKey> GetReferencingForeignKeys() => ReferencingForeignKeys ?? Enumerable.Empty<ForeignKey>();

        public override string ToString() => this.ToDebugString();
    }
}