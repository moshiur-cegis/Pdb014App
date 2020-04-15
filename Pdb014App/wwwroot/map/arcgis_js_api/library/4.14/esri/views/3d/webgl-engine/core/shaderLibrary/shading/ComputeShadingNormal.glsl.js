// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../../../../core/tsSupport/makeTemplateObjectHelper ../attributes/VertexNormal.glsl ../attributes/VertexPosition.glsl ../../shaderModules/interfaces".split(" "),function(t,g,c,r,f,d){Object.defineProperty(g,"__esModule",{value:!0});g.ComputeShadingNormal=function(e,a){var b=e.fragment;0===a.doubleSidedMode?b.code.add(d.glsl(h||(h=c(["\n      vec3 _adjustDoublesided(vec3 normal) {\n        return normal;\n      }\n    "],["\n      vec3 _adjustDoublesided(vec3 normal) {\n        return normal;\n      }\n    "])))):
1===a.doubleSidedMode?(e.include(f.VertexPosition,a),b.uniforms.add("uTransform_ViewFromCameraLocal_T","vec3"),b.code.add(d.glsl(k||(k=c(["\n      vec3 _adjustDoublesided(vec3 normal) {\n        vec3 viewDir \x3d vPositionWorldCameraRelative + uTransform_ViewFromCameraLocal_T;\n        return dot(normal, viewDir) \x3e 0.0 ? -normal : normal;\n      }\n    "],["\n      vec3 _adjustDoublesided(vec3 normal) {\n        vec3 viewDir \x3d vPositionWorldCameraRelative + uTransform_ViewFromCameraLocal_T;\n        return dot(normal, viewDir) \x3e 0.0 ? -normal : normal;\n      }\n    "]))))):
2===a.doubleSidedMode&&b.code.add(d.glsl(l||(l=c(["\n      vec3 _adjustDoublesided(vec3 normal) {\n        return gl_FrontFacing ? normal : -normal;\n      }\n    "],["\n      vec3 _adjustDoublesided(vec3 normal) {\n        return gl_FrontFacing ? normal : -normal;\n      }\n    "]))));0===a.normalType||1===a.normalType?(e.include(r.VertexNormal,a),b.code.add(d.glsl(m||(m=c(["\n      vec3 shadingNormalWorld() {\n        return _adjustDoublesided(normalize(vNormalWorld));\n      }\n\n      vec3 shadingNormal_view() {\n        vec3 normal \x3d normalize(vNormalView);\n        return gl_FrontFacing ? normal : -normal;\n      }\n    "],
["\n      vec3 shadingNormalWorld() {\n        return _adjustDoublesided(normalize(vNormalWorld));\n      }\n\n      vec3 shadingNormal_view() {\n        vec3 normal \x3d normalize(vNormalView);\n        return gl_FrontFacing ? normal : -normal;\n      }\n    "]))))):3===a.normalType?(e.extensions.add("GL_OES_standard_derivatives"),e.include(f.VertexPosition,a),b.code.add(d.glsl(n||(n=c(["\n      vec3 shadingNormalWorld() {\n        return normalize(cross(\n          dFdx(vPositionWorldCameraRelative),\n          dFdy(vPositionWorldCameraRelative)\n        ));\n      }\n\n      vec3 shadingNormal_view() {\n        // swizzling and negation figured out through trial and error\n        return -normalize(cross(dFdx(vPosition_view),dFdy(vPosition_view))).xzy;\n      }\n    "],
["\n      vec3 shadingNormalWorld() {\n        return normalize(cross(\n          dFdx(vPositionWorldCameraRelative),\n          dFdy(vPositionWorldCameraRelative)\n        ));\n      }\n\n      vec3 shadingNormal_view() {\n        // swizzling and negation figured out through trial and error\n        return -normalize(cross(dFdx(vPosition_view),dFdy(vPosition_view))).xzy;\n      }\n    "]))))):2===a.normalType&&(0===a.viewingMode?(e.include(f.VertexPosition,a),b.code.add(d.glsl(p||(p=c(["\n        vec3 shadingNormalWorld() {\n          return normalize(positionWorld());\n        }\n      "],
["\n        vec3 shadingNormalWorld() {\n          return normalize(positionWorld());\n        }\n      "]))))):1===a.viewingMode&&b.code.add(d.glsl(q||(q=c(["\n        vec3 shadingNormalWorld() {\n          return vec3(0.0, 0.0, 1.0);\n        }\n      "],["\n        vec3 shadingNormalWorld() {\n          return vec3(0.0, 0.0, 1.0);\n        }\n      "])))))};var h,k,l,m,n,p,q});