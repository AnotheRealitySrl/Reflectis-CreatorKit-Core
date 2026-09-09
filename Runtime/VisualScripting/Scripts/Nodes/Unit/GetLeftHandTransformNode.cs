using Unity.VisualScripting;
using UnityEngine;

namespace Virtuademy.SDK.Environments.VisualScripting
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
            CharacterLeftHand = ValueOutput<Transform>(nameof(CharacterLeftHand), (flow) => VirtuademyFramework.Current.PlayerLeftHandTransform);
        }
    }
}
