//   Project : Actors
//  Contacts : Pixeye - ask@pixeye.games 


using UnityEngine;

namespace Pixeye.Actors
{
	public abstract class CommandsConsole : ScriptableObject
	{
		public ent lastEntity;

		public ent hasEntity;

		[Bind]
		public string Help()
		{
			//return Toolbox.Get<ProcessorConsole>().Help();
			return LayerKernel.Get<ProcessorConsole>().Help();
		}

		[Bind]
		public string create(string prefabID, Vector3 position)
		{
			var e = LayerKernel.Entity.Create(prefabID, position);
			//var e = Actor.Create(prefabID, position).entity;
			return $"Entity {e.transform.name} with ID [{e.id}] was created!";
		}

		[Bind]
		public string get(int id)
		{
			lastEntity = id;
			return $"Entity with ID [{id}] recieved ";
		}
		[Bind]
		public string tag_ammount(int entId, int tagId){
			hasEntity = entId;
			if(hasEntity.Has(tagId)){
				return $"[{hasEntity.TagsAmount(tagId)}]";
			}
			return "False";
		}
		[Bind]
		public string tag_add(int entId, int tagId){
			hasEntity = entId;
			hasEntity.Set(tagId);
			return $"Succes, tag [{tagId}] added in entity [{entId}]!";
		}
		[Bind]
		public string remove_all_tag(int entId, int tagId){
			hasEntity = entId;
			hasEntity.RemoveAll(tagId);
			return $"tags [{tagId}] removed in entity [{entId}]!";
		}
		[Bind]
		public string has_tag(int entId, int tagId){
			hasEntity = entId;
			if(hasEntity.Has(tagId)){
				return $"Yes, entity with ID [{hasEntity}], has tag [{tagId}] ";
			}
			return "False";
		}
		[Bind]
		public string has_tag_l(int tagId){
			if(lastEntity.Has(tagId)){
				return $"Yes, entity with ID [{lastEntity}], has tag [{tagId}] ";
			}
			return "False";
		}
	}
}