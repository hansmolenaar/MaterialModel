using System;
using System.Collections.Generic;
using System.Linq;

namespace MaterialModel.RadiantApiSdk
{
   public class MaterialModelPropertyGroup : IMaterialModelPropertyGroup
   {
      #region constructor
      private MaterialModelPropertyGroup(IEnumerable<IMaterialModelProperty> props, BehaviorsConsistencyChecker checker)
      {
         Properties = props.ToArray();
         ConistencyChecker = checker;
      }
 

    
      public static MaterialModelPropertyGroup Create(IEnumerable<IMaterialModelProperty> props, BehaviorsConsistencyChecker checker)
      {
         return new MaterialModelPropertyGroup(props, checker);
      }

      public static MaterialModelPropertyGroup CreateNoCheck(IEnumerable<IMaterialModelProperty> props)
      {
         return Create(props, BehaviorIsConsistent);
      }

      public static MaterialModelPropertyGroup CreateEmpty()
      {
         return CreateNoCheck(Enumerable.Empty<IMaterialModelProperty>());
      }
      #endregion

      #region Implementation IMaterialModelPropertyGroup
      public IEnumerable<IMaterialModelProperty> Properties { get; }
      public BehaviorsConsistencyChecker ConistencyChecker { get; }
      #endregion

      #region Yes man
      public static bool BehaviorIsConsistent(IReadOnlyList<string> behaviors, out string errorMessage)
      {
         errorMessage = string.Empty;
         return true;
      }
      #endregion
   }
}
