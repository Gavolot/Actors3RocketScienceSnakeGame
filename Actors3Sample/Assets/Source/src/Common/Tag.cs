//  Project : ecs
// Contacts : Pix - ask@pixeye.games

using Pixeye.Actors;

namespace Pixeye.Source
{
	public class Tag : ITag
	{
		[TagField(categoryName = "InputType")]
		public const int InputKeyboardAxes = 0;
		[TagField(categoryName = "Scope")]
		public const int Player = 1;
		[TagField(categoryName = "Render")]
		public const int DepthSorting = 2;
		[TagField(categoryName = "InputType")]
		public const int InputMouseLook = 3;
		[TagField(categoryName = "Actions")]
		public const int ActionFire = 4;
		[TagField(categoryName = "Actions")]
		public const int ActionLook = 5;
		[TagField(categoryName = "Bob")]
		public const int ActiveYBob = 6;
		[TagField(categoryName = "HumanPart")]
		public const int RightHand = 7;
		[TagField(categoryName = "HumanPart")]
		public const int LeftHand = 8;
		[TagField(categoryName = "HumanPart")]
		public const int RightLeg = 9;
		[TagField(categoryName = "HumanPart")]
		public const int LeftLeg = 10;
		[TagField(categoryName = "Scope")]
		public const int HasGameObjectParent = 11;
		[TagField(categoryName = "HumanPart")]
		public const int Head = 12;
		[TagField(categoryName = "WeaponType")]
		public const int WeaponTypeHands = 13;
		[TagField(categoryName = "WeaponType")]
		public const int WeaponTypePistol = 14;
		[TagField(categoryName = "Bob")]
		public const int ActiveXBob = 15;
		[TagField(categoryName = "Bob")]
		public const int ComponentXBob = 16;
		[TagField(categoryName = "Bob")]
		public const int ComponentYBob = 17;
		[TagField(categoryName = "HumanPart")]
		public const int PistolPositionRight = 18;
		[TagField(categoryName = "Physics")]
		public const int fire1LookImpulseStart = 19;
		[TagField(categoryName = "Physics")]
		public const int fire1LookImpulseDuring = 20;


		[TagField(categoryName = "Snake")]
		public const int TickMover = 21;
		[TagField(categoryName = "Snake")]
		public const int CantMove = 22;
		[TagField(categoryName = "Snake")]
		public const int Apple = 23;
		[TagField(categoryName = "Snake")]
		public const int NewBodyCell = 24;
		[TagField(categoryName = "Snake")]
		public const int SnakeDead = 25;
		[TagField(categoryName = "Snake")]
		public const int Reposition = 26;
	}
}