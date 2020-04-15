// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../../../core/tsSupport/makeTemplateObjectHelper ../../../../../core/libs/gl-matrix-2/vec3 ../../../../../core/libs/gl-matrix-2/vec3f64 ../shaderModules/interfaces".split(" "),function(r,b,c,p,q,e){function g(a,f){f.slicePlaneEnabled?(a.extensions.add("GL_OES_standard_derivatives"),a.fragment.uniforms.add("slicePlaneOrigin","vec3"),a.fragment.uniforms.add("slicePlaneBasis1","vec3"),a.fragment.uniforms.add("slicePlaneBasis2","vec3"),a.fragment.code.add(e.glsl(h||(h=c(["\n      struct SliceFactors {\n        float front;\n        float side0;\n        float side1;\n        float side2;\n        float side3;\n      };\n\n      SliceFactors calculateSliceFactors(vec3 pos) {\n        vec3 rel \x3d pos - slicePlaneOrigin;\n\n        vec3 slicePlaneNormal \x3d -cross(slicePlaneBasis1, slicePlaneBasis2);\n        float slicePlaneW \x3d -dot(slicePlaneNormal, slicePlaneOrigin);\n\n        float basis1Len2 \x3d dot(slicePlaneBasis1, slicePlaneBasis1);\n        float basis2Len2 \x3d dot(slicePlaneBasis2, slicePlaneBasis2);\n\n        float basis1Dot \x3d dot(slicePlaneBasis1, rel);\n        float basis2Dot \x3d dot(slicePlaneBasis2, rel);\n\n        return SliceFactors(\n          dot(slicePlaneNormal, pos) + slicePlaneW,\n          -basis1Dot - basis1Len2,\n          basis1Dot - basis1Len2,\n          -basis2Dot - basis2Len2,\n          basis2Dot - basis2Len2\n        );\n      }\n\n      bool sliceByFactors(SliceFactors factors) {\n        return factors.front \x3c 0.0\n          \x26\x26 factors.side0 \x3c 0.0\n          \x26\x26 factors.side1 \x3c 0.0\n          \x26\x26 factors.side2 \x3c 0.0\n          \x26\x26 factors.side3 \x3c 0.0;\n      }\n\n      bool sliceByPlane(vec3 pos) {\n        return sliceByFactors(calculateSliceFactors(pos));\n      }\n\n      vec4 applySliceHighlight(vec4 color, vec3 pos) {\n        SliceFactors factors \x3d calculateSliceFactors(pos);\n\n        if (sliceByFactors(factors)) {\n          return color;\n        }\n\n        const float HIGHLIGHT_WIDTH \x3d 1.0;\n        const vec4 HIGHLIGHT_COLOR \x3d vec4(0.0, 0.0, 0.0, 0.3);\n\n        factors.front /\x3d (2.0 * HIGHLIGHT_WIDTH) * fwidth(factors.front);\n        factors.side0 /\x3d (2.0 * HIGHLIGHT_WIDTH) * fwidth(factors.side0);\n        factors.side1 /\x3d (2.0 * HIGHLIGHT_WIDTH) * fwidth(factors.side1);\n        factors.side2 /\x3d (2.0 * HIGHLIGHT_WIDTH) * fwidth(factors.side2);\n        factors.side3 /\x3d (2.0 * HIGHLIGHT_WIDTH) * fwidth(factors.side3);\n\n        float highlightFactor \x3d (1.0 - step(0.5, factors.front))\n          * (1.0 - step(0.5, factors.side0))\n          * (1.0 - step(0.5, factors.side1))\n          * (1.0 - step(0.5, factors.side2))\n          * (1.0 - step(0.5, factors.side3));\n\n        return mix(color, vec4(HIGHLIGHT_COLOR.rgb, color.a), highlightFactor * HIGHLIGHT_COLOR.a);\n      }\n      #define rejectBySlice(_pos_) sliceByPlane(_pos_)\n      #define discardBySlice(_pos_) { if (sliceByPlane(_pos_)) discard; }\n      "],
["\n      struct SliceFactors {\n        float front;\n        float side0;\n        float side1;\n        float side2;\n        float side3;\n      };\n\n      SliceFactors calculateSliceFactors(vec3 pos) {\n        vec3 rel \x3d pos - slicePlaneOrigin;\n\n        vec3 slicePlaneNormal \x3d -cross(slicePlaneBasis1, slicePlaneBasis2);\n        float slicePlaneW \x3d -dot(slicePlaneNormal, slicePlaneOrigin);\n\n        float basis1Len2 \x3d dot(slicePlaneBasis1, slicePlaneBasis1);\n        float basis2Len2 \x3d dot(slicePlaneBasis2, slicePlaneBasis2);\n\n        float basis1Dot \x3d dot(slicePlaneBasis1, rel);\n        float basis2Dot \x3d dot(slicePlaneBasis2, rel);\n\n        return SliceFactors(\n          dot(slicePlaneNormal, pos) + slicePlaneW,\n          -basis1Dot - basis1Len2,\n          basis1Dot - basis1Len2,\n          -basis2Dot - basis2Len2,\n          basis2Dot - basis2Len2\n        );\n      }\n\n      bool sliceByFactors(SliceFactors factors) {\n        return factors.front \x3c 0.0\n          \x26\x26 factors.side0 \x3c 0.0\n          \x26\x26 factors.side1 \x3c 0.0\n          \x26\x26 factors.side2 \x3c 0.0\n          \x26\x26 factors.side3 \x3c 0.0;\n      }\n\n      bool sliceByPlane(vec3 pos) {\n        return sliceByFactors(calculateSliceFactors(pos));\n      }\n\n      vec4 applySliceHighlight(vec4 color, vec3 pos) {\n        SliceFactors factors \x3d calculateSliceFactors(pos);\n\n        if (sliceByFactors(factors)) {\n          return color;\n        }\n\n        const float HIGHLIGHT_WIDTH \x3d 1.0;\n        const vec4 HIGHLIGHT_COLOR \x3d vec4(0.0, 0.0, 0.0, 0.3);\n\n        factors.front /\x3d (2.0 * HIGHLIGHT_WIDTH) * fwidth(factors.front);\n        factors.side0 /\x3d (2.0 * HIGHLIGHT_WIDTH) * fwidth(factors.side0);\n        factors.side1 /\x3d (2.0 * HIGHLIGHT_WIDTH) * fwidth(factors.side1);\n        factors.side2 /\x3d (2.0 * HIGHLIGHT_WIDTH) * fwidth(factors.side2);\n        factors.side3 /\x3d (2.0 * HIGHLIGHT_WIDTH) * fwidth(factors.side3);\n\n        float highlightFactor \x3d (1.0 - step(0.5, factors.front))\n          * (1.0 - step(0.5, factors.side0))\n          * (1.0 - step(0.5, factors.side1))\n          * (1.0 - step(0.5, factors.side2))\n          * (1.0 - step(0.5, factors.side3));\n\n        return mix(color, vec4(HIGHLIGHT_COLOR.rgb, color.a), highlightFactor * HIGHLIGHT_COLOR.a);\n      }\n      #define rejectBySlice(_pos_) sliceByPlane(_pos_)\n      #define discardBySlice(_pos_) { if (sliceByPlane(_pos_)) discard; }\n      "])))),
f.sliceHighlightDisabled?a.fragment.code.add(e.glsl(k||(k=c(["\n        #define highlightSlice(_color_, _pos_) (_color_)\n      "],["\n        #define highlightSlice(_color_, _pos_) (_color_)\n      "])))):a.fragment.code.add(e.glsl(l||(l=c(["\n      #define highlightSlice(_color_, _pos_) applySliceHighlight(_color_, _pos_)\n    "],["\n      #define highlightSlice(_color_, _pos_) applySliceHighlight(_color_, _pos_)\n    "]))))):a.fragment.code.add(e.glsl(m||(m=c(["\n      #define rejectBySlice(_pos_) false\n      #define discardBySlice(_pos_) {}\n      #define highlightSlice(_color_, _pos_) (_color_)\n    "],
["\n      #define rejectBySlice(_pos_) false\n      #define discardBySlice(_pos_) {}\n      #define highlightSlice(_color_, _pos_) (_color_)\n    "]))))}Object.defineProperty(b,"__esModule",{value:!0});b.Slice=g;(function(a){a.bindUniformsWithOrigin=function(f,b,d){a.bindUniforms(f,b,d.slicePlane,d.origin)};a.bindUniforms=function(a,b,d,c){b.slicePlaneEnabled&&(c?(p.vec3.subtract(n,d.origin,c),a.setUniform3fv("slicePlaneOrigin",n)):a.setUniform3fv("slicePlaneOrigin",d.origin),a.setUniform3fv("slicePlaneBasis1",
d.basis1),a.setUniform3fv("slicePlaneBasis2",d.basis2))}})(g=b.Slice||(b.Slice={}));var n=q.vec3f64.create(),h,k,l,m});