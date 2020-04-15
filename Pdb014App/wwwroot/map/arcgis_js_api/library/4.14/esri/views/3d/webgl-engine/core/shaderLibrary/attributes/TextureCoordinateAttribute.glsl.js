// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define(["require","exports","../../../../../../core/tsSupport/makeTemplateObjectHelper","../../shaderModules/interfaces"],function(k,e,b,c){Object.defineProperty(e,"__esModule",{value:!0});e.TextureCoordinateAttribute=function(a,d){1===d.attributeTextureCoordinates&&(a.attributes.add("uv0","vec2"),a.varyings.add("vuv0","vec2"),a.vertex.code.add(c.glsl(f||(f=b(["\n      void forwardTextureCoordinates() {\n        vuv0 \x3d uv0;\n      }\n    "],["\n      void forwardTextureCoordinates() {\n        vuv0 \x3d uv0;\n      }\n    "])))));
2===d.attributeTextureCoordinates&&(a.attributes.add("uv0","vec2"),a.varyings.add("vuv0","vec2"),a.attributes.add("uvRegion","vec4"),a.varyings.add("vuvRegion","vec4"),a.vertex.code.add(c.glsl(g||(g=b(["\n      void forwardTextureCoordinates() {\n        vuv0 \x3d uv0;\n        vuvRegion \x3d uvRegion;\n      }\n    "],["\n      void forwardTextureCoordinates() {\n        vuv0 \x3d uv0;\n        vuvRegion \x3d uvRegion;\n      }\n    "])))));0===d.attributeTextureCoordinates&&a.vertex.code.add(c.glsl(h||
(h=b(["\n      void forwardTextureCoordinates() {}\n    "],["\n      void forwardTextureCoordinates() {}\n    "]))))};var f,g,h});