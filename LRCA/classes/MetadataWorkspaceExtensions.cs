namespace LRCA.classes
{
	using System;
	using System.Collections.Generic;
	using System.Data.Entity.Core.Mapping;
	using System.Data.Entity.Core.Metadata.Edm;
	using System.Linq;

	internal static class MetadataWorkspaceExtensions
	{
		#region GetTableName
		public static string GetTableName(this MetadataWorkspace metadataWorkspace, string entityName)
		{
			string result;
			if (!EntityNameToTableNameOverrides.TryGetValue(entityName, out result))
			{
				MappingFragment mappingFragment = metadataWorkspace
					.GetItems<EntityContainerMapping>(DataSpace.CSSpace)
					.Single()
					.EntitySetMappings
					.Where(each => each.EntitySet.ElementType.Name == entityName)
					.Select(each => each.EntityTypeMappings[0].Fragments[0])
					.SingleOrDefault();
				if (!ReferenceEquals(null, mappingFragment))
				{
					result = mappingFragment.StoreEntitySet.Table;
				}
				else
				{
					result = entityName;
				}
			}
			return result;
		}
		#endregion

		#region GetColumnName
		public static string GetColumnName(this MetadataWorkspace metadataWorkspace, string entityName, string propertyName)
		{
			string result = propertyName;
			var entityTypeMapping = metadataWorkspace
				.GetItems<EntityContainerMapping>(DataSpace.CSSpace)
				.Single()
				.EntitySetMappings
				.Where(each => each.EntitySet.ElementType.Name == entityName)
				.Select(each => each.EntityTypeMappings.First())
				.SingleOrDefault();
			if (!ReferenceEquals(null, entityTypeMapping))
			{
				foreach (var each in entityTypeMapping.Fragments)
				{
					var query = each
						.PropertyMappings
						.OfType<ScalarPropertyMapping>()
						.Where(p => p.Property.Name == propertyName);
					if (query.Any())
					{
						result = query.Single().Column.Name;
						break;
					}
				}
			}
			return result;
		}
		public static string GetForeignKeyColumnName(this MetadataWorkspace metadataWorkspace, string relationshipName)
		{
			string result = relationshipName.Split('_').Last();
			var sourceEndMapping = metadataWorkspace
				.GetItems<EntityContainerMapping>(DataSpace.CSSpace)
				.Single()
				.AssociationSetMappings
				.Where(each => each.AssociationSet.Name == relationshipName)
				.Select(each => each.SourceEndMapping)
				.SingleOrDefault();
			if (!ReferenceEquals(null, sourceEndMapping))
			{
				result = sourceEndMapping
					.PropertyMappings
					.Select(each => each.Column.Name)
					.SingleOrDefault();
			}
			return result;
		}
		#endregion

		#region EntityNameToTableNameOverrides
		private static readonly Dictionary<string, string> EntityNameToTableNameOverrides = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
			{ "Unit", "unitview" }
		};
		#endregion
	}
}