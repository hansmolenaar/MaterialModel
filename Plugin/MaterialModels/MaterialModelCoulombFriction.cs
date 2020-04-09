using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MaterialModel.RadiantApiSdk;
using MaterialModel.RadiantApiSdk.Property;

namespace MaterialModel.Plugin
{
   public class MaterialModelCoulombFriction : IMaterialModel
   {


      private static IMaterialModelProperty[] m_components = new IMaterialModelProperty[] {
         new MaterialModelProperty(PropertySingleValueFactory.CreateFrictionAngle()),
          new MaterialModelProperty(PropertySingleValueFactory.CreateCohesion()),
      };
      private static MaterialModelPropertyGroup m_inelastic = MaterialModelPropertyGroup.CreateNoCheck(m_components);
      private static MaterialModelPropertyGroup m_elastic = MaterialModelPropertyGroup.CreateEmpty();

      public TopologicalSupport Support { get { return TopologicalSupport.Surface; } }

      public string DisplayName { get { return "Coulomb Friction"; } }

      public IMaterialModelPropertyGroup ElasticBehaviors { get { return m_elastic; } }
      public IMaterialModelPropertyGroup InelasticBehaviors { get { return m_inelastic; } }

   }
}
