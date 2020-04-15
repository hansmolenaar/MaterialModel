using System;
using System.Collections.Generic;
using System.Linq;

namespace MaterialModel.RadiantApiSdk
{
   public class MaterialModelPropertyGroup : IMaterialModelPropertyGroup
   {
      #region constructor
      private MaterialModelPropertyGroup(IEnumerable<IMaterialModelProperty> props, ConsistencyChecker checker)
      {
         Properties = props.ToArray();
         ConistencyChecker = checker;
      }
 

    
      public static MaterialModelPropertyGroup Create(IEnumerable<IMaterialModelProperty> props, ConsistencyChecker checker)
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
      public ConsistencyChecker ConistencyChecker { get; }
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
