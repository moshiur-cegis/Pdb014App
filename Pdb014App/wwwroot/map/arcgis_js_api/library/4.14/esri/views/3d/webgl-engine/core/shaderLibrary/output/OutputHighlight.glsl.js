// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define(["require","exports","../../../../../../core/tsSupport/makeTemplateObjectHelper","../../shaderModules/interfaces"],function(h,a,f,g){function d(b){b.fragment.uniforms.add("depthTex","sampler2D");b.fragment.uniforms.add("highlightViewportPixelSz","vec4");b.fragment.code.add(g.glsl(e||(e=f(["\n    void outputHighlight() {\n      vec4 fragCoord \x3d gl_FragCoord;\n\n      float sceneDepth \x3d texture2D(depthTex, (fragCoord.xy - highlightViewportPixelSz.xy) * highlightViewportPixelSz.zw).r;\n      if (fragCoord.z \x3e sceneDepth + 5e-6) {\n        gl_FragColor \x3d vec4(1.0, 1.0, 0.0, 1.0);\n      }\n      else {\n        gl_FragColor \x3d vec4(1.0, 0.0, 1.0, 1.0);\n      }\n    }\n  "],
["\n    void outputHighlight() {\n      vec4 fragCoord \x3d gl_FragCoord;\n\n      float sceneDepth \x3d texture2D(depthTex, (fragCoord.xy - highlightViewportPixelSz.xy) * highlightViewportPixelSz.zw).r;\n      if (fragCoord.z \x3e sceneDepth + 5e-6) {\n        gl_FragColor \x3d vec4(1.0, 1.0, 0.0, 1.0);\n      }\n      else {\n        gl_FragColor \x3d vec4(1.0, 0.0, 1.0, 1.0);\n      }\n    }\n  "]))))}Object.defineProperty(a,"__esModule",{value:!0});a.OutputHighlight=d;(function(b){b.bindOutputHighlight=
function(b,a,c){b.bindTexture(c.highlightDepthTexture,5);a.setUniform1i("depthTex",5);a.setUniform4f("highlightViewportPixelSz",0,0,1/c.viewport[2],1/c.viewport[3])}})(d=a.OutputHighlight||(a.OutputHighlight={}));var e});