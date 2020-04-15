// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../../core/libs/gl-matrix-2/mat4 ../../../../core/libs/gl-matrix-2/mat4f64 ../../../../core/libs/gl-matrix-2/vec3 ../../../../core/libs/gl-matrix-2/vec3f64 ../../support/mathUtils ./ComponentUtils ./geometryDataUtils ./HighlightUtils ./Util".split(" "),function(p,q,g,h,c,n,k,d,l,m,f){return function(){function a(b,e,a,c,d,f,g,h,k,l,m){this.shaderTransformationDirty=!0;this.data=b.toRenderData();this.componentOffsets=b.componentOffsets;this.boundingInfo=e;this.material=
a;this.origin=null;this.center=n.vec3f64.create();this.bsRadius=0;this.transformation=null;this.calculateShaderTransformation=d;c&&this.updateTransformation(c,f);this.castShadow=g;this.singleUse=h;this.name=k;this.uniqueName=l;this.idx=m;this.instanceParameters={}}a.prototype.updateTransformation=function(b,e){this.transformation=b;this.shaderTransformationDirty=!0;this.bsRadius=this.getBoundingSphere(b,e,this.center)};a.prototype.shaderTransformationChanged=function(){this.shaderTransformationDirty=
!0};a.prototype.getBoundingSphere=function(b,e,a){e=e||k.maxScale(b);c.vec3.transformMat4(a,this.boundingInfo.getCenter(),b);return this.boundingInfo.getBSRadius()*e};Object.defineProperty(a.prototype,"hasShaderTransformation",{get:function(){return!!this.calculateShaderTransformation},enumerable:!0,configurable:!0});Object.defineProperty(a.prototype,"componentCount",{get:function(){return d.componentCount(this.componentOffsets)},enumerable:!0,configurable:!0});a.prototype.getShaderTransformation=
function(){if(!this.calculateShaderTransformation)return this.transformation;this.shaderTransformationDirty&&(this.shaderTransformation||(this.shaderTransformation=h.mat4f64.create()),g.mat4.copy(this.shaderTransformation,this.calculateShaderTransformation(this.transformation)),this.shaderTransformationDirty=!1);return this.shaderTransformation};a.prototype.computeAttachmentOrigin=function(b){if(this.material.computeAttachmentOrigin)return this.material.computeAttachmentOrigin(this,b)?(c.vec3.transformMat4(b,
b,this.transformation),!0):!1;var a=this.getIndices(f.VertexAttrConstants.POSITION),d=this.getAttribute(f.VertexAttrConstants.POSITION);return l.computeAttachmentOriginTriangles(d,a,b)?(c.vec3.transformMat4(b,b,this.transformation),!0):!1};a.prototype.getIndices=function(b){return"indices"in this.data?this.data.indices[b]:null};a.prototype.getAttribute=function(b){return"vertexAttr"in this.data?this.data.vertexAttr[b]:null};a.prototype.addHighlight=function(b){var a=m.generateHighlightId(),c=this.instanceParameters;
c.componentHighlights=d.addHighlight(c.componentHighlights,null,b,a);return a};a.prototype.removeHighlight=function(b){var a=this.instanceParameters;a.componentHighlights=d.removeHighlight(a.componentHighlights,b)};return a}()});