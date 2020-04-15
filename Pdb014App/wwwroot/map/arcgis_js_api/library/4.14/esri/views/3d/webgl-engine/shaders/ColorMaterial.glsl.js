// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../../core/tsSupport/makeTemplateObjectHelper ../core/shaderLibrary/Slice.glsl ../core/shaderLibrary/Transform.glsl ../core/shaderLibrary/attributes/VertexColor.glsl ../core/shaderModules/interfaces ../core/shaderModules/ShaderBuilder".split(" "),function(n,c,d,h,k,l,e,m){Object.defineProperty(c,"__esModule",{value:!0});c.build=function(b){var a=new m.ShaderBuilder;a.include(k.Transform,{linearDepth:!1});a.include(l.VertexColor,b);a.vertex.uniforms.add("proj","mat4").add("view",
"mat4").add("model","mat4");a.attributes.add("position","vec3");a.varyings.add("vpos","vec3");a.vertex.code.add(e.glsl(f||(f=d(["\n    void main(void) {\n      vpos \x3d (model * vec4(position, 1.0)).xyz;\n      forwardNormalizedVertexColor();\n      gl_Position \x3d transformPosition(proj, view, vpos);\n    }\n  "],["\n    void main(void) {\n      vpos \x3d (model * vec4(position, 1.0)).xyz;\n      forwardNormalizedVertexColor();\n      gl_Position \x3d transformPosition(proj, view, vpos);\n    }\n  "]))));
a.include(h.Slice,b);a.fragment.uniforms.add("eColor","vec4");a.fragment.code.add(e.glsl(g||(g=d(["\n    void main() {\n      discardBySlice(vpos);\n      ","\n      gl_FragColor \x3d highlightSlice(gl_FragColor, vpos);\n    }\n    "],["\n    void main() {\n      discardBySlice(vpos);\n      ","\n      gl_FragColor \x3d highlightSlice(gl_FragColor, vpos);\n    }\n    "])),b.attributeColor?"gl_FragColor \x3d vColor * eColor;":"gl_FragColor \x3d eColor;"));return a};var f,g});