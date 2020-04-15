// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define(["require","exports","../../../../../../core/tsSupport/makeTemplateObjectHelper","../../shaderModules/interfaces"],function(h,d,b,c){Object.defineProperty(d,"__esModule",{value:!0});d.AnalyticalSkyModel=function(a){a=a.fragment.code;a.add(c.glsl(e||(e=b(["\n    vec3 evaluateDiffuseIlluminationHemisphere(vec3 ambientGround, vec3 ambientSky, float NdotNG)\n    {\n      return ((1.0 - NdotNG) * ambientGround + (1.0 + NdotNG) * ambientSky) * 0.5;\n    }\n    "],["\n    vec3 evaluateDiffuseIlluminationHemisphere(vec3 ambientGround, vec3 ambientSky, float NdotNG)\n    {\n      return ((1.0 - NdotNG) * ambientGround + (1.0 + NdotNG) * ambientSky) * 0.5;\n    }\n    "]))));
a.add(c.glsl(f||(f=b(["\n    float integratedRadiance(float cosTheta2, float roughness)\n    {\n      return (cosTheta2 - 1.0) / (cosTheta2 * (1.0 - roughness * roughness) - 1.0);\n    }\n    "],["\n    float integratedRadiance(float cosTheta2, float roughness)\n    {\n      return (cosTheta2 - 1.0) / (cosTheta2 * (1.0 - roughness * roughness) - 1.0);\n    }\n    "]))));a.add(c.glsl(g||(g=b(["\n    vec3 evaluateSpecularIlluminationHemisphere(vec3 ambientGround, vec3 ambientSky, float RdotNG, float roughness)\n    {\n      float cosTheta2 \x3d 1.0 - RdotNG * RdotNG;\n      float intRadTheta \x3d integratedRadiance(cosTheta2, roughness);\n\n      // Calculate the integrated directional radiance of the ground and the sky\n      float ground \x3d RdotNG \x3c 0.0 ? 1.0 - intRadTheta : 1.0 + intRadTheta;\n      float sky \x3d 2.0 - ground;\n      return (ground * ambientGround + sky * ambientSky) * 0.5;\n    }\n    "],
["\n    vec3 evaluateSpecularIlluminationHemisphere(vec3 ambientGround, vec3 ambientSky, float RdotNG, float roughness)\n    {\n      float cosTheta2 \x3d 1.0 - RdotNG * RdotNG;\n      float intRadTheta \x3d integratedRadiance(cosTheta2, roughness);\n\n      // Calculate the integrated directional radiance of the ground and the sky\n      float ground \x3d RdotNG \x3c 0.0 ? 1.0 - intRadTheta : 1.0 + intRadTheta;\n      float sky \x3d 2.0 - ground;\n      return (ground * ambientGround + sky * ambientSky) * 0.5;\n    }\n    "]))))};
var e,f,g});