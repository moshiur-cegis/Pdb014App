// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define(["require","exports","../../../../../../core/tsSupport/makeTemplateObjectHelper","../../../core/shaderLibrary/util/DoublePrecision.glsl","../../../core/shaderModules/interfaces"],function(v,e,b,u,c){function g(d,f){var a=d.vertex;a.uniforms.add("uDistanceFalloffFactor","float");a.code.add(c.glsl(h||(h=b(["\n    float distanceBasedPerspectiveFactor(float distance) {\n      return clamp(sqrt(uDistanceFalloffFactor / distance), 0.0, 1.0);\n    }\n  "],["\n    float distanceBasedPerspectiveFactor(float distance) {\n      return clamp(sqrt(uDistanceFalloffFactor / distance), 0.0, 1.0);\n    }\n  "]))));
a.uniforms.add("uComponentDataTex","sampler2D");a.uniforms.add("uComponentDataTexInvDim","vec2");d.attributes.add("componentIndex","float");a.defines.addFloat("COMPONENT_COLOR_FIELD_OFFSET",0);a.defines.addFloat("COMPONENT_OTHER_FIELDS_OFFSET",1);a.defines.addFloat("COMPONENT_FIELD_COUNT",2);a.defines.addFloat("LINE_WIDTH_FRACTION_FACTOR",8);a.defines.addFloat("EXTENSION_LENGTH_OFFSET",128);a.defines.addFloat("COMPONENT_TEX_WIDTH",4096);a.code.add(c.glsl(k||(k=b(["\n    vec2 _componentTextureCoords(float componentIndex, float fieldOffset) {\n      float fieldIndex \x3d COMPONENT_FIELD_COUNT * componentIndex + fieldOffset;\n\n      float rowIndex \x3d floor(fieldIndex / COMPONENT_TEX_WIDTH);\n      float colIndex \x3d mod(fieldIndex, COMPONENT_TEX_WIDTH);\n\n      vec2 linearIndex \x3d vec2(\n        (colIndex + 0.5) / COMPONENT_TEX_WIDTH,\n        (rowIndex + 0.5) * uComponentDataTexInvDim.y\n      );\n\n      return linearIndex;\n    }\n\n    struct ComponentData {\n      vec4 color;\n      float lineWidth;\n      float extensionLength;\n      float type;\n    };\n\n    ComponentData readComponentData() {\n      vec2 colorIndex \x3d _componentTextureCoords(componentIndex, COMPONENT_COLOR_FIELD_OFFSET);\n      vec2 otherIndex \x3d _componentTextureCoords(componentIndex, COMPONENT_OTHER_FIELDS_OFFSET);\n\n      vec4 colorValue \x3d texture2D(uComponentDataTex, colorIndex);\n      vec4 otherValue \x3d texture2D(uComponentDataTex, otherIndex);\n\n      return ComponentData(\n        vec4(colorValue.rgb, colorValue.a * otherValue.w), // otherValue.w stores separate opacity\n        otherValue.x * (255.0 / LINE_WIDTH_FRACTION_FACTOR),\n        otherValue.y * 255.0 - EXTENSION_LENGTH_OFFSET,\n        -(otherValue.z * 255.0) + 0.5 // SOLID (\x3d0/255) needs to be \x3e 0.0, SKETCHY (\x3d1/255) needs to be \x3c\x3d 0;\n      );\n    }\n  "],
["\n    vec2 _componentTextureCoords(float componentIndex, float fieldOffset) {\n      float fieldIndex \x3d COMPONENT_FIELD_COUNT * componentIndex + fieldOffset;\n\n      float rowIndex \x3d floor(fieldIndex / COMPONENT_TEX_WIDTH);\n      float colIndex \x3d mod(fieldIndex, COMPONENT_TEX_WIDTH);\n\n      vec2 linearIndex \x3d vec2(\n        (colIndex + 0.5) / COMPONENT_TEX_WIDTH,\n        (rowIndex + 0.5) * uComponentDataTexInvDim.y\n      );\n\n      return linearIndex;\n    }\n\n    struct ComponentData {\n      vec4 color;\n      float lineWidth;\n      float extensionLength;\n      float type;\n    };\n\n    ComponentData readComponentData() {\n      vec2 colorIndex \x3d _componentTextureCoords(componentIndex, COMPONENT_COLOR_FIELD_OFFSET);\n      vec2 otherIndex \x3d _componentTextureCoords(componentIndex, COMPONENT_OTHER_FIELDS_OFFSET);\n\n      vec4 colorValue \x3d texture2D(uComponentDataTex, colorIndex);\n      vec4 otherValue \x3d texture2D(uComponentDataTex, otherIndex);\n\n      return ComponentData(\n        vec4(colorValue.rgb, colorValue.a * otherValue.w), // otherValue.w stores separate opacity\n        otherValue.x * (255.0 / LINE_WIDTH_FRACTION_FACTOR),\n        otherValue.y * 255.0 - EXTENSION_LENGTH_OFFSET,\n        -(otherValue.z * 255.0) + 0.5 // SOLID (\x3d0/255) needs to be \x3e 0.0, SKETCHY (\x3d1/255) needs to be \x3c\x3d 0;\n      );\n    }\n  "]))));
f.legacy?a.code.add(c.glsl(l||(l=b(["\n      vec3 _modelToWorldNormal(vec3 normal) {\n        return (uModel * vec4(normal, 0.0)).xyz;\n      }\n\n      vec3 _modelToViewNormal(vec3 normal) {\n        return (uView * uModel * vec4(normal, 0.0)).xyz;\n      }\n    "],["\n      vec3 _modelToWorldNormal(vec3 normal) {\n        return (uModel * vec4(normal, 0.0)).xyz;\n      }\n\n      vec3 _modelToViewNormal(vec3 normal) {\n        return (uView * uModel * vec4(normal, 0.0)).xyz;\n      }\n    "])))):
(a.uniforms.add("uTransformNormal_GlobalFromModel ","mat3"),a.code.add(c.glsl(m||(m=b(["\n      vec3 _modelToWorldNormal(vec3 normal) {\n        return uTransformNormal_GlobalFromModel * normal;\n      }\n    "],["\n      vec3 _modelToWorldNormal(vec3 normal) {\n        return uTransformNormal_GlobalFromModel * normal;\n      }\n    "])))));f.silhouette?(d.attributes.add("normalA","vec3"),d.attributes.add("normalB","vec3"),a.code.add(c.glsl(n||(n=b(["\n      vec3 worldNormal() {\n        return _modelToWorldNormal(normalize(normalA + normalB));\n      }\n    "],
["\n      vec3 worldNormal() {\n        return _modelToWorldNormal(normalize(normalA + normalB));\n      }\n    "]))))):(d.attributes.add("normal","vec3"),a.code.add(c.glsl(p||(p=b(["\n      vec3 worldNormal() {\n        return _modelToWorldNormal(normal);\n      }\n    "],["\n      vec3 worldNormal() {\n        return _modelToWorldNormal(normal);\n      }\n    "])))));f.legacy?a.code.add(c.glsl(q||(q=b(["\n      vec3 worldFromModelPosition(vec3 position) {\n        return (uModel * vec4(position, 1.0)).xyz;\n      }\n\n      vec3 viewFromModelPosition(vec3 position) {\n        return (uView * vec4(worldFromModelPosition(position), 1.0)).xyz;\n      }\n\n      vec4 projFromViewPosition(vec3 position) {\n        return uProj * vec4(position, 1.0);\n      }\n    "],
["\n      vec3 worldFromModelPosition(vec3 position) {\n        return (uModel * vec4(position, 1.0)).xyz;\n      }\n\n      vec3 viewFromModelPosition(vec3 position) {\n        return (uView * vec4(worldFromModelPosition(position), 1.0)).xyz;\n      }\n\n      vec4 projFromViewPosition(vec3 position) {\n        return uProj * vec4(position, 1.0);\n      }\n    "])))):(d.include(u.DoublePrecision,f),a.code.add(c.glsl(r||(r=b(["\n      vec3 worldFromModelPosition(vec3 position) {\n        vec3 rotatedModelPosition \x3d uTransform_WorldFromModel_RS * position;\n\n        vec3 transform_CameraRelativeFromModel \x3d dpAdd(\n          uTransform_WorldFromModel_TL,\n          uTransform_WorldFromModel_TH,\n          -uTransform_WorldFromView_TL,\n          -uTransform_WorldFromView_TH\n        );\n\n        return transform_CameraRelativeFromModel + rotatedModelPosition;\n      }\n\n      vec3 viewFromModelPosition(vec3 position) {\n        return uTransform_ViewFromCameraRelative_RS * worldFromModelPosition(position);\n      }\n\n      vec4 projFromViewPosition(vec3 position) {\n        return uTransform_ProjFromView * vec4(position, 1.0);\n      }\n    "],
["\n      vec3 worldFromModelPosition(vec3 position) {\n        vec3 rotatedModelPosition \x3d uTransform_WorldFromModel_RS * position;\n\n        vec3 transform_CameraRelativeFromModel \x3d dpAdd(\n          uTransform_WorldFromModel_TL,\n          uTransform_WorldFromModel_TH,\n          -uTransform_WorldFromView_TL,\n          -uTransform_WorldFromView_TH\n        );\n\n        return transform_CameraRelativeFromModel + rotatedModelPosition;\n      }\n\n      vec3 viewFromModelPosition(vec3 position) {\n        return uTransform_ViewFromCameraRelative_RS * worldFromModelPosition(position);\n      }\n\n      vec4 projFromViewPosition(vec3 position) {\n        return uTransform_ProjFromView * vec4(position, 1.0);\n      }\n    "])))));
a.code.add(c.glsl(t||(t=b(["\n    float calculateExtensionLength(float extensionLength, float lineLength) {\n      return extensionLength / (log2(max(1.0, 256.0 / lineLength)) * 0.2 + 1.0);\n    }\n  "],["\n    float calculateExtensionLength(float extensionLength, float lineLength) {\n      return extensionLength / (log2(max(1.0, 256.0 / lineLength)) * 0.2 + 1.0);\n    }\n  "]))))}Object.defineProperty(e,"__esModule",{value:!0});e.EdgeUtil=g;(function(b){b.usesSketchLogic=function(b){return 1===b.mode||
2===b.mode};b.usesSolidLogic=function(b){return 0===b.mode||2===b.mode}})(g=e.EdgeUtil||(e.EdgeUtil={}));var h,k,l,m,n,p,q,r,t});