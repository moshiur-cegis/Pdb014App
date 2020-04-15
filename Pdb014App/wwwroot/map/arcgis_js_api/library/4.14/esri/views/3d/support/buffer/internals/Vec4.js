// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define(["require","exports","../../../../../core/libs/gl-matrix-2/vec4"],function(f,g,k){Object.defineProperty(g,"__esModule",{value:!0});f=function(){function c(a,b,c,d,e){void 0===c&&(c=0);this.TypedArrayConstructor=a;this.elementCount=4;a=this.TypedArrayConstructor;void 0===d&&(d=4*a.BYTES_PER_ELEMENT);var h=0===b.byteLength?0:c;this.typedBuffer=null==e?new a(b,h):new a(b,h,(e-c)/a.BYTES_PER_ELEMENT);this.typedBufferStride=d/a.BYTES_PER_ELEMENT;this.count=Math.ceil(this.typedBuffer.length/this.typedBufferStride);
this.stride=this.typedBufferStride*this.TypedArrayConstructor.BYTES_PER_ELEMENT}c.prototype.getVec=function(a,b){return k.vec4.set(b,this.typedBuffer[a*this.typedBufferStride],this.typedBuffer[a*this.typedBufferStride+1],this.typedBuffer[a*this.typedBufferStride+2],this.typedBuffer[a*this.typedBufferStride+3])};c.prototype.setVec=function(a,b){this.typedBuffer[a*this.typedBufferStride]=b[0];this.typedBuffer[a*this.typedBufferStride+1]=b[1];this.typedBuffer[a*this.typedBufferStride+2]=b[2];this.typedBuffer[a*
this.typedBufferStride+3]=b[3]};c.prototype.get=function(a,b){return this.typedBuffer[a*this.typedBufferStride+b]};c.prototype.set=function(a,b,c){this.typedBuffer[a*this.typedBufferStride+b]=c};c.prototype.copyFrom=function(a,b,c){var d=this.typedBuffer,e=b.typedBuffer;a*=this.typedBufferStride;b=c*b.typedBufferStride;d[a]=e[b];d[a+1]=e[b+1];d[a+2]=e[b+2];d[a+3]=e[b+3]};Object.defineProperty(c.prototype,"buffer",{get:function(){return this.typedBuffer.buffer},enumerable:!0,configurable:!0});c.ElementCount=
4;return c}();g.BufferViewVec4Impl=f});