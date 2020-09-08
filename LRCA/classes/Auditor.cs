namespace LRCA.classes
{
	using LRCA.classes.Models;
	using System;
	using System.Collections.Generic;
	using System.Configuration;
	using System.Data.Entity;
	using System.Data.Entity.Core;
	using System.Data.Entity.Core.Metadata.Edm;
	using System.Data.Entity.Core.Objects;
	using System.Data.Entity.Infrastructure;
	using System.Globalization;
	using System.Linq;
	using System.Security.Claims;
	using System.Text;
	using Encoder = Microsoft.Security.Application.Encoder;

	public sealed class Auditor : IAuditor
	{
		#region IAuditor.Audit
		void IAuditor.Audit(IPersistenceContext persistenceContext) {
			_objectContext = ((IObjectContextAdapter)persistenceContext).ObjectContext;
			_metadataWorkspace = _objectContext.MetadataWorkspace;
			AuditInternal((DbContext)persistenceContext);
		}
		#endregion

		#region AuditInternal
		private void AuditInternal(DbContext dbContext) {
			dbContext.ChangeTracker.DetectChanges();
			var commitId = Guid.NewGuid();
			var modifiedOn = DateTime.Now;
			var modifiedBy = ClaimsPrincipal.Current.Identity.Name;
			var history = dbContext.Set<Audit>();
			var entries = from entry in dbContext.ChangeTracker.Entries()
						  where entry.State == EntityState.Modified
						  select entry;
			foreach (var each in entries) {
				var entityType = each.Entity.GetType();
				IEnumerable<Change> changes = CollectPropertyChanges(each).Union(CollectRelationshipChanges(each));
				if (changes.Any()) {
					var data = new StringBuilder();
					EncodeChanges(changes, data);
					history.Add(new Audit {
						TableName = _metadataWorkspace.GetTableName(entityType.Name),
						RecordId = Convert.ToString(each.CurrentValues["Id"], CultureInfo.InvariantCulture),
						ChangeType = 2,
						UserName = modifiedBy,
						RecordedOn = modifiedOn,
						CommitId = commitId,
						Data = data.ToString()
					});
				}
			}
		}
		#endregion

		#region CollectPropertyChanges
		private IEnumerable<Change> CollectPropertyChanges(DbEntityEntry entry) {
			return from propertyName in entry.CurrentValues.PropertyNames
				   let oldValue = entry.OriginalValues[propertyName]
				   let newValue = entry.CurrentValues[propertyName]
				   where !object.Equals(oldValue, newValue)
				   select new Change(_metadataWorkspace.GetColumnName(entry.Entity.GetType().Name, propertyName)) {
					   OldValue = oldValue,
					   NewValue = newValue
				   };
		}
		#endregion

		#region CollectRelationshipChanges
		private IEnumerable<Change> CollectRelationshipChanges(DbEntityEntry entry) {
			var result = new Dictionary<string, Change>();
			var nameToMatch = entry.Entity.GetType().Name + '_';
			var relationships = _objectContext
				.ObjectStateManager
				.GetObjectStateEntries(EntityState.Added | EntityState.Deleted)
				.Where(each => each.IsRelationship && 
					each.EntitySet.Name.StartsWith(nameToMatch, StringComparison.Ordinal) &&
					((RelationshipEndMember)each.EntitySet.ElementType.KeyMembers.Last()).RelationshipMultiplicity != RelationshipMultiplicity.Many);
			foreach (var relationship in relationships) {
				var columnName = _metadataWorkspace.GetForeignKeyColumnName(relationship.EntitySet.Name);
				Change change;
				if (!result.TryGetValue(columnName, out change)) {
					change = new Change(columnName);
					result.Add(columnName, change);
				}
				if (relationship.State == EntityState.Added) {
					var entityKey2 = (EntityKey)relationship.CurrentValues.GetValue(1);
					change.NewValue = entityKey2.EntityKeyValues.Single().Value;
				}
				else {
					var entityKey2 = (EntityKey)relationship.OriginalValues.GetValue(1);
					change.OldValue = entityKey2.EntityKeyValues.Single().Value;
				}
			}
			return result.Values;
		}
		#endregion

		#region EncodeChanges
		private static void EncodeChanges(IEnumerable<Change> changes, StringBuilder data) {
			foreach (var each in changes) {
				var newString = each.NewValue as string;
				var oldString = each.OldValue as string;
				data.AppendFormat("{0}={1}|{2}&"
					, each.ColumnName
					, newString == null ? each.NewValue : Encoder.UrlEncode(newString)
					, oldString == null ? each.OldValue : Encoder.UrlEncode(oldString));
			}
			if (data.Length > 0) {
				data.Length--;
			}
		}
		#endregion

		#region Fields
		private MetadataWorkspace _metadataWorkspace;
		private ObjectContext _objectContext;
		#endregion

		#region Change
		private sealed class Change : IEquatable<Change>
		{
			#region Constructor
			public Change(string columnName) {
				ColumnName = columnName;
			}
			#endregion

			#region Equals
			public bool Equals(Change other) {
				if (ReferenceEquals(null, other)) {
					return false;
				}
				else {
					return this.ColumnName == other.ColumnName;
				}
			}
			public override bool Equals(Object obj) {
				return Equals(obj as Change);
			}
			#endregion

			#region GetHashCode
			public override int GetHashCode() {
				return ColumnName.GetHashCode();
			}
			#endregion

			#region Equality Operators
			public static bool operator ==(Change objA, Change objB) {
				if (ReferenceEquals(null, objA) || ReferenceEquals(null, objB)) {
					return Object.Equals(objA, objB);
				}
				else {
					return objA.Equals(objB);
				}
			}
			public static bool operator !=(Change objA, Change objB) {
				if (ReferenceEquals(null, objA) || ReferenceEquals(null, objB)) {
					return !Object.Equals(objA, objB);
				}
				else {
					return !objA.Equals(objB);
				}
			}
			#endregion

			#region Properties
			public string ColumnName { get; set; }
			public object OldValue { get; set; }
			public object NewValue { get; set; }
			#endregion
		}
		#endregion
	}
}
