// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define(["require","exports","../../../../../core/mathUtils","../../../../../core/libs/gl-matrix-2/vec2f32"],function(e,f,h,g){Object.defineProperty(f,"__esModule",{value:!0});e=function(){function b(a,b,c,d){this.center=g.vec2f32.fromValues(a,b);this.centerT=g.vec2f32.create();this.halfWidth=c/2;this.halfHeight=d/2;this.width=c;this.height=d}Object.defineProperty(b.prototype,"x",{get:function(){return this.center[0]},set:function(a){this.center[0]=a},enumerable:!0,configurable:!0});Object.defineProperty(b.prototype,
"y",{get:function(){return this.center[1]},set:function(a){this.center[1]=a},enumerable:!0,configurable:!0});Object.defineProperty(b.prototype,"blX",{get:function(){return this.center[0]-this.halfWidth},enumerable:!0,configurable:!0});Object.defineProperty(b.prototype,"blY",{get:function(){return this.center[1]-this.halfHeight},enumerable:!0,configurable:!0});Object.defineProperty(b.prototype,"trX",{get:function(){return this.center[0]+this.halfWidth},enumerable:!0,configurable:!0});Object.defineProperty(b.prototype,
"trY",{get:function(){return this.center[1]+this.halfHeight},enumerable:!0,configurable:!0});b.prototype.clone=function(){return new b(this.x,this.y,this.width,this.height)};b.prototype.serialize=function(a){a.writeF32(this.center[0]);a.writeF32(this.center[1]);a.push(this.width);a.push(this.height);return a};b.prototype.findCollisionDelta=function(a){return h.log2(Math.min((a.halfWidth+this.halfWidth)/Math.abs(a.centerT[0]-this.centerT[0]),(a.halfHeight+this.halfHeight)/Math.abs(a.centerT[1]-this.centerT[1])))};
b.prototype.extend=function(a){var b=Math.min(this.blX,a.blX),c=Math.min(this.blY,a.blY),d=Math.max(this.trY,a.trY);this.width=Math.max(this.trX,a.trX)-b;this.height=d-c;this.halfWidth=this.width/2;this.halfHeight=this.height/2;this.x=b+this.halfWidth;this.y=c+this.halfHeight};b.deserialize=function(a){var e=a.readF32(),c=a.readF32(),d=a.readInt32();a=a.readInt32();return new b(e,c,d,a)};return b}();f.default=e});