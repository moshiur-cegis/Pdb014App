// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../../../core/libs/gl-matrix-2/mat4 ../../../../../core/libs/gl-matrix-2/mat4f64 ../../../support/buffer/glUtil ../../lib/DefaultVertexAttributeLocations ../../lib/IntervalUtilities ../../lib/ResizableFloat32Array ../../lib/Util ../WaterGLMaterial ./Instance ./utils ../../../../webgl/BufferObject ../../../../webgl/Util ../../../../webgl/VertexArrayObject".split(" "),function(t,L,w,r,z,A,x,B,v,C,D,k,E,F,G){function H(c,a,b,g){for(var m=new Map,f=a.vertexBufferLayout.stride/
4,d=function(b,g){var h=b.origin,d=c.get(h.id),e=m.get(h.id);null==e&&(e={optimalCount:null==d?0:d.optimalCount,sparseCount:null==d?0:d.buffer.size,toAdd:[],toRemove:[],origin:h.vec3},m.set(h.id,e));h=a.elementCount(b.data)*f;g?(e.optimalCount+=h,e.sparseCount+=h,e.toAdd.push(b)):(e.optimalCount-=h,e.toRemove.push(b))},l=0;l<b.length;l++){var e=b[l];d(e,!0)}for(b=0;b<g.length;b++)e=g[b],d(e,!1);return m}t=function(){function c(a,b,g,m){void 0===m&&(m=A.Default3D);this.type="MergedRenderer";this._dataByOrigin=
new Map;this._highlightCount=0;this._rctx=a;this._vertexAttributeLocations=m;this._material=g;this._materialRep=b;this._glMaterials=k.acquireMaterials(this._material,this._materialRep);this._bufferWriter=g.createBufferWriter()}c.prototype.dispose=function(){k.releaseMaterials(this._material,this._materialRep)};Object.defineProperty(c.prototype,"isEmpty",{get:function(){return 0===this._dataByOrigin.size},enumerable:!0,configurable:!0});Object.defineProperty(c.prototype,"hasHighlights",{get:function(){return 0<
this._highlightCount},enumerable:!0,configurable:!0});c.prototype.hasWater=function(){var a=!1;this._glMaterials.forEach(function(b){a=a||b instanceof C.WaterGLMaterial});return a};c.prototype.renderPriority=function(){return this._material.renderPriority};c.prototype.modify=function(a){var b=this,g=I;g.clear();this.updateGeometries(a.toUpdate,g);this.addAndRemoveGeometries(a.toAdd,a.toRemove,g);this.updateHighlightCount();g.forEach(function(a){return b.updateDisplayedIndexRanges(a)})};c.prototype.addAndRemoveGeometries=
function(a,b,g){var m=this,f=this._bufferWriter,d=f.vertexBufferLayout,l=d.stride/4,e=this._dataByOrigin,h=H(e,f,a,b);h.forEach(function(a,b){h.delete(b);var f=a.optimalCount,n=a.sparseCount,c=e.get(b);null==c&&(v.assert(0<f),c=m.createData(d,f,a.origin),e.set(b,c));if(0===f)c.vao.dispose(!0),c.vao=null,e.delete(b);else{var y=f<a.sparseCount/2;b=J;var k=c.buffer.size,p=c.buffer.array,f=c.buffer.resize(y?f:n,!1);y||f?m.removeAndRebuild(c,a.toRemove,l,p,b):0<a.toRemove.length?(m.removeByErasing(c,a.toRemove,
l,b),0<a.toAdd.length&&(b.end=k)):(b.begin=k,b.end=k);f=K;v.setMatrixTranslation3(f,-a.origin[0],-a.origin[1],-a.origin[2]);m.append(c,a.toAdd,l,f,b);a=c.vao.vertexBuffers.geometry;a.byteSize!==c.buffer.array.buffer.byteLength?a.setData(c.buffer.array):(n=b.begin,f=b.end,n<f&&(n*=4,a.setSubData(c.buffer.array,n,n,4*f)));(b.updatedDisplayedIndexRange||c.displayedIndexRanges)&&g.add(c)}})};c.prototype.updateGeometries=function(a,b){for(var g=this._bufferWriter,c=g.vertexBufferLayout.stride/4,f=0;f<
a.length;f++){var d=a[f],l=d.updateType,d=d.renderGeometry,e=this._dataByOrigin.get(d.origin.id),h=e&&e.instances.get(d.uniqueName);if(!h)break;l&1&&(h.displayedIndexRange=k.generateRenderGeometryVisibleIndexRanges(d),b.add(e));l&17&&(h.highlightedIndexRanges=k.generateRenderGeometryHighlightRanges(d),e.highlightCount=null);l&6&&(l=e.buffer.array,e=e.vao,k.calculateTransformRelToOrigin(d,u,p),g.write({transformation:u,invTranspTransformation:p},d.data,g.vertexBufferLayout.createView(l.buffer),h.from),
v.assert(h.from+g.elementCount(d.data)===h.to,"material VBO layout has changed"),e.vertexBuffers.geometry.setSubData(l,h.from*c*4,h.from*c*4,h.to*c*4))}};c.prototype.updateDisplayedIndexRanges=function(a){a.displayedIndexRanges=[];var b=!0;a.instances.forEach(function(g){g.displayedIndexRange?(a.displayedIndexRanges.push.apply(a.displayedIndexRanges,x.offsetIntervals(g.displayedIndexRange,g.from)),b=!1):a.displayedIndexRanges.push([g.from,g.to-1])});a.displayedIndexRanges=b?null:x.mergeIntervals(a.displayedIndexRanges)};
c.prototype.updateHighlightCount=function(){var a=this;this._highlightCount=0;this._dataByOrigin.forEach(function(b){if(null==b.highlightCount){var g=0;b.instances.forEach(function(a){a.highlightedIndexRanges&&++g});b.highlightCount=g}a._highlightCount+=b.highlightCount})};c.prototype.updateLogic=function(a){return this._material.update(a)};c.prototype.render=function(a,b,g,c){var f=this,d=this._rctx,l=this._glMaterials.get(b.pass),e=4===b.pass;2===b.pass&&null===a&&(a=19);if(!l||1===l.ensureResources(d)||
null!=a&&!l.beginSlot(a)||e&&0===this._highlightCount)return!1;l.bind(d,g);b=l.getProgram();b.setUniformMatrix4fv("model",r.mat4f64.IDENTITY);b.hasUniform("modelNormal")&&b.setUniformMatrix4fv("modelNormal",r.mat4f64.IDENTITY);var h=!1;this._dataByOrigin.forEach(function(a){e&&0===a.highlightCount||(g.origin=a.origin,l.bindView(g),h=e?f.renderHighlightPass(l,a,c)||h:f.renderDefaultPass(l,a,c)||h)});l.release();return h};c.prototype.renderDefaultPass=function(a,b,g){var c=this._rctx,f=a.getDrawMode(),
d=b.displayedIndexRanges;if(d&&0===d.length)return!1;a.ensureAttributeLocations(b.vao);c.bindVAO(b.vao);d?k.drawArraysFaceRange(c,d,0,f,g):(a=4*b.buffer.size/F.getStride(b.vao.layout.geometry),k.drawArrays(c,f,0,a,g));return!0};c.prototype.renderHighlightPass=function(a,b,g){var c=this._rctx,f=a.getDrawMode(),d=b.vao;a.ensureAttributeLocations(d);c.bindVAO(d);var l=!1;b.instances.forEach(function(a){var b=a.highlightedIndexRanges;if(b&&0!==b.length)for(var e=0;e<b.length;e++){var d=b[e];k.drawArrays(c,
f,d.range?d.range[0]+a.from:a.from,d.range?d.range[1]-d.range[0]+1:a.to-a.from,g);l=!0}});return l};c.prototype.createData=function(a,b,c){return{instances:new Map,vao:new G(this._rctx,this._vertexAttributeLocations,{geometry:z.glLayout(a)},{geometry:E.createVertex(this._rctx,35044)}),buffer:new B.ResizableFloat32Array(b),optimalCount:0,origin:c,highlightCount:0}};c.prototype.removeAndRebuild=function(a,b,c,m,f){for(var d=0;d<b.length;d++){var g=b[d].uniqueName,e=a.instances.get(g);a.optimalCount-=
(e.to-e.from)*c;a.instances.delete(g)}var h=0,n=a.buffer.array;f.begin=0;f.end=0;var k=-1,q=-1,p=0;a.instances.forEach(function(a){var b=a.from*c,d=a.to*c,e=d-b;k!==q&&q!==b?(n.set(m.subarray(k,q),p),p+=q-k,k=b):-1===k&&(k=b);q=d;a.from=h/c;h+=e;a.to=h/c});k!==q&&n.set(m.subarray(k,q),p);f.end=h};c.prototype.removeByErasing=function(a,b,c,m){m.begin=Infinity;m.end=-Infinity;for(var f=-1,d=-1,g=0;g<b.length;g++){var e=b[g].uniqueName,h=a.instances.get(e),k=h.from*c,h=h.to*c;f!==d&&d!==k?(a.buffer.erase(f,
d),f=k):-1===f&&(f=k);d=h;a.instances.delete(e);a.optimalCount-=h-k;k<m.begin&&(m.begin=k);h>m.end&&(m.end=h)}f!==d&&a.buffer.erase(f,d)};c.prototype.append=function(a,b,c,m,f){f.updatedDisplayedIndexRange=!1;for(var d=this._bufferWriter,g=0;g<b.length;g++){var e=b[g],h=e.data;w.mat4.multiply(u,m,e.transformation);w.mat4.invert(p,u);w.mat4.transpose(p,p);var n=f.end;d.write({transformation:u,invTranspTransformation:p},h,d.vertexBufferLayout.createView(a.buffer.array.buffer),f.end/c);var h=d.elementCount(h)*
c,r=n+h;v.assert(null==a.instances.get(e.uniqueName));var q=k.generateRenderGeometryVisibleIndexRanges(e),t=k.generateRenderGeometryHighlightRanges(e);t&&(a.highlightCount=null);n=new D(e.name,n/c,r/c,q,t,void 0,void 0,e.idx);a.instances.set(e.uniqueName,n);q&&(f.updatedDisplayedIndexRange=!0);a.optimalCount+=h;f.end+=h}};Object.defineProperty(c.prototype,"test",{get:function(){return{material:this._material}},enumerable:!0,configurable:!0});return c}();var J={updatedDisplayedIndexRange:!1,begin:0,
end:0},K=r.mat4f64.create(),u=r.mat4f64.create(),p=r.mat4f64.create(),I=new Set;return t});