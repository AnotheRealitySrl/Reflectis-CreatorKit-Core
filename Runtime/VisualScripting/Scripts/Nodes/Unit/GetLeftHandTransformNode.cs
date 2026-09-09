using Virtuademy.SDK.Core.Avatars;
using Unity.VisualScripting;
using UnityEngine;

namespace Virtuademy.CreatorKit.Worlds.VisualScripting
{
    [UnitTitle("Reflectis CMUser: Get Character Left Hand")]
    [UnitSurtitle("Character Left Hand")]
    [UnitShortTitle("Get Character Left Hand")]
    [UnitCategory("Reflectis\\Get")]
    public class GetLeftHandTransformNode : Unit
    {

        [NullMeansSelf]
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueOutput CharacterLeftHand { get; private set; }

        //private Transform _characterReference;

        protected override void Definition()
        {
            CharacterLeftHand = ValueOutput<Transform>(nameof(CharacterLeftHand), (flow) => WorldServices.Get<IAvatarSystem>().AvatarInstance.CharacterReference.LeftInteractorReference);
        }
    }
}
